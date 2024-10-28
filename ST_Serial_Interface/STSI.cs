using MelonLoader;
using ST_Serial_Interface;
using System.IO.Ports;
using UnityEngine;

// Assembly information
[assembly: MelonInfo(typeof(STSI), "ST_Serial_Interface", "1.0.0", "MookeyJ")]
[assembly: MelonGame("Monster And Monster", "Star Trucker")]

namespace ST_Serial_Interface
{
    public class STSI : MelonMod
    {
        // How long to display startup message on the screen
        private readonly static int messageOnScreenSecs = 10;

        // Create new objects
        private readonly Serial serial = new();

        // App state checker for the logger
        private static int phase_old = Serial.phase;

        // Verbose logic
        public static bool verbose = false;

        // Melon Preferences options
        private MelonPreferences_Category? serial_category;
        private MelonPreferences_Entry<string>? serial_port;
        private MelonPreferences_Entry<int>? serial_baud_rate;
        private MelonPreferences_Entry<string>? serial_parity;
        private MelonPreferences_Entry<int>? serial_data_bits;
        private MelonPreferences_Entry<string>? serial_stop_bits;
        private MelonPreferences_Entry<string>? serial_handshake;
        private MelonPreferences_Entry<int>? serial_timeout;
        private MelonPreferences_Entry<bool>? serial_verbose;

        public override void OnLateInitializeMelon()
        {
            base.OnLateInitializeMelon();

            // Setup Melon preferences
            serial_category = MelonPreferences.CreateCategory("ST Serial Interface");
            serial_port = serial_category.CreateEntry<string>("Port", "COM4");
            serial_baud_rate = serial_category.CreateEntry<int>("Baud_Rate", 9600);
            serial_parity = serial_category.CreateEntry<string>("Parity", "None");
            serial_data_bits = serial_category.CreateEntry<int>("Data_Bits", 8);
            serial_stop_bits = serial_category.CreateEntry<string>("Stop_Bits", "One");
            serial_handshake = serial_category.CreateEntry<string>("Handshake", "None");
            serial_timeout = serial_category.CreateEntry<int>("Timeout", 5000);
            serial_verbose = serial_category.CreateEntry<bool>("Verbose", false);

            // Set verbosity
            verbose = serial_verbose.Value;

            // Display available ports
            string[] portNames = SerialPort.GetPortNames();
            LoggerInstance.Msg($"Number of ports found: {portNames.Length}");
            foreach (string portName in portNames)
            {
                LoggerInstance.Msg($"Port: {portName}");
            }

            // Setup the serial port
            serial.Setup(
                serial_port.Value,
                serial_baud_rate.Value,
                serial_parity.Value,
                serial_data_bits.Value,
                serial_stop_bits.Value,
                serial_handshake.Value,
                serial_timeout.Value
            );

            // Start the serial connection
            serial.Start();

            // Log the initialize message
            LoggerInstance.Msg($"ST Serial Interface started on {serial_port.Value}");
            MelonEvents.OnGUI.Subscribe(DrawInit, 100);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            // Logging for the app phase
            if (Serial.phase != phase_old)
            {
                if (Serial.phase == 0) { LoggerInstance.Msg("App State: Initialize"); }
                else if (Serial.phase == 1) { LoggerInstance.Msg("App State: Synchronization"); }
                else if (Serial.phase == 2) { LoggerInstance.Msg("App State: Activate"); }
                phase_old = Serial.phase;
            }
        }


        public override void OnDeinitializeMelon()
        {
            base.OnDeinitializeMelon();
            serial.Stop();
        }

        private void DrawInit()
        {
            // Draw the initialize message on the screen
            if (Time.realtimeSinceStartup < messageOnScreenSecs && serial_port != null)
            {
                GUIStyle style = new GUIStyle();
                style.alignment = TextAnchor.UpperLeft;
                style.normal.textColor = Color.yellow;
                style.fontStyle = FontStyle.Bold;
                GUI.Box(new Rect(Screen.width - 235, 5, 600, 600), $"ST Serial Interface started on {serial_port.Value}", style);
            }
        }

        public static void Logger(string msg, string mod_name="[\u001b[36mST_Serial_Interface\u001b[0m] ")
        {
            MelonLogger.Msg($"{mod_name}{msg}");
        }
    }
}
