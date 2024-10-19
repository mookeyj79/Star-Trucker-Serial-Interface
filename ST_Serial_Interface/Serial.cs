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
        private static StringComparer string_comparer = StringComparer.OrdinalIgnoreCase;

        // Rolodex declaration
        private static readonly Rolodex rolodex = new();

        public void Setup(string port, int baud_rate, string parity, int data_bits, string stop_bits, string handshake)
        {
            // Sets up the serial connection

            // Serial settings
            Dictionary<string, Parity> parity_dict = new();
            Dictionary<string, StopBits> stop_bits_dict = new();
            Dictionary<string, Handshake> handshake_dict = new();

            parity_dict["none"] = Parity.None;
            parity_dict["odd"] = Parity.Odd;
            parity_dict["even"] = Parity.Even;
            parity_dict["mark"] = Parity.Mark;
            parity_dict["space"] = Parity.Space;

            stop_bits_dict["none"] = StopBits.None;
            stop_bits_dict["one"] = StopBits.One;
            stop_bits_dict["two"] = StopBits.Two;
            stop_bits_dict["onepointfive"] = StopBits.OnePointFive;

            handshake_dict["none"] = Handshake.None;
            handshake_dict["xonxoff"] = Handshake.XOnXOff;
            handshake_dict["requesttosend"] = Handshake.RequestToSend;
            handshake_dict["requesttosendxonxoff"] = Handshake.RequestToSendXOnXOff;

            // Map rolodex functions to dictionaries
            rolodex.FunctionMapper();

            // Set up serial port
            serial_port = new SerialPort()
            {
                PortName = port,
                BaudRate = baud_rate,
                Parity = parity_dict[parity.ToLower()],
                DataBits = 8,
                StopBits = stop_bits_dict[stop_bits.ToLower()],
                Handshake = handshake_dict[handshake.ToLower()],
                WriteTimeout = 500,
                ReadTimeout = 500,
            };

            serial_port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }

        public void Start()
        {
            if (serial_port == null)
            {
                return;
            }
            serial_port.Open();
        }

        public void Stop()
        {
            if (serial_port == null)
            {
                return;
            }
            serial_port.Close();
        }

        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(HandleData, sender);
        }

        private static void HandleData(object? state)
        {
            if (state != null)
            {
                SerialPort sp = (SerialPort)state;

                try
                {
                    if (sp.BytesToRead > 0)
                    {
                        byte[] buffer = new byte[sp.BytesToRead];
                        sp.Read(buffer, 0, buffer.Length);

                        if (BinaryTools.IsBinaryData(buffer))
                        {
                            // Neither UTF-8 or ASCII characters
                            string resp = "DEN";
                            byte[] responseData = Encoding.UTF8.GetBytes(resp);
                            sp.Write(responseData, 0, responseData.Length);
                        }
                        else
                        {
                            string recievedText = Encoding.UTF8.GetString(buffer);
                            string responseText = ProcessData(recievedText);
                            byte[] responseTextBytes = Encoding.UTF8.GetBytes(responseText);
                            sp.Write(responseTextBytes, 0, responseTextBytes.Length);
                        }
                    }
                }
                catch (TimeoutException) { }
            }
        }
        

        private static string ProcessData(string message)
        {
            string resp;
            message = message.Trim().ToUpper();

            if (string_comparer.Equals(message, "SYN") && phase == 0)
            {
                phase = 1;
                resp = "ACK";
            }

            else if (string_comparer.Equals(message, "ACT") && phase == 1)
            {
                phase = 2;
                resp = "ACK";
                if (STSI.verbose)
                {
                    STSI.Logger($"Registered Functions: {rolodex.Channels.Count}", "");
                    foreach (KeyValuePair<int, (Func<object> action, string name)> entry in rolodex.Channels)
                    {
                        STSI.Logger($"{entry.Key}: {entry.Value.name}", "");
                    }
                }
            }

            else if (phase == 1 && (message.StartsWith("CMD") || message.StartsWith("RBOOL") || message.StartsWith("RINT") || message.StartsWith("RFLT")))
            {
                resp = CommandBuilder(message);
            }

            else if (phase == 2 && message.StartsWith("EXC"))
            {
                resp = CommandExecuter(message);
            }

            else if (message.StartsWith("RST"))
            {
                phase = 0;
                rolodex.Channels.Clear();
                resp = "ACK";
            }

            else if (message.StartsWith("DBG="))
            {
                message = message.Split(new[] {'='}, 2)[1];  // Split on first occurance of '='
                STSI.Logger(message, "");
                resp = "ACK";
            }

            else
            {
                resp = "DEN";
            }

            return resp;
        }

        private static string CommandBuilder(string command)
        {
            string[] command_split = command.Split(new Char[] { '=', ',' });
            if (command_split.Length == 3)
            {
                if (command.StartsWith("CMD"))
                {
                    if (rolodex.CMD_Rolodex.ContainsKey(command_split[1]))
                    {
                        rolodex.ChannelMapper_CMD(Int32.Parse(command_split[2]), rolodex.CMD_Rolodex[command_split[1]]);
                        return "ACK";
                    }
                }
                else if (command.StartsWith("RBOOL"))
                {
                    if (rolodex.RET_Rolodex.ContainsKey(command_split[1]))
                    {
                        rolodex.ChannelMapper_RET(Int32.Parse(command_split[2]), rolodex.RET_Rolodex[command_split[1]], typeof(bool));
                        return "ACK";
                    }
                }
                else if (command.StartsWith("RINT"))
                {
                    if (rolodex.RET_Rolodex.ContainsKey(command_split[1]))
                    {
                        rolodex.ChannelMapper_RET(Int32.Parse(command_split[2]), rolodex.RET_Rolodex[command_split[1]], typeof(int));
                        return "ACK";
                    }
                }
                else if (command.StartsWith("RFLT"))
                {
                    if (rolodex.RET_Rolodex.ContainsKey(command_split[1]))
                    {
                        rolodex.ChannelMapper_RET(Int32.Parse(command_split[2]), rolodex.RET_Rolodex[command_split[1]], typeof(float));
                        return "ACK";
                    }
                }
            }
            return "DEN";
        }

        private static string CommandExecuter(string command)
        {
            string[] command_split = command.Split(new Char[] { '=' });
            if (command_split.Length == 2)
            {
                int channel = Int32.Parse(command_split[1]);
                if (rolodex.Channels.TryGetValue(channel, out var channelInfo))
                {
                    Func<object> action = channelInfo.action;
                    string name = channelInfo.name;

                    try
                    {
                        object result = action();
                        return $"{result}";
                    }
                    catch { return "DEN"; }

                }
            }
            return "DEN";
        }
    }
}
