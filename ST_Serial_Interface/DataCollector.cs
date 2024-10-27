using ExtensionMethods;
using Il2Cpp;
using Il2CppInterop.Runtime.InteropTypes.Arrays;

namespace ST_Serial_Interface
{
    internal class DataCollector
    {
        private static float GetAirFilter_Base(int filter)
        {
            // 0 - R1, 1 - R2, 2 - L2, 3 - L1
            float filter_status = 0;
            ObjectManager.life_support_obj = ObjectManager.ObjectChecker<LifeSupport>(ObjectManager.life_support_obj, "LifeSupport");
            if (ObjectManager.life_support_obj != null)
            {
                Il2CppReferenceArray<TruckSystemsBindingAirFilterState> air_filter_levels = ObjectManager.life_support_obj.airFilterStateBindings;
                filter_status = air_filter_levels[filter].Get().percentageEfficiency * 100;
            }
            return filter_status;
        }

        public static float GetAirFilter_R1()
        {
            return GetAirFilter_Base(0);
        }

        public static float GetAirFilter_R2()
        {
            return GetAirFilter_Base(1);
        }

        public static float GetAirFilter_L1()
        {
            return GetAirFilter_Base(3);
        }

        public static float GetAirFilter_L2()
        {
            return GetAirFilter_Base(2);
        }

        public static float GetSpeedometer()
        {
            float speedometer = 0;
            ObjectManager.speedometer_obj = ObjectManager.ObjectChecker<DashboardSpeedometerNeedleController>(ObjectManager.speedometer_obj, "StarTruck_Dashboard_Needle_Large [ Speed ]");
            if (ObjectManager.speedometer_obj != null) { speedometer = ObjectManager.speedometer_obj.valueBinding.Get().Map(0, (float)89.408, 0, 200); }
            return speedometer;
        }

        public static float GetFuelLevel()
        {
            float fuel_level = 0;
            ObjectManager.fuel_level_obj = ObjectManager.ObjectChecker<DashboardNeedleController>(ObjectManager.fuel_level_obj, "StarTruck_Dashboard_Needle_Small [ Fuel ]");
            if (ObjectManager.fuel_level_obj != null) { fuel_level = ObjectManager.fuel_level_obj.valueBinding.Get().Map(0, (float)89.408, 0, 200); }
            return fuel_level;
        }

        public static float GetOxygenLevel()
        {
            float oxygen_level = 0;
            ObjectManager.oxygen_level_obj = ObjectManager.ObjectChecker<DashboardNeedleController>(ObjectManager.oxygen_level_obj, "StarTruck_Dashboard_Needle_Small [ Oxygen ]");
            if (ObjectManager.oxygen_level_obj != null) { oxygen_level = ObjectManager.oxygen_level_obj.valueBinding.Get().Map(5, (float)19.5, 0, 100); }
            return oxygen_level;
        }

        public static float GetHeadLightsStatus()
        {
            bool headlight_status = false;
            ObjectManager.headlights_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.headlights_obj, "StarTruck_SwitchToggle1_HeadLights");
            if (ObjectManager.headlights_obj != null) { headlight_status = ObjectManager.headlights_obj.activated; }
            return Convert.ToSingle(headlight_status);
        }

