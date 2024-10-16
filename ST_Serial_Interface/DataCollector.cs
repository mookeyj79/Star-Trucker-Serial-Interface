using ExtensionMethods;
using Il2Cpp;
using Il2CppFlowCanvas.Nodes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using UnityEngine;

namespace ST_Serial_Interface
{
    internal class DataCollector
    {
        // Game objects
        private LifeSupport? life_support_obj;
        private CorePower? core_obj;
        private SuitStation? suit_obj;
        private GravityCompensator? gravity_obj;
        private Maglock? maglock_obj;
        private DashboardSpeedometerNeedleController? speedometer_obj;
        private DashboardNeedleController? fuel_level_obj;
        private DashboardNeedleController? oxygen_level_obj;
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
        private CruiseControl? cruise_control_obj;

        private float GetAirFilter_Base(int filter)
        {
            // 0 - R1, 1 - R2, 2 - L2, 3 - L1

            // Set default output
            float filter_status = 0;

            // Verify that 'life_support_obj' exists, create if not
            if (life_support_obj == null)
            {
                try { life_support_obj = GameObject.FindFirstObjectByType<LifeSupport>(); }
                catch { life_support_obj = null; }
            }

            // Get air filter status
            if (life_support_obj != null)
            {
                Il2CppReferenceArray<TruckSystemsBindingAirFilterState> air_filter_levels = life_support_obj.airFilterStateBindings;
                filter_status = air_filter_levels[filter].Get().percentageEfficiency * 100;
            }

            // Return value
            return filter_status;
        }

        public float GetAirFilter_R1()
        {
            // Get filter status from the base
            return GetAirFilter_Base(0);
        }

        public float GetAirFilter_R2()
        {
            // Get filter status from the base
            return GetAirFilter_Base(1);
        }

        public float GetAirFilter_L1()
        {
            // Get filter status from the base
            return GetAirFilter_Base(3);
        }

        public float GetAirFilter_L2()
        {
            // Get filter status from the base
            return GetAirFilter_Base(2);
        }

        public float GetSpeedometer()
        {
            // Set default output
            float speedometer = 0;

            // Verify that 'speedometer_obj' exists, create if not
            if (speedometer_obj == null)
            {
                try { speedometer_obj = GameObject.Find("StarTruck_Dashboard_Needle_Large [ Speed ]").GetComponent<DashboardSpeedometerNeedleController>(); }
                catch { speedometer_obj = null; }
            }

            // Get current speedometer state
            if (speedometer_obj != null)
            {
                speedometer = speedometer_obj.valueBinding.Get().Map(0, (float)89.408, 0, 200);
            }

            // Return value
            return speedometer;
        }

        public float GetFuelLevel()
        {
            // Set default output
            float fuel_level = 0;

            // Verify that 'fuel_level_obj' exists, create if not
            if (fuel_level_obj == null)
            {
                try { fuel_level_obj = GameObject.Find("StarTruck_Dashboard_Needle_Small [ Fuel ]").GetComponent<DashboardNeedleController>(); }
                catch { fuel_level_obj = null; }
            }

            // Get current fuel level
            if (fuel_level_obj != null) { fuel_level = fuel_level_obj.valueBinding.Get(); }

            // Return value
            return fuel_level;
        }

        public float GetOxygenLevel()
        {
            // Set default output
            float oxygen_level = 0;

            // Verify that 'oxygen_level_obj' exists, create if not
            if (oxygen_level_obj == null)
            {
                try { oxygen_level_obj = GameObject.Find("StarTruck_Dashboard_Needle_Small [ Oxygen ]").GetComponent<DashboardNeedleController>(); }
                catch { oxygen_level_obj = null; }
            }

            // Get current oxygen level
            if (oxygen_level_obj != null) { oxygen_level = oxygen_level_obj.valueBinding.Get().Map(5, (float)19.5, 0, 100); }

            // Return value
            return oxygen_level;
        }

        public float GetHeadLightsStatus()
        {
            // Set default output
            bool headlight_status = false;

            // Verify that 'headlights_obj' exists, create if not
            if (headlights_obj == null)
            {
                try { headlights_obj = GameObject.Find("StarTruck_SwitchToggle1_HeadLights").GetComponent<ToggleSwitch>(); }
                catch { headlights_obj = null; }
            }

            // Get current headlights status
            if (headlights_obj != null) { headlight_status = headlights_obj.activated; }

            // Return value
            return Convert.ToSingle(headlight_status);
        }

