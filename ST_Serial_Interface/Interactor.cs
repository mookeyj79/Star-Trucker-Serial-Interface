using Il2Cpp;

namespace ST_Serial_Interface
{
    internal class Interactor
    {

        public static string ToggleHeadLightsOn()
        {
            ObjectManager.headlights_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.headlights_obj, "StarTruck_SwitchToggle1_HeadLights");
            if (ObjectManager.headlights_obj == null) { return "DEN"; }
            ObjectManager.headlights_obj.ToggleOn();
            return "ACK";
        }

        public static string ToggleHeadLightsOff()
        {
            ObjectManager.headlights_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.headlights_obj, "StarTruck_SwitchToggle1_HeadLights");
            if (ObjectManager.headlights_obj == null) { return "DEN"; }
            ObjectManager.headlights_obj.ToggleOff();
            return "ACK";
        }

        public static string ToggleAuxLightsOn()
        {
            ObjectManager.auxlights_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.auxlights_obj, "StarTruck_SwitchToggle2_AuxLights");
            if (ObjectManager.auxlights_obj == null) { return "DEN"; }
            ObjectManager.auxlights_obj.ToggleOn();
            return "ACK";
        }

        public static string ToggleAuxLightsOff()
        {
            ObjectManager.auxlights_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.auxlights_obj, "StarTruck_SwitchToggle2_AuxLights");
            if (ObjectManager.auxlights_obj == null) { return "DEN"; }
            ObjectManager.auxlights_obj.ToggleOff();
            return "ACK";
        }

        public static string ToggleRoofLightsOn()
        {
            ObjectManager.auxlights_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.rooflights_obj, "StarTruck_SwitchToggle3_RoofLights");
            if (ObjectManager.rooflights_obj == null) { return "DEN"; }
            ObjectManager.rooflights_obj.ToggleOn();
            return "ACK";
        }

        public static string ToggleRoofLightsOff()
        {
            ObjectManager.auxlights_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.rooflights_obj, "StarTruck_SwitchToggle3_RoofLights");
            if (ObjectManager.rooflights_obj == null) { return "DEN"; }
            ObjectManager.rooflights_obj.ToggleOff();
            return "ACK";
        }

        public static string ToggleFrontLightsOn()
        {
            ObjectManager.frontlights_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.frontlights_obj, "StarTruck_SwitchToggle4_FrontLights");
            if (ObjectManager.frontlights_obj == null) { return "DEN"; }
            ObjectManager.frontlights_obj.ToggleOn();
            return "ACK";
        }

        public static string ToggleFrontLightsOff()
        {
            ObjectManager.frontlights_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.frontlights_obj, "StarTruck_SwitchToggle4_FrontLights");
            if (ObjectManager.frontlights_obj == null) { return "DEN"; }
            ObjectManager.frontlights_obj.ToggleOff();
            return "ACK";
        }

        public static string ToggleLowerLightsOn()
        {
            ObjectManager.lowerlights_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.lowerlights_obj, "StarTruck_SwitchToggle5_LowerLights");
            if (ObjectManager.lowerlights_obj == null) { return "DEN"; }
            ObjectManager.lowerlights_obj.ToggleOn();
            return "ACK";
        }

        public static string ToggleLowerLightsOff()
        {
            ObjectManager.lowerlights_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.lowerlights_obj, "StarTruck_SwitchToggle5_LowerLights");
            if (ObjectManager.lowerlights_obj == null) { return "DEN"; }
            ObjectManager.lowerlights_obj.ToggleOff();
            return "ACK";
        }

        public static string ToggleUpperLightsOn()
        {
            ObjectManager.upperlights_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.upperlights_obj, "StarTruck_SwitchToggle6_UpperLights");
            if (ObjectManager.upperlights_obj == null) { return "DEN"; }
            ObjectManager.upperlights_obj.ToggleOn();
            return "ACK";
        }

        public static string ToggleUpperLightsOff()
        {
            ObjectManager.upperlights_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.upperlights_obj, "StarTruck_SwitchToggle6_UpperLights");
            if (ObjectManager.upperlights_obj == null) { return "DEN"; }
            ObjectManager.upperlights_obj.ToggleOff();
            return "ACK";
        }

        public static string ToggleCircuitBreakerGravityOn()
        {
            ObjectManager.circuit_gravity_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.circuit_gravity_obj, "StarTruck_Circuit_Panel [Gravity]");
            if (ObjectManager.circuit_gravity_obj == null) { return "DEN"; }
            ObjectManager.circuit_gravity_obj.ToggleOn();
            return "ACK";
        }

        public static string ToggleCircuitBreakerGravityOff()
        {
            ObjectManager.circuit_gravity_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.circuit_gravity_obj, "StarTruck_Circuit_Panel [Gravity]");
            if (ObjectManager.circuit_gravity_obj == null) { return "DEN"; }
            ObjectManager.circuit_gravity_obj.ToggleOff();
            return "ACK";
        }

        public static string ToggleCircuitBreakerShieldOn()
        {
            ObjectManager.circuit_shield_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.circuit_shield_obj, "StarTruck_Circuit_Panel [Shield]");
            if (ObjectManager.circuit_shield_obj == null) { return "DEN"; }
            ObjectManager.circuit_shield_obj.ToggleOn();
            return "ACK";
        }

        public static string ToggleCircuitBreakerShieldOff()
        {
            ObjectManager.circuit_shield_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.circuit_shield_obj, "StarTruck_Circuit_Panel [Shield]");
            if (ObjectManager.circuit_shield_obj == null) { return "DEN"; }
            ObjectManager.circuit_shield_obj.ToggleOff();
            return "ACK";
        }

        public static string ToggleCircuitBreakerTempOn()
        {
            ObjectManager.circuit_temp_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.circuit_temp_obj, "StarTruck_Circuit_Panel [Temp]");
            if (ObjectManager.circuit_temp_obj == null) { return "DEN"; }
            ObjectManager.circuit_temp_obj.ToggleOn();
            return "ACK";
        }

        public static string ToggleCircuitBreakerTempOff()
        {
            ObjectManager.circuit_temp_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.circuit_temp_obj, "StarTruck_Circuit_Panel [Temp]");
            if (ObjectManager.circuit_temp_obj == null) { return "DEN"; }
            ObjectManager.circuit_temp_obj.ToggleOff();
            return "ACK";
        }

        public static string ToggleCircuitBreakerOxygenOn()
        {
            ObjectManager.circuit_oxygen_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.circuit_oxygen_obj, "StarTruck_Circuit_Panel [Oxygen]");
            if (ObjectManager.circuit_oxygen_obj == null) { return "DEN"; }
            ObjectManager.circuit_oxygen_obj.ToggleOn();
            return "ACK";
        }

        public static string ToggleCircuitBreakerOxygenOff()
        {
            ObjectManager.circuit_oxygen_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.circuit_oxygen_obj, "StarTruck_Circuit_Panel [Oxygen]");
            if (ObjectManager.circuit_oxygen_obj == null) { return "DEN"; }
            ObjectManager.circuit_oxygen_obj.ToggleOff();
            return "ACK";
        }

        public static string ToggleCircuitBreakerMaglockOn()
        {
            ObjectManager.circuit_maglock_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.circuit_maglock_obj, "StarTruck_Circuit_Panel  [Maglock]");
            if (ObjectManager.circuit_maglock_obj == null) { return "DEN"; }
            ObjectManager.circuit_maglock_obj.ToggleOn();
            return "ACK";
        }

        public static string ToggleCircuitBreakerMaglockOff()
        {
            ObjectManager.circuit_maglock_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.circuit_maglock_obj, "StarTruck_Circuit_Panel  [Maglock]");
            if (ObjectManager.circuit_maglock_obj == null) { return "DEN"; }
            ObjectManager.circuit_maglock_obj.ToggleOff();
            return "ACK";
        }

        public static string ToggleCircuitBreakerCoreOn()
        {
            ObjectManager.circuit_core_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.circuit_core_obj, "StarTruck_Circuit_Panel [Core]");
            if (ObjectManager.circuit_core_obj == null) { return "DEN"; }
            ObjectManager.circuit_core_obj.ToggleOn();
            return "ACK";
        }

        public static string ToggleCircuitBreakerCoreOff()
        {
            ObjectManager.circuit_core_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.circuit_core_obj, "StarTruck_Circuit_Panel [Core]");
            if (ObjectManager.circuit_core_obj == null) { return "DEN"; }
            ObjectManager.circuit_core_obj.ToggleOff();
            return "ACK";
        }

        public static string ToggleCircuitBreakerSuitOn()
        {
            ObjectManager.circuit_suit_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.circuit_suit_obj, "StarTruck_Circuit_Panel [Suit]");
            if (ObjectManager.circuit_suit_obj == null) { return "DEN"; }
            ObjectManager.circuit_suit_obj.ToggleOn();
            return "ACK";
        }

        public static string ToggleCircuitBreakerSuitOff()
        {
            ObjectManager.circuit_suit_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.circuit_suit_obj, "StarTruck_Circuit_Panel [Suit]");
            if (ObjectManager.circuit_suit_obj == null) { return "DEN"; }
            ObjectManager.circuit_suit_obj.ToggleOff();
            return "ACK";
        }

        public static string ToggleHornOn()
        {
            ObjectManager.horn_obj = ObjectManager.ObjectChecker<InteractTarget>(ObjectManager.horn_obj, "StarTruck_Dashboard_Top_Lever_Scanner");
            if (ObjectManager.horn_obj == null) { return "DEN"; }
            ObjectManager.horn_obj.OnPrimaryInteract(true);
            return "ACK";
        }

        public static string ToggleHornOff()
        {
            ObjectManager.horn_obj = ObjectManager.ObjectChecker<InteractTarget>(ObjectManager.horn_obj, "StarTruck_Dashboard_Top_Lever_Scanner");
            if (ObjectManager.horn_obj == null) { return "DEN"; }
            ObjectManager.horn_obj.OnPrimaryInteract(false);
            return "ACK";
        }

        public static string ToggleShutters()
        {
            ObjectManager.shutters_obj = ObjectManager.ObjectChecker<InteractTarget>(ObjectManager.shutters_obj, "StarTruck_Dashboard_Top_Lever_Shutter");
            if (ObjectManager.shutters_obj == null) { return "DEN"; }
            ObjectManager.shutters_obj.OnPrimaryInteract(true);
            return "ACK";
        }

        public static string ToggleCruiseControl()
        {
            ObjectManager.cruise_control_switch_obj = ObjectManager.ObjectChecker<CruiseControlSwitch>(ObjectManager.cruise_control_switch_obj, "StarTruck_Switch_Pole [Cruise Control Enable]");
            if (ObjectManager.cruise_control_switch_obj == null) { return "DEN"; }
            ObjectManager.cruise_control_switch_obj.OnInteract();
            return "ACK";
        }

        public static string IncreaseCruiseControl()
        {
            ObjectManager.cruise_control_switch_obj = ObjectManager.ObjectChecker<CruiseControlSwitch>(ObjectManager.cruise_control_switch_obj, "StarTruck_Switch_Pole [Cruise Control Enable]");
            if (ObjectManager.cruise_control_switch_obj == null) { return "DEN"; }
            ObjectManager.cruise_control_switch_obj.OnIncreaseSpeedButtonPress();
            return "ACK";
        }

        public static string DecreaseCruiseControl()
        {
            ObjectManager.cruise_control_switch_obj = ObjectManager.ObjectChecker<CruiseControlSwitch>(ObjectManager.cruise_control_switch_obj, "StarTruck_Switch_Pole [Cruise Control Enable]");
            if (ObjectManager.cruise_control_switch_obj == null) { return "DEN"; }
            ObjectManager.cruise_control_switch_obj.OnDecreaseSpeedButtonPress();
            return "ACK";
        }

        public static string ToggleChokeLeftOn()
        {
            ObjectManager.choke_left_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.choke_left_obj, "StarTruck_Switch_Pole [ ChokeL ]");
            if (ObjectManager.choke_left_obj == null) { return "DEN"; }
            ObjectManager.choke_left_obj.ToggleOn();
            return "ACK";
        }

        public static string ToggleChokeLeftOff()
        {
            ObjectManager.choke_left_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.choke_left_obj, "StarTruck_Switch_Pole [ ChokeL ]");
            if (ObjectManager.choke_left_obj == null) { return "DEN"; }
            ObjectManager.choke_left_obj.ToggleOff();
            return "ACK";
        }

        public static string ToggleChokeRightOn()
        {
            ObjectManager.choke_right_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.choke_right_obj, "StarTruck_Switch_Pole [ ChokeR ]");
            if (ObjectManager.choke_right_obj == null) { return "DEN"; }
            ObjectManager.choke_right_obj.ToggleOn();
            return "ACK";
        }

        public static string ToggleChokeRightOff()
        {
            ObjectManager.choke_right_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.choke_right_obj, "StarTruck_Switch_Pole [ ChokeR ]");
            if (ObjectManager.choke_right_obj == null) { return "DEN"; }
            ObjectManager.choke_right_obj.ToggleOff();
            return "ACK";
        }

        public static string ToggleRearThrustersOn()
        {
            ObjectManager.rear_thrusters_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.rear_thrusters_obj, "StarTruck_Switch_Pole [ Rear Thrusters ]");
            if (ObjectManager.rear_thrusters_obj == null) { return "DEN"; }
            ObjectManager.rear_thrusters_obj.ToggleOn();
            return "ACK";
        }

        public static string ToggleRearThrustersOff()
        {
            ObjectManager.rear_thrusters_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.rear_thrusters_obj, "StarTruck_Switch_Pole [ Rear Thrusters ]");
            if (ObjectManager.rear_thrusters_obj == null) { return "DEN"; }
            ObjectManager.rear_thrusters_obj.ToggleOff();
            return "ACK";
        }

        public static string ToggleMainThrustersLeftOn()
        {
            ObjectManager.main_thruster_left_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.main_thruster_left_obj, "StarTruck_Switch_Pole_Large [ Main L ]");
            if (ObjectManager.main_thruster_left_obj == null) { return "DEN"; }
            ObjectManager.main_thruster_left_obj.ToggleOn();
            return "ACK";
        }

        public static string ToggleMainThrustersLeftOff()
        {
            ObjectManager.main_thruster_left_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.main_thruster_left_obj, "StarTruck_Switch_Pole_Large [ Main L ]");
            if (ObjectManager.main_thruster_left_obj == null) { return "DEN"; }
            ObjectManager.main_thruster_left_obj.ToggleOff();
            return "ACK";
        }

        public static string ToggleMainThrustersRightOn()
        {
            ObjectManager.main_thruster_right_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.main_thruster_right_obj, "StarTruck_Switch_Pole_Large [ Main R ]");
            if (ObjectManager.main_thruster_right_obj == null) { return "DEN"; }
            ObjectManager.main_thruster_right_obj.ToggleOn();
            return "ACK";
        }

        public static string ToggleMainThrustersRightOff()
        {
            ObjectManager.main_thruster_right_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.main_thruster_right_obj, "StarTruck_Switch_Pole_Large [ Main R ]");
            if (ObjectManager.main_thruster_right_obj == null) { return "DEN"; }
            ObjectManager.main_thruster_right_obj.ToggleOff();
            return "ACK";
        }

        public static string ToggleAlertsOn()
        {
            ObjectManager.alerts_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.alerts_obj, "StarTruck_Switch_Pole [ Alerts ]");
            if (ObjectManager.alerts_obj == null) { return "DEN"; }
            ObjectManager.alerts_obj.ToggleOn();
            return "ACK";
        }

        public static string ToggleAlertsOff()
        {
            ObjectManager.alerts_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.alerts_obj, "StarTruck_Switch_Pole [ Alerts ]");
            if (ObjectManager.alerts_obj == null) { return "DEN"; }
            ObjectManager.alerts_obj.ToggleOff();
            return "ACK";
        }

        public static string ToggleDriveAssist()
        {
            ObjectManager.drive_assist_obj = ObjectManager.ObjectChecker<ToggleButton>(ObjectManager.drive_assist_obj, "StarTruck_SwitchTriangle");
            if (ObjectManager.drive_assist_obj == null) { return "DEN"; }
            ObjectManager.drive_assist_obj.OnInteract();
            return "ACK";
        }

        public static string ToggleMaglock()
        {
            ObjectManager.maglock_lever_obj = ObjectManager.ObjectChecker<MaglockLever>(ObjectManager.maglock_lever_obj, "StarTruck_MagLock_Lever_Root");
            if (ObjectManager.maglock_lever_obj == null) { return "DEN"; }
            ObjectManager.maglock_lever_obj.OnInteract();
            return "ACK";
        }

        public static string ToggleEmergencyBrakeOn()
        {
            ObjectManager.emergency_brake_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.emergency_brake_obj, "StarTruck_Emergency_Brake_Controls_Root");
            if (ObjectManager.emergency_brake_obj == null) { return "DEN"; }
            ObjectManager.emergency_brake_obj.ToggleOn();
            return "ACK";
        }

        public static string ToggleEmergencyBrakeOff()
        {
            ObjectManager.emergency_brake_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.emergency_brake_obj, "StarTruck_Emergency_Brake_Controls_Root");
            if (ObjectManager.emergency_brake_obj == null) { return "DEN"; }
            ObjectManager.emergency_brake_obj.ToggleOff();
            return "ACK";
        }

        public string ToggleWarpLever()
        {
            ObjectManager.warp_lever_obj = ObjectManager.ObjectChecker<WarpLever>(ObjectManager.warp_lever_obj, "StarTruck_Switch_Warp");
            if (ObjectManager.warp_lever_obj == null) { return "DEN"; }
            ObjectManager.warp_lever_obj.OnInteract();
            return "ACK";
        }
    }
}
