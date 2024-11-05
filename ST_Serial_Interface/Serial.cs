using System.Collections.Concurrent;
using System.IO.Ports;
using System.Text;

namespace ST_Serial_Interface
{
    internal class Serial
    {
        // Current app phase
        // 0 - Initialize; 1 -Synchronization; 2 - Activate
        public static int phase = 0;

        // Serial port declaration
        private static SerialPort? serial_port;

        // Builtin string comparer
        private static readonly StringComparer string_comparer = StringComparer.OrdinalIgnoreCase;

        // Thread related objects
        private static readonly BlockingCollection<SerialPort> queue = new();
        private static readonly SemaphoreSlim semaphore = new(3);
        private static readonly object buffer_lock = new();
        private static readonly StringBuilder data_buffer = new();


        // Rolodex declaration
        private static readonly Rolodex rolodex = new();

        static Serial()
        {
            Task.Run(ProcessQueue);
        }

        public static void Setup(string port, int baud_rate, string parity, int data_bits, string stop_bits, string handshake, int timeout)
        {
            rolodex.FunctionMapper();

            serial_port = new SerialPort(port, baud_rate, ParseParity(parity), data_bits, ParseStopBits(stop_bits))
            {
                Handshake = ParseHandshake(handshake),
                WriteTimeout = timeout,
                ReadTimeout = timeout
            };

            serial_port.DataReceived += DataReceivedHandler;
        }

        public static bool Start()
        {
            if (serial_port == null) return false;

            try
            {
                serial_port.Open();
                STSI.connection_message = $"ST Serial Interface started on {serial_port.PortName}";
                return true;
            }
            catch (System.IO.IOException)
            {
                STSI.connection_message = $"Unable to connect to {serial_port.PortName} :(";
                return false;
            }
        }

        public static void Stop()
        {
            serial_port?.Close();
        }

        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            if (sender is SerialPort sp && sp.BytesToRead > 0)
            {
                queue.Add(sp);
            }
        }

        private static async Task ProcessQueue()
        {
            foreach (var sp in queue.GetConsumingEnumerable())
            {
                await HandleData(sp);
            }
        }

        private static async Task HandleData(SerialPort sp)
        {
            await semaphore.WaitAsync();
            try
            {
                byte[] buffer = new byte[sp.BytesToRead];
                sp.Read(buffer, 0, buffer.Length);

                if (BinaryTools.IsBinaryData(buffer))
                {
                    sp.Write(Encoding.UTF8.GetBytes("NAK\n"), 0, 4);
                    return;
                }

                lock (buffer_lock)
                {
                    data_buffer.Append(Encoding.UTF8.GetString(buffer));
                    ProcessMessages(sp);
                }
            }
            catch (TimeoutException) { }
            finally { semaphore.Release(); }
        }

        private static void ProcessMessages(SerialPort sp)
        {
            while (data_buffer.ToString().Contains('\n'))
            {
                string full_message = data_buffer.ToString();
                int delimiter_index = full_message.IndexOf('\n');
                string received_text = full_message[..delimiter_index].Trim();

                data_buffer.Remove(0, delimiter_index + 1);

                string response_text = ProcessData(received_text);

                if (STSI.verbose && response_text == "NAK") { STSI.Logger($"{received_text} : NAK", ""); }

                sp.Write(Encoding.UTF8.GetBytes(response_text + '\n'), 0, response_text.Length + 1);
            }
        }

        private static string ProcessData(string message)
        {
            message = message.Trim().ToUpper();

            if (string_comparer.Equals(message, "SYN") && phase == 0)
            {
                phase = 1;
                return "ACK";
            }

            if (string_comparer.Equals(message, "ACT") && phase == 1)
            {
                phase = 2;
                LogRegisterFunctions();
                return "ACK";
            }

            if (phase == 1 && (message.StartsWith("CMD") || message.StartsWith("RBOOL") || message.StartsWith("RINT") || message.StartsWith("RFLT")))
            {
                return CommandBuilder(message);
            }

            if (phase == 2 && message.StartsWith("EXC"))
            {
                return CommandExecuter(message);
            }

            if (message.StartsWith("RST"))
            {
                phase = 0;
                rolodex.Channels.Clear();
                return "ACK";
            }

            if (message.StartsWith("DBG="))
            {
                STSI.Logger(message.Split(new[] { '=' }, 2)[1], "");
                return "ACK";
            }

            return "NAK";
        }

        private static void LogRegisterFunctions()
        {
            if (STSI.verbose)
            {
                STSI.Logger($"Registered Runctions: {rolodex.Channels.Count}", "");
                foreach (var entry in rolodex.Channels)
                {
                    STSI.Logger($"{entry.Key}:{entry.Value.name}", "");
                }
            }
        }

        private static string CommandBuilder(string command)
        {
            string[] command_split = command.Split(new[] { '=', ',' });
            if (command_split.Length == 3)
            {
                return HandleCommand(command_split[0], command_split[1], int.Parse(command_split[2]));
            }
            return "NAK";
        }

        private static string HandleCommand(string command_type, string key, int channel)
        {
            if (command_type.Equals("CMD") && rolodex.CMD_Rolodex.TryGetValue(key, out var action))
            {
                rolodex.ChannelMapper_CMD(channel, action);
                return "ACK";
            }

            if (command_type.Equals("RBOOL") && rolodex.RET_Rolodex.TryGetValue(key, out var bool_action))
            {
                rolodex.ChannelMapper_RET(channel, bool_action, typeof(bool));
                return "ACK";
            }

            if (command_type.Equals("RINT") && rolodex.RET_Rolodex.TryGetValue(key, out var int_action))
            {
                rolodex.ChannelMapper_RET(channel, int_action, typeof(int));
                return "ACK";
            }

            if (command_type.Equals("RFLT") && rolodex.RET_Rolodex.TryGetValue(key, out var float_action))
            {
                rolodex.ChannelMapper_RET(channel, float_action, typeof(float));
                return "ACK";
            }

            return "NAK";
        }

        private static string CommandExecuter(string command)
        {
            string[] command_split = command.Split('=');
            if (command_split.Length == 2 && int.TryParse(command_split[1], out int channel) && rolodex.Channels.TryGetValue(channel, out var channel_info)){
                try
                {
                    object result = channel_info.action();
                    return result.ToString() ?? "NAK";
                }
                catch { return "NAK";  }
            }
            return "NAK";
        }

        private static Parity ParseParity(string parity) =>
            Enum.TryParse(parity, true, out Parity parsed_parity) ? parsed_parity : Parity.None;

        private static StopBits ParseStopBits(string stop_bits) =>
            Enum.TryParse(stop_bits, true, out StopBits parsed_parity) ? parsed_parity : StopBits.None;

        private static Handshake ParseHandshake(string handshake) =>
            Enum.TryParse(handshake, true, out Handshake parsed_handshake) ? parsed_handshake : Handshake.None;
    }
}