        public float GetAuxLightsStatus()
        {
            // Set default output
            bool auxlight_status = false;

            // Verify that 'headlights_obj' exists, create if not
            if (auxlights_obj == null)
            {
                try { auxlights_obj = GameObject.Find("StarTruck_SwitchToggle2_AuxLights").GetComponent<ToggleSwitch>(); }
                catch { auxlights_obj = null; }
            }

            // Get current auxlights status
            if (auxlights_obj != null) { auxlight_status = auxlights_obj.activated; }

            // Return value
            return Convert.ToSingle(auxlight_status);
        }

        public float GetRoofLightsStatus()
        {
            // Set default output
            bool rooflight_status = false;

            // Verify that 'headlights_obj' exists, create if not
            if (rooflights_obj == null)
            {
                try { rooflights_obj = GameObject.Find("StarTruck_SwitchToggle3_RoofLights").GetComponent<ToggleSwitch>(); }
                catch { rooflights_obj = null; }
            }

            // Get current rooflights status
            if (rooflights_obj != null) { rooflight_status = rooflights_obj.activated; }

            // Return value
            return Convert.ToSingle(rooflight_status);
        }

        public float GetFrontLightsStatus()
        {
            // Set default output
            bool frontlight_status = false;

            // Verify that 'frontlights_obj' exists, create if not
            if (frontlights_obj == null)
            {
                try { frontlights_obj = GameObject.Find("StarTruck_SwitchToggle4_FrontLights").GetComponent<ToggleSwitch>(); }
                catch { frontlights_obj = null; }
            }

            // Get current frontlights status
            if (frontlights_obj != null) { frontlight_status = frontlights_obj.activated; }

            // Return value
            return Convert.ToSingle(frontlight_status);
        }

        public float GetLowerLightsStatus()
        {
            // Set default output
            bool lowerlight_status = false;

            // Verify that 'lowerlights_obj' exists, create if not
            if (lowerlights_obj == null)
            {
                try { lowerlights_obj = GameObject.Find("StarTruck_SwitchToggle5_LowerLights").GetComponent<ToggleSwitch>(); }
                catch { lowerlights_obj = null; }
            }

            // Get current lowerlights status
            if (lowerlights_obj != null) { lowerlight_status = lowerlights_obj.activated; }

            // Return value
            return Convert.ToSingle(lowerlight_status);
        }

        public float GetUpperLightsStatus()
        {
            // Set default output
            bool upperlight_status = false;

            // Verify that 'lowerlights_obj' exists, create if not
            if (upperlights_obj == null)
            {
                try { upperlights_obj = GameObject.Find("StarTruck_SwitchToggle6_UpperLights").GetComponent<ToggleSwitch>(); }
                catch { upperlights_obj = null; }
            }

            // Get current upperlights status
            if (upperlights_obj != null) { upperlight_status = upperlights_obj.activated; }

            // Return value
            return Convert.ToSingle(upperlight_status);
        }

        private float GetCorePowerLevel_Base(int core)
        {
            // 0 - Core 1, 1 - Core 2 

            // Set default output
            float core_power_level = 0;

            // Verify that 'core_obj' exists, create if not
            if (core_obj == null)
            {
                try { core_obj = GameObject.FindFirstObjectByType<CorePower>(); }
                catch { core_obj = null; }
            }

            // Get current core power level
            if (core_obj != null)
            {
                Il2CppReferenceArray<TruckSystemsBindingPowerCellState> core_power_cells = core_obj.powerCellStates;
                core_power_level = core_power_cells[core].Get().powerPercentage;
            }

            // Return value
            return core_power_level;
        }

        public float GetCorePowerLevel_1()
        {
            // Get core power level from base
            return GetCorePowerLevel_Base(0);
        }

        public float GetCorePowerLevel_2()
        {
            // Get core power level from base
            return GetCorePowerLevel_Base(1);
        }

