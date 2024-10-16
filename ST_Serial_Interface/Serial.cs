using System.IO.Ports;

namespace ST_Serial_Interface
{
    internal class Serial
    {
        // Determines if the serial loop should keep running
        private static bool mod_active = false;

        // Current app phase
        // 0 - Initialize; 1 -Synchronization; 2 - Activate
        public static int phase = 0;

        // Message received via serial
        public static string message = "";

        // Thread running the serial read function
        private readonly Thread read_thread = new(ReadData);

        // Builtin string comparer
        private static StringComparer string_comparer = StringComparer.OrdinalIgnoreCase;

        // Serial port declaration
        private static SerialPort? serial_port;

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
        }

        public void Start()
        {
            if (serial_port == null)
            {
                return;
            }
            serial_port.Open();
            mod_active = true;
            read_thread.Start();
        }

        public void Stop()
        {
            if (serial_port == null)
            {
                return;
            }
            mod_active = false;
            read_thread.Join();
            serial_port.Close();
        }

        private static void ReadData()
        {
            string resp;
            while (mod_active && serial_port != null)
            {
                try
                {
                    message = serial_port.ReadLine().Trim().ToUpper();
                    if (string_comparer.Equals(message, "SYN") && phase == 0)
                    {
                        phase = 1;
                        resp = "ACK";
                    }
                    else if (string_comparer.Equals(message, "ACT") && phase == 1)
                    {
                        phase = 2;
                        resp = "ACK";
                    }
                    else if (phase == 1 && (message.StartsWith("CMD") || message.StartsWith("RBOOL") || message.StartsWith("RINT") || message.StartsWith("RFLT")))
                    {
                        resp = CommandBuilder(message);
                    }
                    else if (phase == 2 && message.StartsWith("EXC")){
                        resp = CommandExecuter(message);
                    }
                    else if (message.StartsWith("RST"))
                    {
                        phase = 0;
                        rolodex.Channels.Clear();
                        resp = "ACK";
                    }
                    else
                    {
                        resp = "DEN";
                    }
                    serial_port.WriteLine(resp);
                }
                catch (TimeoutException) { }
            }
        }

        private static string CommandBuilder(string command)
        {
            string[] command_split = command.Split(new Char[] {'=', ','});
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
                if (rolodex.Channels.ContainsKey(channel)){
                    string resp = $"{rolodex.Channels[channel]()}";
                    return resp;
                }
            }
            return "DEN";
        }
    }
}
