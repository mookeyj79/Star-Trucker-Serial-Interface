using Il2Cpp;
using UnityEngine;

namespace ST_Serial_Interface
{
    internal class ObjectManager
    {
        public static CorePower? core_obj;
        public static CruiseControl? cruise_control_obj;
        public static CruiseControlSwitch? cruise_control_switch_obj;
        public static DashboardNeedleController? fuel_level_obj;
        public static DashboardNeedleController? oxygen_level_obj;
        public static DashboardNeedleController? thruster_temp_left_obj;
        public static DashboardNeedleController? thruster_temp_right_obj;
        public static DashboardSpeedometerNeedleController? speedometer_obj;
        public static GravityCompensator? gravity_obj;
        public static InteractTarget? horn_obj;
        public static InteractTarget? shutters_obj;
        public static LifeSupport? life_support_obj;
        public static Maglock? maglock_obj;
        public static MaglockLever? maglock_lever_obj;
        public static SuitStation? suit_obj;
        public static ToggleButton? drive_assist_obj;
        public static ToggleSwitch? alerts_obj;
        public static ToggleSwitch? auxlights_obj;
        public static ToggleSwitch? choke_left_obj;
        public static ToggleSwitch? choke_right_obj;
        public static ToggleSwitch? circuit_core_obj;
        public static ToggleSwitch? circuit_gravity_obj;
        public static ToggleSwitch? circuit_maglock_obj;
        public static ToggleSwitch? circuit_oxygen_obj;
        public static ToggleSwitch? circuit_shield_obj;
        public static ToggleSwitch? circuit_suit_obj;
        public static ToggleSwitch? circuit_temp_obj;
        public static ToggleSwitch? emergency_brake_obj;
        public static ToggleSwitch? frontlights_obj;
        public static ToggleSwitch? headlights_obj;
        public static ToggleSwitch? lowerlights_obj;
        public static ToggleSwitch? main_thruster_left_obj;
        public static ToggleSwitch? main_thruster_right_obj;
        public static ToggleSwitch? rear_thrusters_obj;
        public static ToggleSwitch? rooflights_obj;
        public static ToggleSwitch? upperlights_obj;
        public static WarpLever? warp_lever_obj;
        public static TemperatureControlUnit? temp_control_obj;
        public static DialSwitch? temp_dial_obj;
        public static DialSwitch? blower_dial_obj;

        public static T? ObjectChecker<T>(T? obj, string name)
        {
            if (obj == null)
            {
                try { return GameObject.Find(name).GetComponent<T>(); }
                catch (System.NullReferenceException) { return default; };
            }
            return obj;
        }
    }
}
