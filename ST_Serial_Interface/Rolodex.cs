namespace ST_Serial_Interface
{
    internal class Rolodex
    {
        public Dictionary<string, Func<string>> CMD_Rolodex = new();
        public Dictionary<string, Func<float>> RET_Rolodex = new();
        public Dictionary<int, (Func<object> action, string name)> Channels = new();

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
            CMD_Rolodex["TOGGLE_HEADLIGHTS_ON"] = Interactor.ToggleHeadLightsOn;
            CMD_Rolodex["TOGGLE_HEADLIGHTS_OFF"] = Interactor.ToggleHeadLightsOff;
            CMD_Rolodex["TOGGLE_AUXLIGHTS_ON"] = Interactor.ToggleAuxLightsOn;
            CMD_Rolodex["TOGGLE_AUXLIGHTS_OFF"] = Interactor.ToggleAuxLightsOff;
            CMD_Rolodex["TOGGLE_ROOFLIGHTS_ON"] = Interactor.ToggleRoofLightsOn;
            CMD_Rolodex["TOGGLE_ROOFLIGHTS_OFF"] = Interactor.ToggleRoofLightsOff;
            CMD_Rolodex["TOGGLE_FRONTLIGHTS_ON"] = Interactor.ToggleFrontLightsOn;
            CMD_Rolodex["TOGGLE_FRONTLIGHTS_OFF"] = Interactor.ToggleFrontLightsOff;
            CMD_Rolodex["TOGGLE_LOWERLIGHTS_ON"] = Interactor.ToggleLowerLightsOn;
            CMD_Rolodex["TOGGLE_LOWERLIGHTS_OFF"] = Interactor.ToggleLowerLightsOff;
            CMD_Rolodex["TOGGLE_UPPERLIGHTS_ON"] = Interactor.ToggleUpperLightsOn;
            CMD_Rolodex["TOGGLE_UPPERLIGHTS_OFF"] = Interactor.ToggleUpperLightsOff;
            CMD_Rolodex["TOGGLE_CIRCUIT_GRAVITY_ON"] = Interactor.ToggleCircuitBreakerGravityOn;
            CMD_Rolodex["TOGGLE_CIRCUIT_GRAVITY_OFF"] = Interactor.ToggleCircuitBreakerGravityOff;
            CMD_Rolodex["TOGGLE_CIRCUIT_SHIELD_ON"] = Interactor.ToggleCircuitBreakerShieldOn;
            CMD_Rolodex["TOGGLE_CIRCUIT_SHIELD_OFF"] = Interactor.ToggleCircuitBreakerShieldOff;
            CMD_Rolodex["TOGGLE_CIRCUIT_TEMP_ON"] = Interactor.ToggleCircuitBreakerTempOn;
            CMD_Rolodex["TOGGLE_CIRCUIT_TEMP_OFF"] = Interactor.ToggleCircuitBreakerTempOff;
            CMD_Rolodex["TOGGLE_CIRCUIT_OXYGEN_ON"] = Interactor.ToggleCircuitBreakerOxygenOn;
            CMD_Rolodex["TOGGLE_CIRCUIT_OXYGEN_OFF"] = Interactor.ToggleCircuitBreakerOxygenOff;
            CMD_Rolodex["TOGGLE_CIRCUIT_MAGLOCK_ON"] = Interactor.ToggleCircuitBreakerMaglockOn;
            CMD_Rolodex["TOGGLE_CIRCUIT_MAGLOCK_OFF"] = Interactor.ToggleCircuitBreakerMaglockOff;
            CMD_Rolodex["TOGGLE_CIRCUIT_CORE_ON"] = Interactor.ToggleCircuitBreakerCoreOn;
            CMD_Rolodex["TOGGLE_CIRCUIT_CORE_OFF"] = Interactor.ToggleCircuitBreakerCoreOff;
            CMD_Rolodex["TOGGLE_CIRCUIT_SUIT_ON"] = Interactor.ToggleCircuitBreakerSuitOn;
            CMD_Rolodex["TOGGLE_CIRCUIT_SUIT_OFF"] = Interactor.ToggleCircuitBreakerSuitOff;
            CMD_Rolodex["TOGGLE_HORN_ON"] = Interactor.ToggleHornOn;
            CMD_Rolodex["TOGGLE_HORN_OFF"] = Interactor.ToggleHornOff;
            CMD_Rolodex["TOGGLE_SHUTTERS"] = Interactor.ToggleShutters;
            CMD_Rolodex["TOGGLE_CRUISE_CONTROL"] = Interactor.ToggleCruiseControl;
            CMD_Rolodex["INCREASE_CRUISE_CONTROL"] = Interactor.IncreaseCruiseControl;
            CMD_Rolodex["DECREASE_CRUISE_CONTROL"] = Interactor.DecreaseCruiseControl;
            CMD_Rolodex["TOGGLE_CHOKE_L_ON"] = Interactor.ToggleChokeLeftOn;
            CMD_Rolodex["TOGGLE_CHOKE_L_OFF"] = Interactor.ToggleChokeLeftOff;
            CMD_Rolodex["TOGGLE_CHOKE_R_ON"] = Interactor.ToggleChokeRightOn;
            CMD_Rolodex["TOGGLE_CHOKE_R_OFF"] = Interactor.ToggleChokeRightOff;
            CMD_Rolodex["TOGGLE_REAR_THRUSTERS_ON"] = Interactor.ToggleRearThrustersOn;
            CMD_Rolodex["TOGGLE_REAR_THRUSTERS_OFF"] = Interactor.ToggleRearThrustersOff;
            CMD_Rolodex["TOGGLE_MAIN_THRUSTERS_L_ON"] = Interactor.ToggleMainThrustersLeftOn;
            CMD_Rolodex["TOGGLE_MAIN_THRUSTERS_L_OFF"] = Interactor.ToggleMainThrustersLeftOff;
            CMD_Rolodex["TOGGLE_MAIN_THRUSTERS_R_ON"] = Interactor.ToggleMainThrustersRightOn;
            CMD_Rolodex["TOGGLE_MAIN_THRUSTERS_R_OFF"] = Interactor.ToggleMainThrustersRightOff;
            CMD_Rolodex["TOGGLE_SYSTEM_ALERTS_ON"] = Interactor.ToggleAlertsOn;
            CMD_Rolodex["TOGGLE_SYSTEM_ALERTS_OFF"] = Interactor.ToggleAlertsOff;
            CMD_Rolodex["TOGGLE_DRIVE_ASSIST"] = Interactor.ToggleDriveAssist;
            CMD_Rolodex["TOGGLE_MAGLOCK"] = Interactor.ToggleMaglock;
            CMD_Rolodex["TOGGLE_EMERGENCY_BRAKE_ON"] = Interactor.ToggleEmergencyBrakeOn;
            CMD_Rolodex["TOGGLE_EMERGENCY_BRAKE_OFF"] = Interactor.ToggleEmergencyBrakeOff;
            CMD_Rolodex["TOGGLE_WARP_LEVER"] = Interactor.ToggleWarpLever;
            CMD_Rolodex["SWITCH_TEMP_DIAL"] = Interactor.SwitchTempDial;
            CMD_Rolodex["SWITCH_BLOWER_DIAL"] = Interactor.SwitchBlowerDial;
            CMD_Rolodex["SET_TEMP_DIAL_0"] = Interactor.SetTempDial_0;
            CMD_Rolodex["SET_TEMP_DIAL_1"] = Interactor.SetTempDial_1;
            CMD_Rolodex["SET_TEMP_DIAL_2"] = Interactor.SetTempDial_2;
            CMD_Rolodex["SET_TEMP_DIAL_3"] = Interactor.SetTempDial_3;
            CMD_Rolodex["SET_TEMP_DIAL_4"] = Interactor.SetTempDial_4;
            CMD_Rolodex["SET_BLOWER_DIAL_0"] = Interactor.SetBlowerDial_0;
            CMD_Rolodex["SET_BLOWER_DIAL_1"] = Interactor.SetBlowerDial_1;
            CMD_Rolodex["SET_BLOWER_DIAL_2"] = Interactor.SetBlowerDial_2;
            CMD_Rolodex["SET_BLOWER_DIAL_3"] = Interactor.SetBlowerDial_3;
            CMD_Rolodex["SET_BLOWER_DIAL_4"] = Interactor.SetBlowerDial_4;

            RET_Rolodex["GET_SPEEDOMETER_MPH"] = DataCollector.GetSpeedometerMPH;
            RET_Rolodex["GET_SPEEDOMETER_KPH"] = DataCollector.GetSpeedometerKPH;
            RET_Rolodex["GET_FUEL_LEVEL"] = DataCollector.GetFuelLevel;
            RET_Rolodex["GET_OXYGEN_LEVEL"] = DataCollector.GetOxygenLevel;
            RET_Rolodex["GET_CORE_POWER_LEVEL_1"] = DataCollector.GetCorePowerLevel_1;
            RET_Rolodex["GET_CORE_POWER_LEVEL_2"] = DataCollector.GetCorePowerLevel_2;
            RET_Rolodex["GET_SUIT_POWER_LEVEL"] = DataCollector.GetSuitPowerLevel;
            RET_Rolodex["GET_GRAVITY_POWER_LEVEL"] = DataCollector.GetGravityPowerLevel;
            RET_Rolodex["GET_LIFE_SUPPORT_POWER_LEVEL"] = DataCollector.GetLifeSupportPowerLevel;
            RET_Rolodex["GET_MAGLOCK_POWER_LEVEL_1"] = DataCollector.GetMaglockPowerLevel_1;
            RET_Rolodex["GET_MAGLOCK_POWER_LEVEL_2"] = DataCollector.GetMaglockPowerLevel_2;
            RET_Rolodex["GET_AIR_FILTER_STATUS_R1"] = DataCollector.GetAirFilter_R1;
            RET_Rolodex["GET_AIR_FILTER_STATUS_R2"] = DataCollector.GetAirFilter_R2;
            RET_Rolodex["GET_AIR_FILTER_STATUS_L1"] = DataCollector.GetAirFilter_L1;
            RET_Rolodex["GET_AIR_FILTER_STATUS_L2"] = DataCollector.GetAirFilter_L2;
            RET_Rolodex["GET_CRUISE_CONTROL_SPEED"] = DataCollector.GetCruiseControlSpeed;
            RET_Rolodex["GET_CRUISE_CONTROL_STATUS"] = DataCollector.GetCruiseControlStatus;
            RET_Rolodex["GET_HEADLIGHT_STATUS"] = DataCollector.GetHeadLightsStatus;
            RET_Rolodex["GET_AUXLIGHT_STATUS"] = DataCollector.GetAuxLightsStatus;
            RET_Rolodex["GET_ROOFLIGHT_STATUS"] = DataCollector.GetRoofLightsStatus;
            RET_Rolodex["GET_FRONTLIGHT_STATUS"] = DataCollector.GetFrontLightsStatus;
            RET_Rolodex["GET_LOWERLIGHT_STATUS"] = DataCollector.GetLowerLightsStatus;
            RET_Rolodex["GET_UPPERLIGHT_STATUS"] = DataCollector.GetUpperLightsStatus;
            RET_Rolodex["GET_CIRCUIT_GRAVITY_STATUS"] = DataCollector.GetCircuitBreakerGravityState;
            RET_Rolodex["GET_CIRCUIT_SHIELD_STATUS"] = DataCollector.GetCircuitBreakerShieldState;
            RET_Rolodex["GET_CIRCUIT_TEMP_STATUS"] = DataCollector.GetCircuitBreakerTempState;
            RET_Rolodex["GET_CIRCUIT_OXYGEN_STATUS"] = DataCollector.GetCircuitBreakerOxygenState;
            RET_Rolodex["GET_CIRCUIT_MAGLOCK_STATUS"] = DataCollector.GetCircuitBreakerMaglockState;
            RET_Rolodex["GET_CIRCUIT_CORE_STATUS"] = DataCollector.GetCircuitBreakerCoreState;
            RET_Rolodex["GET_CIRCUIT_SUIT_STATUS"] = DataCollector.GetCircuitBreakerSuitState;
            RET_Rolodex["GET_THRUSTER_TEMP_L"] = DataCollector.GetThrusterTempLeft;
            RET_Rolodex["GET_THRUSTER_TEMP_R"] = DataCollector.GetThrusterTempRight;
            RET_Rolodex["GET_DRIVE_ASSIST_STATUS"] = DataCollector.GetDriveAssistStatus;
            RET_Rolodex["GET_MAGLOCK_STATUS"] = DataCollector.GetMaglockStatus;
            RET_Rolodex["GET_EMERGENCY_BRAKE_STATUS"] = DataCollector.GetEmergencyBrakeStatus;
            RET_Rolodex["GET_WARP_STATUS"] = DataCollector.GetWarpStatus;
            RET_Rolodex["GET_EXTERNAL_TEMP_F"] = DataCollector.GetExternalTempFah;
            RET_Rolodex["GET_EXTERNAL_TEMP_C"] = DataCollector.GetExternalTempCel;
            RET_Rolodex["GET_INTERNAL_TEMP_F"] = DataCollector.GetInternalTempFah;
            RET_Rolodex["GET_INTERNAL_TEMP_C"] = DataCollector.GetInternalTempCel;
            RET_Rolodex["GET_PLAYER_TEMP_COMF"] = DataCollector.GetPlayerComfortableTemp;
            RET_Rolodex["GET_PLAYER_TEMP_SAFE"] = DataCollector.GetPlayerSafeTemp;
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
