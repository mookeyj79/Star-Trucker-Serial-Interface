using ExtensionMethods;
using Il2Cpp;
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

        private T GetAirFilter_R1_Base<T>()
        {
            // Generic air filter base allowing for specified type output

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
                filter_status = air_filter_levels[0].Get().percentageEfficiency * 100;
            }

            // Return value in given type
            return (T)Convert.ChangeType(filter_status, typeof(T));
        }

        private T GetAirFilter_R2_Base<T>()
        {
            // Generic air filter base allowing for specified type output

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
                filter_status = air_filter_levels[1].Get().percentageEfficiency * 100;
            }

            // Return value in given type
            return (T)Convert.ChangeType(filter_status, typeof(T));
        }

        private T GetAirFilter_L1_Base<T>()
        {
            // Generic air filter base allowing for specified type output

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
                filter_status = air_filter_levels[3].Get().percentageEfficiency * 100;
            }

            // Return value in given type
            return (T)Convert.ChangeType(filter_status, typeof(T));
        }

        private T GetAirFilter_L2_Base<T>()
        {
            // Generic air filter base allowing for specified type output

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
                filter_status = air_filter_levels[2].Get().percentageEfficiency * 100;
            }

            // Return value in given type
            return (T)Convert.ChangeType(filter_status, typeof(T));
        }

        public int GetAirFilter_R1_INT()
        {
            // Returns a 'int' variant of the air filter status
            return GetAirFilter_R1_Base<int>();
        }

        public float GetAirFilter_R1_FLOAT()
        {
            // Returns a 'float' variant of the air filter status
            return GetAirFilter_R1_Base<float>();
        }

        public int GetAirFilter_R2_INT()
        {
            // Returns a 'int' variant of the air filter status
            return GetAirFilter_R2_Base<int>();
        }

        public float GetAirFilter_R2_FLOAT()
        {
            // Returns a 'float' variant of the air filter status
            return GetAirFilter_R2_Base<float>();
        }

        public int GetAirFilter_L1_INT()
        {
            // Returns a 'int' variant of the air filter status
            return GetAirFilter_L1_Base<int>();
        }

        public float GetAirFilter_L1_FLOAT()
        {
            // Returns a 'float' variant of the air filter status
            return GetAirFilter_L1_Base<float>();
        }

        public int GetAirFilter_L2_INT()
        {
            // Returns a 'int' variant of the air filter status
            return GetAirFilter_L2_Base<int>();
        }

        public float GetAirFilter_L2_FLOAT()
        {
            // Returns a 'float' variant of the air filter status
            return GetAirFilter_L2_Base<float>();
        }

        private T GetSpeedometer_Base<T>()
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

            // Return value in given type
            return (T)Convert.ChangeType(speedometer, typeof(T));
        }

        public int GetSpeedometer_INT()
        {
            // Returns a 'int' variant of the speedometer
            return GetSpeedometer_Base<int>();
        }

        public float GetSpeedometer_FLOAT()
        {
            // Returns a 'float' variant of the speedometer
            return GetSpeedometer_Base<float>();
        }

        private T GetFuelLevel_Base<T>()
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

            // Return value in given type
            return (T)Convert.ChangeType(fuel_level, typeof(T));
        }

        public int GetFuelLevel_INT()
        {
            // Returns a 'int' variant of the fuel level
            return GetFuelLevel_Base<int>();
        }

        public float GetFuelLevel_FLOAT()
        {
            // Returns a 'float' variant of the fuel level
            return GetFuelLevel_Base<float>();
        }

        private T GetOxygenLevel<T>()
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

            // Return value in given type
            return (T)Convert.ChangeType(oxygen_level, typeof(T));
        }

        public int GetOxygenLevel_INT()
        {
            // Returns a 'int' variant of the oxygen level
            return GetOxygenLevel<int>();
        }

        public float GetOxygenLevel_FLOAT()
        {
            // Returns a 'float' variant of the oxygen level
            return GetOxygenLevel<float>();
        }

        private T GetHeadLightsStatus_Base<T>()
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

            // Return value in given type
            return (T)Convert.ChangeType(headlight_status, typeof(T));
        }

        public bool GetHeadLightsStatus_BOOL()
        {
            // Returns a 'bool' variant of the headlight status
            return GetHeadLightsStatus_Base<bool>();
        }

        private T GetAuxLightsStatus_Base<T>()
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

            // Return value in given type
            return (T)Convert.ChangeType(auxlight_status, typeof(T));
        }

        public bool GetAuxLightsStatus_BOOL()
        {
            // Returns a 'bool' variant of the auxlights status
            return GetAuxLightsStatus_Base<bool>();
        }

        private T GetRoofLightsStatus_Base<T>()
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

            // Return value in given type
            return (T)Convert.ChangeType(rooflight_status, typeof(T));
        }

        public bool GetRoofLightsStatus_BOOL()
        {
            // Returns a 'bool' variant of the rooflights status
            return GetRoofLightsStatus_Base<bool>();
        }

        private T GetFrontLightsStatus_Base<T>()
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

            // Return value in given type
            return (T)Convert.ChangeType(frontlight_status, typeof(T));
        }

        public bool GetFrontLightsStatus_BOOL()
        {
            // Returns a 'bool' variant of the frontlights status
            return GetFrontLightsStatus_Base<bool>();
        }

        private T GetLowerLightsStatus_Base<T>()
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

            // Return value in given type
            return (T)Convert.ChangeType(lowerlight_status, typeof(T));
        }

        public bool GetLowerLightsStatus_BOOL()
        {
            // Returns a 'bool' variant of the lowerlights status
            return GetLowerLightsStatus_Base<bool>();
        }

        private T GetUpperLightsStatus_Base<T>()
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

            // Return value in given type
            return (T)Convert.ChangeType(upperlight_status, typeof(T));
        }

        public bool GetUpperLightsStatus_BOOL()
        {
            // Returns a 'bool' variant of the upperlights status
            return GetUpperLightsStatus_Base<bool>();
        }

        private T GetCorePowerLevel_C1_Base<T>()
        {
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
                core_power_level = core_power_cells[0].Get().powerPercentage;
            }

            // Return value in given type
            return (T)Convert.ChangeType(core_power_level, typeof(T));
        }

        private T GetCorePowerLevel_C2_Base<T>()
        {
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
                core_power_level = core_power_cells[1].Get().powerPercentage;
            }

            // Return value in given type
            return (T)Convert.ChangeType(core_power_level, typeof(T));
        }

        public int GetCorePowerLevel_C1_INT()
        {
            // Returns a 'int' variant of the core power level
            return GetCorePowerLevel_C1_Base<int>();
        }

        public float GetCorePowerLevel_C1_FLOAT()
        {
            // Returns a 'float' variant of the core power level
            return GetCorePowerLevel_C1_Base<float>();
        }

        public int GetCorePowerLevel_C2_INT()
        {
            // Returns a 'int' variant of the core power level
            return GetCorePowerLevel_C2_Base<int>();
        }

        public float GetCorePowerLevel_C2_FLOAT()
        {
            // Returns a 'float' variant of the core power level
            return GetCorePowerLevel_C2_Base<float>();
        }

        private T GetSuitPowerLevel_Base<T>()
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

            // Return value in given type
            return (T)Convert.ChangeType(suit_power_level, typeof(T));
        }

        public int GetSuitPowerLevel_INT()
        {
            // Returns a 'int' variant of the suit power level
            return GetSuitPowerLevel_Base<int>();
        }

        public float GetSuitPowerLevel_FLOAT()
        {
            // Returns a 'float' variant of the suit power level
            return GetSuitPowerLevel_Base<float>();
        }

        private T GetGravityPowerLevel_Base<T>()
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

            // Return value in given type
            return (T)Convert.ChangeType(gravity_power_level, typeof(T));
        }

        public int GetGravityPowerLevel_INT()
        {
            // Returns a 'int' variant of the gravity power level
            return GetGravityPowerLevel_Base<int>();
        }

        public float GetGravityPowerLevel_FLOAT()
        {
            // Returns a 'float' variant of the gravity power level
            return GetGravityPowerLevel_Base<float>();
        }

        private T GetLifeSupportPowerLevel_Base<T>()
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
            return (T)Convert.ChangeType(life_support_power_level, typeof(T));
        }

        public int GetLifeSupportPowerLevel_INT()
        {
            // Returns a 'int' variant of the life support power level
            return GetLifeSupportPowerLevel_Base<int>();
        }

        public float GetLifeSupportPowerLevel_FLOAT()
        {
            // Returns a 'float' variant of the life support power level
            return GetLifeSupportPowerLevel_Base<float>();
        }

        private T GetMaglockPowerLevel_A_Base<T>()
        {
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
                maglock_power_level = maglock_power_cells[0].Get().powerPercentage;
            }

            // Return value in given type
            return (T)Convert.ChangeType(maglock_power_level, typeof(T));
        }

        private T GetMaglockPowerLevel_B_Base<T>()
        {
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
                maglock_power_level = maglock_power_cells[1].Get().powerPercentage;
            }

            // Return value in given type
            return (T)Convert.ChangeType(maglock_power_level, typeof(T));
        }

        public int GetMaglockPowerLevel_A_INT()
        {
            // Returns a 'int' variant of the maglock power level
            return GetMaglockPowerLevel_A_Base<int>();
        }

        public float GetMaglockPowerLevel_A_FLOAT()
        {
            // Returns a 'float' variant of the maglock power level
            return GetMaglockPowerLevel_A_Base<float>();
        }

        public int GetMaglockPowerLevel_B_INT()
        {
            // Returns a 'int' variant of the maglock power level
            return GetMaglockPowerLevel_B_Base<int>();
        }

        public float GetMaglockPowerLevel_B_FLOAT()
        {
            // Returns a 'float' variant of the maglock power level
            return GetMaglockPowerLevel_B_Base<float>();
        }
    }
}