        public float GetSuitPowerLevel()
        {
            // Set default output
            float suit_power_level = 0;

            // Verify that 'suit_obj' exists, create if not
            if (suit_obj == null)
            {
                try { suit_obj = GameObject.FindFirstObjectByType<SuitStation>(); }
                catch { suit_obj = null; }
            }

            // Get current suit power level
            if (suit_obj != null) { suit_power_level = suit_obj.powerCellState.Get().powerPercentage; }

            // Return value
            return suit_power_level;
        }

        public float GetGravityPowerLevel()
        {
            // Set default output
            float gravity_power_level = 0;

            // Verify that 'gravity_obj' exists, create if not
            if (gravity_obj == null)
            {
                try { gravity_obj = GameObject.FindAnyObjectByType<GravityCompensator>(); }
                catch { gravity_obj = null; }
            }

            // Get current gravity power level
            if (gravity_obj != null) { gravity_power_level = gravity_obj.powerCellState.Get().powerPercentage; }

            // Return value
            return gravity_power_level;
        }

        public float GetLifeSupportPowerLevel()
        {
            // Set default output
            float life_support_power_level = 0;

            // Verify that 'life_support_obj' exists, create if not
            if (life_support_obj == null)
            {
                try { life_support_obj = GameObject.FindAnyObjectByType<LifeSupport>(); }
                catch { life_support_obj = null; }
            }

            // Get current life support power level
            if (life_support_obj != null) { life_support_power_level = life_support_obj.powerCellState.Get().powerPercentage; }

            // Return value in given type
            return life_support_power_level;
        }

        private float GetMaglockPowerLevel_Base(int maglock)
        {
            // 0 - Maglock 1, 1 - Maglock 2

            // Set default output
            float maglock_power_level = 0;

            // Verify that 'maglock_obj' exists, create if not
            if (maglock_obj == null)
            {
                try { maglock_obj = GameObject.FindFirstObjectByType<Maglock>(); }
                catch { maglock_obj = null; }
            }

            // Get current maglock power level
            if (maglock_obj != null)
            {
                Il2CppReferenceArray<TruckSystemsBindingPowerCellState> maglock_power_cells = maglock_obj.powerCellStates;
                maglock_power_level = maglock_power_cells[maglock].Get().powerPercentage;
            }

            // Return value
            return maglock_power_level;
        }

        public float GetMaglockPowerLevel_1()
        {
            // Return maglock power level from base
            return GetMaglockPowerLevel_Base(0);
        }

        public float GetMaglockPowerLevel_2()
        {
            // Return maglock power level from base
            return GetMaglockPowerLevel_Base(1);
        }

        public float GetCruiseControlSpeed()
        {
            // Set default output
            float cruise_control_speed = 0;

            // Verify that 'cruise_control_obj' exists, create if not
            if (cruise_control_obj == null)
            {
                try { cruise_control_obj = GameObject.FindAnyObjectByType<CruiseControl>(); }
                catch { cruise_control_obj = null; }
            }

            // Get current cruise control speed
            if (cruise_control_obj != null) { cruise_control_speed = cruise_control_obj.cruiseControlSpeed.Get().Map(0, (float)89.408, 0, 200); }

            // Return value
            return cruise_control_speed;
        }

        public float GetCruiseControlStatus()
        {
            // Set default output
            bool cruise_control_active = false;

            // Verify that 'cruise_control_obj' exists, create if not
            if (cruise_control_obj == null)
            {
                try { cruise_control_obj = GameObject.FindAnyObjectByType<CruiseControl>(); }
                catch { cruise_control_obj = null; }
            }

            // Get current cruise control speed
            if (cruise_control_obj != null) { cruise_control_active = cruise_control_obj.cruiseControlActive.Get(); }

            // Return value
            return Convert.ToSingle(cruise_control_active);
        }

        public float GetCircuitBreakerGravityState()
        {
            // Set default output
            bool circuit_gravity_status = false;

            // Verify that 'circuit_gravity_obj' exists, create if not
            if (circuit_gravity_obj == null)
            {
                try { circuit_gravity_obj = GameObject.Find("StarTruck_Circuit_Panel [Gravity]").GetComponent<ToggleSwitch>(); }
                catch { circuit_gravity_obj = null; }
            }

            // Get current gravity circuit breaker status
            if (circuit_gravity_obj != null) { circuit_gravity_status = circuit_gravity_obj.activated; }

            // Return value
            return Convert.ToSingle(circuit_gravity_status);
        }