        public static float GetAuxLightsStatus()
        {
            bool auxlight_status = false;
            ObjectManager.auxlights_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.auxlights_obj, "StarTruck_SwitchToggle2_AuxLights");
            if (ObjectManager.auxlights_obj != null) { auxlight_status = ObjectManager.auxlights_obj.activated; }
            return Convert.ToSingle(auxlight_status);
        }

        public static float GetRoofLightsStatus()
        {
            bool rooflight_status = false;
            ObjectManager.rooflights_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.rooflights_obj, "StarTruck_SwitchToggle3_RoofLights");
            if (ObjectManager.rooflights_obj != null) { rooflight_status = ObjectManager.rooflights_obj.activated; }
            return Convert.ToSingle(rooflight_status);
        }

        public static float GetFrontLightsStatus()
        {
            bool frontlight_status = false;
            ObjectManager.frontlights_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.frontlights_obj, "StarTruck_SwitchToggle4_FrontLights");
            if (ObjectManager.frontlights_obj != null) { frontlight_status = ObjectManager.frontlights_obj.activated; }
            return Convert.ToSingle(frontlight_status);
        }

        public static float GetLowerLightsStatus()
        {
            bool lowerlight_status = false;
            ObjectManager.lowerlights_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.lowerlights_obj, "StarTruck_SwitchToggle5_LowerLights");
            if (ObjectManager.lowerlights_obj != null) { lowerlight_status = ObjectManager.lowerlights_obj.activated; }
            return Convert.ToSingle(lowerlight_status);
        }

        public static float GetUpperLightsStatus()
        {
            bool upperlight_status = false;
            ObjectManager.upperlights_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.upperlights_obj, "StarTruck_SwitchToggle6_UpperLights");
            if (ObjectManager.upperlights_obj != null) { upperlight_status = ObjectManager.upperlights_obj.activated; }
            return Convert.ToSingle(upperlight_status);
        }

        private static float GetCorePowerLevel_Base(int core)
        {
            // 0 - Core 1, 1 - Core 2 
            float core_power_level = 0;
            ObjectManager.core_obj = ObjectManager.ObjectChecker<CorePower>(ObjectManager.core_obj, "CorePower");
            if (ObjectManager.core_obj != null)
            {
                Il2CppReferenceArray<TruckSystemsBindingPowerCellState> core_power_cells = ObjectManager.core_obj.powerCellStates;
                core_power_level = core_power_cells[core].Get().powerPercentage; ;
            }
            return core_power_level;
        }

        public static float GetCorePowerLevel_1()
        {
            return GetCorePowerLevel_Base(0);
        }

        public static float GetCorePowerLevel_2()
        {
            return GetCorePowerLevel_Base(1);
        }

        public static float GetSuitPowerLevel()
        {
            float suit_power_level = 0;
            ObjectManager.suit_obj = ObjectManager.ObjectChecker<SuitStation>(ObjectManager.suit_obj, "SpaceSuit");
            if (ObjectManager.suit_obj != null) { suit_power_level = ObjectManager.suit_obj.powerCellState.Get().powerPercentage; }
            return suit_power_level;
        }

        public static float GetGravityPowerLevel()
        {
            float gravity_power_level = 0;
            ObjectManager.gravity_obj = ObjectManager.ObjectChecker<GravityCompensator>(ObjectManager.gravity_obj, "GravityCompensator");
            if (ObjectManager.gravity_obj != null) { gravity_power_level = ObjectManager.gravity_obj.powerCellState.Get().powerPercentage; }
            return gravity_power_level;
        }

        public static float GetLifeSupportPowerLevel() 
        {
            float life_support_power_level = 0;
            ObjectManager.life_support_obj = ObjectManager.ObjectChecker<LifeSupport>(ObjectManager.life_support_obj, "LifeSupport");
            if (ObjectManager.life_support_obj != null) { life_support_power_level = ObjectManager.life_support_obj.powerCellState.Get().powerPercentage; }
            return life_support_power_level;
        }

        private static float GetMaglockPowerLevel_Base(int maglock)
        {
            // 0 - Maglock 1, 1 - Maglock 2
            float maglock_power_level = 0;
            ObjectManager.maglock_obj = ObjectManager.ObjectChecker<Maglock>(ObjectManager.maglock_obj, "Maglock");
            if (ObjectManager.maglock_obj != null)
            {
                Il2CppReferenceArray<TruckSystemsBindingPowerCellState> maglock_power_cells = ObjectManager.maglock_obj.powerCellStates;
                maglock_power_level = maglock_power_cells[maglock].Get().powerPercentage; ;
            }
            return maglock_power_level;
        }

        public static float GetMaglockPowerLevel_1()
        {
            return GetMaglockPowerLevel_Base(0);
        }

        public static float GetMaglockPowerLevel_2()
        {
            return GetMaglockPowerLevel_Base(1);
        }

        public static float GetCruiseControlSpeed()
        {
            float cruise_control_speed = 0;
            ObjectManager.cruise_control_obj = ObjectManager.ObjectChecker<CruiseControl>(ObjectManager.cruise_control_obj, "StarTruck");
            if (ObjectManager.cruise_control_obj != null) { cruise_control_speed = ObjectManager.cruise_control_obj.cruiseControlSpeed.Get().Map(0, (float)89.408, 0, 200); }
            return cruise_control_speed;
        }

        public static float GetCruiseControlStatus()
        {
            bool cruise_control_active = false;
            ObjectManager.cruise_control_obj = ObjectManager.ObjectChecker<CruiseControl>(ObjectManager.cruise_control_obj, "StarTruck");
            if (ObjectManager.cruise_control_obj != null) { cruise_control_active = ObjectManager.cruise_control_obj.cruiseControlActive.Get(); }
            return Convert.ToSingle(cruise_control_active);
        }

        public static float GetCircuitBreakerGravityState()
        {
            bool circuit_gravity_status = false;
            ObjectManager.circuit_gravity_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.circuit_gravity_obj, "StarTruck_Circuit_Panel [Gravity]");
            if (ObjectManager.circuit_gravity_obj != null) { circuit_gravity_status = ObjectManager.circuit_gravity_obj.activated; }
            return Convert.ToSingle(circuit_gravity_status);
        }

        public static float GetCircuitBreakerShieldState()
        {
            bool circuit_shield_status = false;
            ObjectManager.circuit_shield_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.circuit_shield_obj, "StarTruck_Circuit_Panel [Shield]");
            if (ObjectManager.circuit_shield_obj != null) { circuit_shield_status = ObjectManager.circuit_shield_obj.activated; }
            return Convert.ToSingle(circuit_shield_status);
        }

        public static float GetCircuitBreakerTempState()
        {
            bool circuit_temp_status = false;
            ObjectManager.circuit_temp_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.circuit_temp_obj, "StarTruck_Circuit_Panel [Temp]");
            if (ObjectManager.circuit_temp_obj != null) { circuit_temp_status = ObjectManager.circuit_temp_obj.activated; }
            return Convert.ToSingle(circuit_temp_status);
        }

        public static float GetCircuitBreakerOxygenState()
        {
            bool circuit_oxygen_status = false;
            ObjectManager.circuit_oxygen_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.circuit_oxygen_obj, "StarTruck_Circuit_Panel [Oxygen]");
            if (ObjectManager.circuit_oxygen_obj != null) { circuit_oxygen_status = ObjectManager.circuit_oxygen_obj.activated; }
            return Convert.ToSingle(circuit_oxygen_status);
        }

        public static float GetCircuitBreakerMaglockState()
        {
            bool circuit_maglock_status = false;
            ObjectManager.circuit_maglock_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.circuit_maglock_obj, "StarTruck_Circuit_Panel  [Maglock]");
            if (ObjectManager.circuit_maglock_obj != null) { circuit_maglock_status = ObjectManager.circuit_maglock_obj.activated; }
            return Convert.ToSingle(circuit_maglock_status);
        }

        public static float GetCircuitBreakerCoreState()
        {
            bool circuit_core_status = false;
            ObjectManager.circuit_core_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.circuit_core_obj, "StarTruck_Circuit_Panel [Core]");
            if (ObjectManager.circuit_core_obj != null) { circuit_core_status = ObjectManager.circuit_core_obj.activated; }
            return Convert.ToSingle(circuit_core_status);
        }

        public static float GetCircuitBreakerSuitState()
        {
            bool circuit_suit_status = false;
            ObjectManager.circuit_suit_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.circuit_suit_obj, "StarTruck_Circuit_Panel [Suit]");
            if (ObjectManager.circuit_suit_obj != null) { circuit_suit_status = ObjectManager.circuit_suit_obj.activated; }
            return Convert.ToSingle(circuit_suit_status);
        }

        public static float GetThrusterTempLeft()
        {
            float thruster_temp = 0;
            ObjectManager.thruster_temp_left_obj = ObjectManager.ObjectChecker<DashboardNeedleController>(ObjectManager.thruster_temp_left_obj, "StarTruck_Needle_L");
            if (ObjectManager.thruster_temp_left_obj != null) { thruster_temp = ObjectManager.thruster_temp_left_obj.valueBinding.Get() * 100; }
            return thruster_temp;
        }

        public static float GetThrusterTempRight()
        {
            float thruster_temp = 0;
            ObjectManager.thruster_temp_right_obj = ObjectManager.ObjectChecker<DashboardNeedleController>(ObjectManager.thruster_temp_right_obj, "StarTruck_Needle_R");
            if (ObjectManager.thruster_temp_right_obj != null) { thruster_temp = ObjectManager.thruster_temp_right_obj.valueBinding.Get() * 100; }
            return thruster_temp;
        }

        public static float GetDriveAssistStatus()
        {
            bool drive_assist_status = false;
            ObjectManager.drive_assist_obj = ObjectManager.ObjectChecker<ToggleButton>(ObjectManager.drive_assist_obj, "StarTruck_SwitchTriangle");
            if (ObjectManager.drive_assist_obj != null) { drive_assist_status = ObjectManager.drive_assist_obj.activated; }
            return Convert.ToSingle(drive_assist_status);
        }

        public static float GetMaglockStatus()
        {
            int maglock_status = 0;
            ObjectManager.maglock_lever_obj = ObjectManager.ObjectChecker<MaglockLever>(ObjectManager.maglock_lever_obj, "StarTruck_MagLock_Lever_Root");
            if (ObjectManager.maglock_lever_obj != null)
            { 
                if (ObjectManager.maglock_lever_obj.displayString == "Hitch") { maglock_status = 1; }
                else if (ObjectManager.maglock_lever_obj.displayString == "Unhitch") { maglock_status = 2; }
                else { maglock_status = 0; }
            }
            return Convert.ToSingle(maglock_status);
        }

        public static float GetEmergencyBrakeStatus()
        {
            bool emergency_brake_status = false;
            ObjectManager.emergency_brake_obj = ObjectManager.ObjectChecker<ToggleSwitch>(ObjectManager.emergency_brake_obj, "StarTruck_Emergency_Brake_Controls_Root");
            if (ObjectManager.emergency_brake_obj != null) { emergency_brake_status = ObjectManager.emergency_brake_obj.activated; }
            return Convert.ToSingle(emergency_brake_status);
        }

        public static float GetWarpStatus()
        {
            bool warp_status = false;
            ObjectManager.warp_lever_obj = ObjectManager.ObjectChecker<WarpLever>(ObjectManager.warp_lever_obj, "StarTruck_Switch_Warp");
            if (ObjectManager.warp_lever_obj != null) { warp_status = ObjectManager.warp_lever_obj.IsWarpAvailable(); }
            return Convert.ToSingle(warp_status);
        }
    }
}
