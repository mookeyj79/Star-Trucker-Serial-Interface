using Il2Cpp;
using UnityEngine;

namespace ST_Serial_Interface
{
    internal class Interactor
    {
        private ToggleSwitch? headlights_obj;
        private ToggleSwitch? auxlights_obj;
        private ToggleSwitch? rooflights_obj;
        private ToggleSwitch? frontlights_obj;
        private ToggleSwitch? lowerlights_obj;
        private ToggleSwitch? upperlights_obj;
        private InteractTarget? horn_obj;
        private InteractTarget? shutters_obj;

        public string ToggleHeadLightsOn()
        {
            // Verify that 'headlights_obj' exists, create if not
            if (headlights_obj == null)
            {
                try { headlights_obj = GameObject.Find("StarTruck_SwitchToggle1_HeadLights").GetComponent<ToggleSwitch>(); }
                catch { return "DEN"; }
            }

            // Toggle headlights on
            headlights_obj.ToggleOn();

            // Return acknowledgement
            return "ACK";
        }

        public string ToggleHeadLightsOff()
        {
            // Verify that 'headlights_obj' exists, create if not
            if (headlights_obj == null)
            {
                try { headlights_obj = GameObject.Find("StarTruck_SwitchToggle1_HeadLights").GetComponent<ToggleSwitch>(); }
                catch { return "DEN"; }
            }

            // Toggle headlights off
            headlights_obj.ToggleOff();

            // Return acknowledgement
            return "ACK";
        }

        public string ToggleAuxLightsOn()
        {
            // Verify that 'auxlights_obj' exists, create if not
            if (auxlights_obj == null)
            {
                try { auxlights_obj = GameObject.Find("StarTruck_SwitchToggle2_AuxLights").GetComponent<ToggleSwitch>(); }
                catch { return "DEN"; }
            }

            // Toggle auxlights on
            auxlights_obj.ToggleOn();

            // Return acknowledgement
            return "ACK";
        }

        public string ToggleAuxLightsOff()
        {
            // Verify that 'auxlights_obj' exists, create if not
            if (auxlights_obj == null)
            {
                try { auxlights_obj = GameObject.Find("StarTruck_SwitchToggle2_AuxLights").GetComponent<ToggleSwitch>(); }
                catch { return "DEN"; }
            }

            // Toggle auxlights off
            auxlights_obj.ToggleOff();

            // Return acknowledgement
            return "ACK";
        }

        public string ToggleRoofLightsOn()
        {
            // Verify that 'rooflights_obj' exists, create if not
            if (rooflights_obj == null)
            {
                try { rooflights_obj = GameObject.Find("StarTruck_SwitchToggle3_RoofLights").GetComponent<ToggleSwitch>(); }
                catch { return "DEN"; }
            }

            // Toggle rooflights on
            rooflights_obj.ToggleOn();

            // Return acknowledgement
            return "ACK";
        }

        public string ToggleRoofLightsOff()
        {
            // Verify that 'rooflights_obj' exists, create if not
            if (rooflights_obj == null)
            {
                try { rooflights_obj = GameObject.Find("StarTruck_SwitchToggle3_RoofLights").GetComponent<ToggleSwitch>(); }
                catch { return "DEN"; }
            }

            // Toggle rooflights off
            rooflights_obj.ToggleOff();

            // Return acknowledgement
            return "ACK";
        }

        public string ToggleFrontLightsOn()
        {
            // Verify that 'frontlights_obj' exists, create if not
            if (frontlights_obj == null)
            {
                try { frontlights_obj = GameObject.Find("StarTruck_SwitchToggle4_FrontLights").GetComponent<ToggleSwitch>(); }
                catch { return "DEN"; }
            }

            // Toggle frontlights on
            frontlights_obj.ToggleOn();

            // Return acknowledgement
            return "ACK";
        }

        public string ToggleFrontLightsOff()
        {
            // Verify that 'frontlights_obj' exists, create if not
            if (frontlights_obj == null)
            {
                try { frontlights_obj = GameObject.Find("StarTruck_SwitchToggle4_FrontLights").GetComponent<ToggleSwitch>(); }
                catch { return "DEN"; }
            }

            // Toggle frontlights off
            frontlights_obj.ToggleOff();

            // Return acknowledgement
            return "ACK";
        }

        public string ToggleLowerLightsOn()
        {
            // Verify that 'lowerlights_obj' exists, create if not
            if (lowerlights_obj == null)
            {
                try { lowerlights_obj = GameObject.Find("StarTruck_SwitchToggle5_LowerLights").GetComponent<ToggleSwitch>(); }
                catch { return "DEN"; }
            }

            // Toggle lowerlights on
            lowerlights_obj.ToggleOn();

            // Return acknowledgement
            return "ACK";
        }

        public string ToggleLowerLightsOff()
        {
            // Verify that 'lowerlights_obj' exists, create if not
            if (lowerlights_obj == null)
            {
                try { lowerlights_obj = GameObject.Find("StarTruck_SwitchToggle5_LowerLights").GetComponent<ToggleSwitch>(); }
                catch { return "DEN"; }
            }

            // Toggle lowerlights off
            lowerlights_obj.ToggleOff();

            // Return acknowledgement
            return "ACK";
        }

        public string ToggleUpperLightsOn()
        {
            // Verify that 'upperlights_obj' exists, create if not
            if (upperlights_obj == null)
            {
                try { upperlights_obj = GameObject.Find("StarTruck_SwitchToggle6_UpperLights").GetComponent<ToggleSwitch>(); }
                catch { return "DEN"; }
            }

            // Toggle upperlights on
            upperlights_obj.ToggleOn();

            // Return acknowledgement
            return "ACK";
        }

        public string ToggleUpperLightsOff()
        {
            // Verify that 'upperlights_obj' exists, create if not
            if (upperlights_obj == null)
            {
                try { upperlights_obj = GameObject.Find("StarTruck_SwitchToggle6_UpperLights").GetComponent<ToggleSwitch>(); }
                catch { return "DEN"; }
            }

            // Toggle upperlights off
            upperlights_obj.ToggleOff();

            // Return acknowledgement
            return "ACK";
        }

        public string ToggleHornOn()
        {
            // Verify that 'horn_obj' exists, create if not
            if (horn_obj == null)
            {
                try { horn_obj = GameObject.Find("StarTruck_Dashboard_Top_Lever_Scanner").GetComponent<InteractTarget>(); }
                catch { return "DEN"; }
            }

            // Toggle horn on
            horn_obj.OnPrimaryInteract(true);

            // Return acknowledgement
            return "ACK";
        }

        public string ToggleHornOff()
        {
            // Verify that 'horn_obj' exists, create if not
            if (horn_obj == null)
            {
                try { horn_obj = GameObject.Find("StarTruck_Dashboard_Top_Lever_Scanner").GetComponent<InteractTarget>(); }
                catch { return "DEN"; }
            }

            // Toggle horn off
            horn_obj.OnPrimaryInteract(false);

            // Return acknowledgement
            return "ACK";
        }

        public string ToggleShutters()
        {
            // Verify that 'shutters_obj' exists, create if not
            if (shutters_obj == null)
            {
                try { shutters_obj = GameObject.Find("StarTruck_Dashboard_Top_Lever_Shutter").GetComponent<InteractTarget>(); }
                catch { return "DEN"; }
            }

            // Toggle shutters
            shutters_obj.OnPrimaryInteract(true);

            // Return acknowledgement
            return "ACK";
        }
    }
}
