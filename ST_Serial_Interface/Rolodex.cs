using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ST_Serial_Interface
{
    internal class Rolodex
    {
        public Dictionary<string, Func<string>> CMD_Rolodex = new();
        public Dictionary<string, Func<float>> RET_Rolodex = new();
        public Dictionary<int, (Func<object> action, string name)> Channels = new();

        private readonly Interactor interactor = new();
        private readonly DataCollector data_collector = new();

        private static bool CastToBool(Func<float> f)
        {
            float value = f();
            return value != 0;
        }

        private static int CastToInt(Func<float> f)
        {
            float value = f();
            return (int)value;
        }

        private static float CastToFloat(Func<float> f)
        {
            return f();
        }

        private static string CastToString(Func<float> f)
        {
            float value = f();
            return value.ToString();
        }

        public void FunctionMapper()
        {
            CMD_Rolodex["TOGGLE_HEADLIGHTS_ON"] = interactor.ToggleHeadLightsOn;
            CMD_Rolodex["TOGGLE_HEADLIGHTS_OFF"] = interactor.ToggleHeadLightsOff;
            CMD_Rolodex["TOGGLE_AUXLIGHTS_ON"] = interactor.ToggleAuxLightsOn;
            CMD_Rolodex["TOGGLE_AUXLIGHTS_OFF"] = interactor.ToggleAuxLightsOff;
            CMD_Rolodex["TOGGLE_ROOFLIGHTS_ON"] = interactor.ToggleRoofLightsOn;
            CMD_Rolodex["TOGGLE_ROOFLIGHTS_OFF"] = interactor.ToggleRoofLightsOff;
            CMD_Rolodex["TOGGLE_FRONTLIGHTS_ON"] = interactor.ToggleFrontLightsOn;
            CMD_Rolodex["TOGGLE_FRONTLIGHTS_OFF"] = interactor.ToggleFrontLightsOff;
            CMD_Rolodex["TOGGLE_LOWERLIGHTS_ON"] = interactor.ToggleLowerLightsOn;
            CMD_Rolodex["TOGGLE_LOWERLIGHTS_OFF"] = interactor.ToggleLowerLightsOff;
            CMD_Rolodex["TOGGLE_UPPERLIGHTS_ON"] = interactor.ToggleUpperLightsOn;
            CMD_Rolodex["TOGGLE_UPPERLIGHTS_OFF"] = interactor.ToggleUpperLightsOff;
            CMD_Rolodex["TOGGLE_CIRCUIT_GRAVITY_ON"] = interactor.ToggleCircuitBreakerGravityOn;
            CMD_Rolodex["TOGGLE_CIRCUIT_GRAVITY_OFF"] = interactor.ToggleCircuitBreakerGravityOff;
            CMD_Rolodex["TOGGLE_CIRCUIT_SHIELD_ON"] = interactor.ToggleCircuitBreakerShieldOn;
            CMD_Rolodex["TOGGLE_CIRCUIT_SHIELD_OFF"] = interactor.ToggleCircuitBreakerShieldOff;
            CMD_Rolodex["TOGGLE_CIRCUIT_TEMP_ON"] = interactor.ToggleCircuitBreakerTempOn;
            CMD_Rolodex["TOGGLE_CIRCUIT_TEMP_OFF"] = interactor.ToggleCircuitBreakerTempOff;
            CMD_Rolodex["TOGGLE_CIRCUIT_OXYGEN_ON"] = interactor.ToggleCircuitBreakerOxygenOn;
            CMD_Rolodex["TOGGLE_CIRCUIT_OXYGEN_OFF"] = interactor.ToggleCircuitBreakerOxygenOff;
            CMD_Rolodex["TOGGLE_CIRCUIT_MAGLOCK_ON"] = interactor.ToggleCircuitBreakerMaglockOn;
            CMD_Rolodex["TOGGLE_CIRCUIT_MAGLOCK_OFF"] = interactor.ToggleCircuitBreakerMaglockOff;
            CMD_Rolodex["TOGGLE_CIRCUIT_CORE_ON"] = interactor.ToggleCircuitBreakerCoreOn;
            CMD_Rolodex["TOGGLE_CIRCUIT_CORE_OFF"] = interactor.ToggleCircuitBreakerCoreOff;
            CMD_Rolodex["TOGGLE_CIRCUIT_SUIT_ON"] = interactor.ToggleCircuitBreakerSuitOn;
            CMD_Rolodex["TOGGLE_CIRCUIT_SUIT_OFF"] = interactor.ToggleCircuitBreakerSuitOff;
            CMD_Rolodex["TOGGLE_HORN_ON"] = interactor.ToggleHornOn;
            CMD_Rolodex["TOGGLE_HORN_OFF"] = interactor.ToggleHornOff;
            CMD_Rolodex["TOGGLE_SHUTTERS"] = interactor.ToggleShutters;
            CMD_Rolodex["TOGGLE_CRUISE_CONTROL"] = interactor.ToggleCruiseControl;
            CMD_Rolodex["INCREASE_CRUISE_CONTROL"] = interactor.IncreaseCruiseControl;
            CMD_Rolodex["DECREASE_CRUISE_CONTROL"] = interactor.DecreaseCruiseControl;
            CMD_Rolodex["TOGGLE_CHOKE_L_ON"] = interactor.ToggleChokeLeftOn;
            CMD_Rolodex["TOGGLE_CHOKE_L_OFF"] = interactor.ToggleChokeLeftOff;
            CMD_Rolodex["TOGGLE_CHOKE_R_ON"] = interactor.ToggleChokeRightOn;
            CMD_Rolodex["TOGGLE_CHOKE_R_OFF"] = interactor.ToggleChokeRightOff;
            CMD_Rolodex["TOGGLE_REAR_THRUSTERS_ON"] = interactor.ToggleRearThrustersOn;
            CMD_Rolodex["TOGGLE_REAR_THRUSTERS_OFF"] = interactor.ToggleRearThrustersOff;
            CMD_Rolodex["TOGGLE_MAIN_THRUSTERS_L_ON"] = interactor.ToggleMainThrustersLeftOn;
            CMD_Rolodex["TOGGLE_MAIN_THRUSTERS_L_OFF"] = interactor.ToggleMainThrustersLeftOff;
            CMD_Rolodex["TOGGLE_MAIN_THRUSTERS_R_ON"] = interactor.ToggleMainThrustersRightOn;
            CMD_Rolodex["TOGGLE_MAIN_THRUSTERS_R_OFF"] = interactor.ToggleMainThrustersRightOff;
            CMD_Rolodex["TOGGLE_SYSTEM_ALERTS_ON"] = interactor.ToggleAlertsOn;
            CMD_Rolodex["TOGGLE_SYSTEM_ALERTS_OFF"] = interactor.ToggleAlertsOff;
            CMD_Rolodex["TOGGLE_DRIVE_ASSIST"] = interactor.ToggleDriveAssist;
            CMD_Rolodex["TOGGLE_MAGLOCK"] = interactor.ToggleMaglock;

            RET_Rolodex["GET_SPEEDOMETER"] = data_collector.GetSpeedometer;
            RET_Rolodex["GET_FUEL_LEVEL"] = data_collector.GetFuelLevel;
            RET_Rolodex["GET_OXYGEN_LEVEL"] = data_collector.GetOxygenLevel;
            RET_Rolodex["GET_CORE_POWER_LEVEL_1"] = data_collector.GetCorePowerLevel_1;
            RET_Rolodex["GET_CORE_POWER_LEVEL_2"] = data_collector.GetCorePowerLevel_2;
            RET_Rolodex["GET_SUIT_POWER_LEVEL"] = data_collector.GetSuitPowerLevel;
            RET_Rolodex["GET_GRAVITY_POWER_LEVEL"] = data_collector.GetGravityPowerLevel;
            RET_Rolodex["GET_LIFE_SUPPORT_POWER_LEVEL"] = data_collector.GetLifeSupportPowerLevel;
            RET_Rolodex["GET_MAGLOCK_POWER_LEVEL_1"] = data_collector.GetMaglockPowerLevel_1;
            RET_Rolodex["GET_MAGLOCK_POWER_LEVEL_2"] = data_collector.GetMaglockPowerLevel_2;
            RET_Rolodex["GET_AIR_FILTER_STATUS_R1"] = data_collector.GetAirFilter_R1;
            RET_Rolodex["GET_AIR_FILTER_STATUS_R2"] = data_collector.GetAirFilter_R2;
            RET_Rolodex["GET_AIR_FILTER_STATUS_L1"] = data_collector.GetAirFilter_L1;
            RET_Rolodex["GET_AIR_FILTER_STATUS_L2"] = data_collector.GetAirFilter_L2;
            RET_Rolodex["GET_CRUISE_CONTROL_SPEED"] = data_collector.GetCruiseControlSpeed;
            RET_Rolodex["GET_CRUISE_CONTROL_STATUS"] = data_collector.GetCruiseControlStatus;
            RET_Rolodex["GET_HEADLIGHT_STATUS"] = data_collector.GetHeadLightsStatus;
            RET_Rolodex["GET_AUXLIGHT_STATUS"] = data_collector.GetAuxLightsStatus;
            RET_Rolodex["GET_ROOFLIGHT_STATUS"] = data_collector.GetRoofLightsStatus;
            RET_Rolodex["GET_FRONTLIGHT_STATUS"] = data_collector.GetFrontLightsStatus;
            RET_Rolodex["GET_LOWERLIGHT_STATUS"] = data_collector.GetLowerLightsStatus;
            RET_Rolodex["GET_UPPERLIGHT_STATUS"] = data_collector.GetUpperLightsStatus;
            RET_Rolodex["GET_CIRCUIT_GRAVITY_STATUS"] = data_collector.GetCircuitBreakerGravityState;
            RET_Rolodex["GET_CIRCUIT_SHIELD_STATUS"] = data_collector.GetCircuitBreakerShieldState;
            RET_Rolodex["GET_CIRCUIT_TEMP_STATUS"] = data_collector.GetCircuitBreakerTempState;
            RET_Rolodex["GET_CIRCUIT_OXYGEN_STATUS"] = data_collector.GetCircuitBreakerOxygenState;
            RET_Rolodex["GET_CIRCUIT_MAGLOCK_STATUS"] = data_collector.GetCircuitBreakerMaglockState;
            RET_Rolodex["GET_CIRCUIT_CORE_STATUS"] = data_collector.GetCircuitBreakerCoreState;
            RET_Rolodex["GET_CIRCUIT_SUIT_STATUS"] = data_collector.GetCircuitBreakerSuitState;
            RET_Rolodex["GET_THRUSTER_TEMP_L"] = data_collector.GetThrusterTempLeft;
            RET_Rolodex["GET_THRUSTER_TEMP_R"] = data_collector.GetThrusterTempRight;
            RET_Rolodex["GET_DRIVE_ASSIST_STATUS"] = data_collector.GetDriveAssistStatus;
            RET_Rolodex["GET_MAGLOCK_STATUS"] = data_collector.GetMaglockStatus;
        }

        public void ChannelMapper_RET(int channel, Func<float> action, Type? type = null)
        {
            if (type == typeof(bool))
            {
                Channels[channel] = (action: () => CastToBool(action), name: action.Method.Name);
            }
            else if (type == typeof(int))
            {
                Channels[channel] = (action: () => CastToInt(action), name: action.Method.Name);
            }
            else if (type == typeof(string))
            {
                Channels[channel] = (action: () => CastToString(action), name: action.Method.Name);
            }
            else
            {
                Channels[channel] = (action: () => CastToFloat(action), name: action.Method.Name);
            }
        }

        public void ChannelMapper_CMD(int channel, Func<string> action)
        {
            Channels[channel] = (action: () => action(), name: action.Method.Name);
        }
    }
}
