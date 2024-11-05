using MelonLoader;
using ST_Serial_Interface;
using System.IO.Ports;
using System.Text.Json;
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

        // Update information
        private const string current_version = "v1.1.0";
        private const string repo_owner = "mookeyj79";
        private const string repo_name = "Star-Trucker-Serial-Interface";

        public static string connection_message = "";
        private static string update_message = "";

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

            // Check for updates
            CheckForUpdates();

            // Display available ports
            string[] portNames = SerialPort.GetPortNames();
            LoggerInstance.Msg($"Number of ports found: {portNames.Length}");
            foreach (string portName in portNames)
            {
                LoggerInstance.Msg($"Port: {portName}");
            }

            // Setup the serial port
            Serial.Setup(
                serial_port.Value,
                serial_baud_rate.Value,
                serial_parity.Value,
                serial_data_bits.Value,
                serial_stop_bits.Value,
                serial_handshake.Value,
                serial_timeout.Value
            );

            // Start the serial connection
            Serial.Start();

            // Log the initialize message
            LoggerInstance.Msg($"{connection_message}");
            MelonEvents.OnGUI.Subscribe(DrawInit, 100);
        }

        private async void CheckForUpdates()
        {
            string? latest_version = await GetLastestVersion();
            if (latest_version != null && latest_version != current_version)
            {
                update_message = $"A new version ({latest_version}) is available!";
                LoggerInstance.Warning(update_message);
            }
        }

        private static async Task<string?> GetLastestVersion()
        {
            try
            {
                using HttpClient client = new();
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; AcmeInc/1.0)");
                string url = $"https://api.github.com/repos/{repo_owner}/{repo_name}/releases/latest";
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json_response = await response.Content.ReadAsStringAsync();
                    using JsonDocument json_doc = JsonDocument.Parse(json_response);
                    JsonElement root = json_doc.RootElement;

                    if (root.TryGetProperty("tag_name", out JsonElement tag_element))
                    {
                        return tag_element.GetString();
                    }
                }
            }
            catch (Exception ex)
            {
                update_message = $"Error checking for updates: {ex.Message}";
            }
            return null;
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
            Serial.Stop();
        }

        private void DrawInit()
        {
            // Draw the initialize message on the screen
            if (Time.realtimeSinceStartup < messageOnScreenSecs)
            {
                float box_width = 250;
                float box_height = 50;
                Rect box_rect = new(Screen.width - box_width - 10, 5, box_width, box_height);
                
                GUIStyle style1 = new(GUI.skin.label)
                {
                    alignment = TextAnchor.MiddleRight
                };
                style1.normal.background = null;
                style1.normal.textColor = Color.yellow;
                style1.fontStyle = FontStyle.Bold;

                GUIStyle style2 = new(GUI.skin.label)
                {
                    alignment = TextAnchor.MiddleRight
                };
                style2.normal.background = null;
                style2.normal.textColor = Color.green;
                style2.fontStyle = FontStyle.Bold;

                GUI.Box(box_rect, GUIContent.none);
                GUILayout.BeginArea(box_rect);
                GUILayout.Label(connection_message, style1);
                GUILayout.Label(update_message, style2);
                GUILayout.EndArea();
            }
        }

        public static void Logger(string msg, string mod_name="[\u001b[36mST_Serial_Interface\u001b[0m] ")
        {
            MelonLogger.Msg($"{mod_name}{msg}");
        }
    }
}
