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
        private ToggleSwitch? circuit_gravity_obj;
        private ToggleSwitch? circuit_shield_obj;
        private ToggleSwitch? circuit_temp_obj;
        private ToggleSwitch? circuit_oxygen_obj;
        private ToggleSwitch? circuit_maglock_obj;
        private ToggleSwitch? circuit_core_obj;
        private ToggleSwitch? circuit_suit_obj;
        private InteractTarget? horn_obj;
        private InteractTarget? shutters_obj;
        private CruiseControlSwitch? cruise_control_obj;

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

        public string ToggleCircuitBreakerGravityOn()
        {
            // Verify that 'circuit_gravity_obj' exists, create if not
            if (circuit_gravity_obj == null)
            {
                try { circuit_gravity_obj = GameObject.Find("StarTruck_Circuit_Panel [Gravity]").GetComponent<ToggleSwitch>(); }
                catch { return "DEN"; }
            }

            // Toggle gravity cicuit breaker on
            circuit_gravity_obj.ToggleOn();

            // Return acknowledgement
            return "ACK";
        }

        public string ToggleCircuitBreakerGravityOff()
        {
            // Verify that 'circuit_gravity_obj' exists, create if not
            if (circuit_gravity_obj == null)
            {
                try { circuit_gravity_obj = GameObject.Find("StarTruck_Circuit_Panel [Gravity]").GetComponent<ToggleSwitch>(); }
                catch { return "DEN"; }
            }

            // Toggle gravity circuit breaker off
            circuit_gravity_obj.ToggleOff();

            // Return acknowledgement
            return "ACK";
        }

        public string ToggleCircuitBreakerShieldOn()
        {
            // Verify that 'circuit_shield_obj' exists, create if not
            if (circuit_shield_obj == null)
            {
                try { circuit_shield_obj = GameObject.Find("StarTruck_Circuit_Panel [Shield]").GetComponent<ToggleSwitch>(); }
                catch { return "DEN"; }
            }

            // Toggle shield circuit breaker on
            circuit_shield_obj.ToggleOn();

            // Return acknowledgement
            return "ACK";
        }

        public string ToggleCircuitBreakerShieldOff()
        {
            // Verify that 'circuit_shield_obj' exists, create if not
            if (circuit_shield_obj == null)
            {
                try { circuit_shield_obj = GameObject.Find("StarTruck_Circuit_Panel [Shield]").GetComponent<ToggleSwitch>(); }
                catch { return "DEN"; }
            }

            // Toggle shield circuit breaker off
            circuit_shield_obj.ToggleOff();

            // Return acknowledgement
            return "ACK";
        }

        public string ToggleCircuitBreakerTempOn()
        {
            // Verify that 'circuit_temp_obj' exists, create if not
            if (circuit_temp_obj == null)
            {
                try { circuit_temp_obj = GameObject.Find("StarTruck_Circuit_Panel [Temp]").GetComponent<ToggleSwitch>(); }
                catch { return "DEN"; }
            }

            // Toggle temp circuit breaker on
            circuit_temp_obj.ToggleOn();

            // Return acknowledgement
            return "ACK";
        }

        public string ToggleCircuitBreakerTempOff()
        {
            // Verify that 'circuit_temp_obj' exists, create if not
            if (circuit_temp_obj == null)
            {
                try { circuit_temp_obj = GameObject.Find("StarTruck_Circuit_Panel [Temp]").GetComponent<ToggleSwitch>(); }
                catch { return "DEN"; }
            }

            // Toggle temp circuit breaker off
            circuit_temp_obj.ToggleOff();

            // Return acknowledgement
            return "ACK";
        }

        public string ToggleCircuitBreakerOxygenOn()
        {
            // Verify that 'circuit_temp_obj' exists, create if not
            if (circuit_oxygen_obj == null)
            {
                try { circuit_oxygen_obj = GameObject.Find("StarTruck_Circuit_Panel [Oxygen]").GetComponent<ToggleSwitch>(); }
                catch { return "DEN"; }
            }

            // Toggle oxygen circuit breaker on
            circuit_oxygen_obj.ToggleOn();

            // Return acknowledgement
            return "ACK";
        }

        public string ToggleCircuitBreakerOxygenOff()
        {
            // Verify that 'circuit_temp_obj' exists, create if not
            if (circuit_oxygen_obj == null)
            {
                try { circuit_oxygen_obj = GameObject.Find("StarTruck_Circuit_Panel [Oxygen]").GetComponent<ToggleSwitch>(); }
                catch { return "DEN"; }
            }

            // Toggle oxygen circuit breaker off
            circuit_oxygen_obj.ToggleOff();

            // Return acknowledgement
            return "ACK";
        }

        public string ToggleCircuitBreakerMaglockOn()
        {
            // Verify that 'circuit_maglock_obj' exists, create if not
            if (circuit_maglock_obj == null)
            {
                try { circuit_maglock_obj = GameObject.Find("StarTruck_Circuit_Panel  [Maglock]").GetComponent<ToggleSwitch>(); }
                catch { return "DEN"; }
            }

            // Toggle maglock circuit breaker on
            circuit_maglock_obj.ToggleOn();

            // Return acknowledgement
            return "ACK";
        }

        public string ToggleCircuitBreakerMaglockOff()
        {
            // Verify that 'circuit_maglock_obj' exists, create if not
            if (circuit_maglock_obj == null)
            {
                try { circuit_maglock_obj = GameObject.Find("StarTruck_Circuit_Panel  [Maglock]").GetComponent<ToggleSwitch>(); }
                catch { return "DEN"; }
            }

            // Toggle maglock circuit breaker off
            circuit_maglock_obj.ToggleOff();

            // Return acknowledgement
            return "ACK";
        }

        public string ToggleCircuitBreakerCoreOn()
        {
            // Verify that 'circuit_core_obj' exists, create if not
            if (circuit_core_obj == null)
            {
                try { circuit_core_obj = GameObject.Find("StarTruck_Circuit_Panel [Core]").GetComponent<ToggleSwitch>(); }
                catch { return "DEN"; }
            }

            // Toggle core circuit breaker on
            circuit_core_obj.ToggleOn();

            // Return acknowledgement
            return "ACK";
        }

        public string ToggleCircuitBreakerCoreOff()
        {
            // Verify that 'circuit_core_obj' exists, create if not
            if (circuit_core_obj == null)
            {
                try { circuit_core_obj = GameObject.Find("StarTruck_Circuit_Panel [Core]").GetComponent<ToggleSwitch>(); }
                catch { return "DEN"; }
            }

            // Toggle core circuit breaker off
            circuit_core_obj.ToggleOff();

            // Return acknowledgement
            return "ACK";
        }

        public string ToggleCircuitBreakerSuitOn()
        {
            // Verify that 'circuit_suit_obj' exists, create if not
            if (circuit_suit_obj == null)
            {
                try { circuit_suit_obj = GameObject.Find("StarTruck_Circuit_Panel [Suit]").GetComponent<ToggleSwitch>(); }
                catch { return "DEN"; }
            }

            // Toggle suit circuit breaker on
            circuit_suit_obj.ToggleOn();

            // Return acknowledgement
            return "ACK";
        }

        public string ToggleCircuitBreakerSuitOff()
        {
            // Verify that 'circuit_suit_obj' exists, create if not
            if (circuit_suit_obj == null)
            {
                try { circuit_suit_obj = GameObject.Find("StarTruck_Circuit_Panel [Suit]").GetComponent<ToggleSwitch>(); }
                catch { return "DEN"; }
            }

            // Toggle suit circuit breaker off
            circuit_suit_obj.ToggleOff();

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

        public string ToggleCruiseControl()
        {
            // Verify that 'cruise_control_obj' exists, create if not
            if (cruise_control_obj == null)
            {
                try { cruise_control_obj = GameObject.Find("StarTruck_Switch_Pole [Cruise Control Enable]").GetComponent<CruiseControlSwitch>(); }
                catch { return "DEN"; }
            }

            // Toggle shutters
            cruise_control_obj.OnInteract();

            // Return acknowledgement
            return "ACK";
        }

        public string IncreaseCruiseControl()
        {
            // Verify that 'cruise_control_obj' exists, create if not
            if (cruise_control_obj == null)
            {
                try { cruise_control_obj = GameObject.Find("StarTruck_Switch_Pole [Cruise Control Enable]").GetComponent<CruiseControlSwitch>(); }
                catch { return "DEN"; }
            }

            // Toggle shutters
            cruise_control_obj.OnIncreaseSpeedButtonPress();

            // Return acknowledgement
            return "ACK";
        }

        public string DecreaseCruiseControl()
        {
            // Verify that 'cruise_control_obj' exists, create if not
            if (cruise_control_obj == null)
            {
                try { cruise_control_obj = GameObject.Find("StarTruck_Switch_Pole [Cruise Control Enable]").GetComponent<CruiseControlSwitch>(); }
                catch { return "DEN"; }
            }

            // Toggle shutters
            cruise_control_obj.OnDecreaseSpeedButtonPress();

            // Return acknowledgement
            return "ACK";
        }
    }
}