        public float GetCircuitBreakerShieldState()
        {
            // Set default output
            bool circuit_shield_status = false;

            // Verify that 'cicuit_shield_obj' exists, create if not
            if (circuit_shield_obj == null)
            {
                try { circuit_shield_obj = GameObject.Find("StarTruck_Circuit_Panel [Shield]").GetComponent<ToggleSwitch>(); }
                catch { circuit_shield_obj = null; }
            }

            // Get current gravity circuit breaker status
            if (circuit_shield_obj != null) { circuit_shield_status = circuit_shield_obj.activated; }

            // Return value
            return Convert.ToSingle(circuit_shield_status);
        }

        public float GetCircuitBreakerTempState()
        {
            // Set default output
            bool circuit_temp_status = false;

            // Verify that 'cicuit_temp_obj' exists, create if not
            if (circuit_temp_obj == null)
            {
                try { circuit_temp_obj = GameObject.Find("StarTruck_Circuit_Panel [Temp]").GetComponent<ToggleSwitch>(); }
                catch { circuit_temp_obj = null; }
            }

            // Get current temp circuit breaker status
            if (circuit_temp_obj != null) { circuit_temp_status = circuit_temp_obj.activated; }

            // Return value
            return Convert.ToSingle(circuit_temp_status);
        }

        public float GetCircuitBreakerOxygenState()
        {
            // Set default output
            bool circuit_oxygen_status = false;

            // Verify that 'cicuit_oxygen_obj' exists, create if not
            if (circuit_oxygen_obj == null)
            {
                try { circuit_oxygen_obj = GameObject.Find("StarTruck_Circuit_Panel [Oxygen]").GetComponent<ToggleSwitch>(); }
                catch { circuit_oxygen_obj = null; }
            }

            // Get current oxygen circuit breaker status
            if (circuit_oxygen_obj != null) { circuit_oxygen_status = circuit_oxygen_obj.activated; }

            // Return value
            return Convert.ToSingle(circuit_oxygen_status);
        }

        public float GetCircuitBreakerMaglockState()
        {
            // Set default output
            bool circuit_maglock_status = false;

            // Verify that 'cicuit_maglock_obj' exists, create if not
            if (circuit_maglock_obj == null)
            {
                try { circuit_maglock_obj = GameObject.Find("StarTruck_Circuit_Panel  [Maglock]").GetComponent<ToggleSwitch>(); }
                catch { circuit_maglock_obj = null; }
            }

            // Get current maglock circuit breaker status
            if (circuit_maglock_obj != null) { circuit_maglock_status = circuit_maglock_obj.activated; }

            // Return value
            return Convert.ToSingle(circuit_maglock_status);
        }

        public float GetCircuitBreakerCoreState()
        {
            // Set default output
            bool circuit_core_status = false;

            // Verify that 'cicuit_core_obj' exists, create if not
            if (circuit_core_obj == null)
            {
                try { circuit_core_obj = GameObject.Find("StarTruck_Circuit_Panel [Core]").GetComponent<ToggleSwitch>(); }
                catch { circuit_core_obj = null; }
            }

            // Get current core circuit breaker status
            if (circuit_core_obj != null) { circuit_core_status = circuit_core_obj.activated; }

            // Return value
            return Convert.ToSingle(circuit_core_status);
        }

        public float GetCircuitBreakerSuitState()
        {
            // Set default output
            bool circuit_suit_status = false;

            // Verify that 'cicuit_suit_obj' exists, create if not
            if (circuit_suit_obj == null)
            {
                try { circuit_suit_obj = GameObject.Find("StarTruck_Circuit_Panel [Suit]").GetComponent<ToggleSwitch>(); }
                catch { circuit_suit_obj = null; }
            }

            // Get current suit circuit breaker status
            if (circuit_suit_obj != null) { circuit_suit_status = circuit_suit_obj.activated; }

            // Return value in given type
            return Convert.ToSingle(circuit_suit_status);
        }
    }
}
