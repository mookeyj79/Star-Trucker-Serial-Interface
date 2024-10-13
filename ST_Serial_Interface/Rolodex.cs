using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ST_Serial_Interface
{
    internal class Rolodex
    {
        public Dictionary<string, Delegate> CMD_Rolodex = new();
        public Dictionary<string, Delegate> RBOOL_Rolodex = new();
        public Dictionary<string, Delegate> RINT_Rolodex = new();
        public Dictionary<string, Delegate> RFLT_Rolodex = new();
        public Dictionary<int, Delegate> Channels = new();

        private readonly Interactor interactor = new();
        private readonly DataCollector data_collector = new();

        public void FunctionMapper()
        {
            CMD_Rolodex["TOGGLE_HEADLIGHTS_ON"] = new Func<string>(interactor.ToggleHeadLightsOn);
            CMD_Rolodex["TOGGLE_HEADLIGHTS_OFF"] = new Func<string>(interactor.ToggleHeadLightsOff);
            CMD_Rolodex["TOGGLE_AUXLIGHTS_ON"] = new Func<string>(interactor.ToggleAuxLightsOn);
            CMD_Rolodex["TOGGLE_AUXLIGHTS_OFF"] = new Func<string>(interactor.ToggleAuxLightsOff);
            CMD_Rolodex["TOGGLE_ROOFLIGHTS_ON"] = new Func<string>(interactor.ToggleRoofLightsOn);
            CMD_Rolodex["TOGGLE_ROOFLIGHTS_OFF"] = new Func<string>(interactor.ToggleRoofLightsOff);
            CMD_Rolodex["TOGGLE_FRONTLIGHTS_ON"] = new Func<string>(interactor.ToggleFrontLightsOn);
            CMD_Rolodex["TOGGLE_FRONTLIGHTS_OFF"] = new Func<string>(interactor.ToggleFrontLightsOff);
            CMD_Rolodex["TOGGLE_LOWERLIGHTS_ON"] = new Func<string>(interactor.ToggleLowerLightsOn);
            CMD_Rolodex["TOGGLE_LOWERLIGHTS_OFF"] = new Func<string>(interactor.ToggleLowerLightsOff);
            CMD_Rolodex["TOGGLE_UPPERLIGHTS_ON"] = new Func<string>(interactor.ToggleUpperLightsOn);
            CMD_Rolodex["TOGGLE_UPPERLIGHTS_OFF"] = new Func<string>(interactor.ToggleUpperLightsOff);
            CMD_Rolodex["TOGGLE_HORN_ON"] = new Func<string>(interactor.ToggleHornOn);
            CMD_Rolodex["TOGGLE_HORN_OFF"] = new Func<string>(interactor.ToggleHornOff);
            CMD_Rolodex["TOGGLE_SHUTTERS"] = new Func<string>(interactor.ToggleShutters);

            RINT_Rolodex["GET_SPEEDOMETER"] = new Func<int>(data_collector.GetSpeedometer_INT);
            RINT_Rolodex["GET_FUEL_LEVEL"] = new Func<int>(data_collector.GetFuelLevel_INT);
            RINT_Rolodex["GET_OXYGEN_LEVEL"] = new Func<int>(data_collector.GetOxygenLevel_INT);
            RINT_Rolodex["GET_CORE_POWER_LEVEL_C1"] = new Func<int>(data_collector.GetCorePowerLevel_C1_INT);
            RINT_Rolodex["GET_CORE_POWER_LEVEL_C2"] = new Func<int>(data_collector.GetCorePowerLevel_C2_INT);
            RINT_Rolodex["GET_SUIT_POWER_LEVEL"] = new Func<int>(data_collector.GetSuitPowerLevel_INT);
            RINT_Rolodex["GET_GRAVITY_POWER_LEVEL"] = new Func<int>(data_collector.GetGravityPowerLevel_INT);
            RINT_Rolodex["GET_LIFE_SUPPORT_POWER_LEVEL"] = new Func<int>(data_collector.GetLifeSupportPowerLevel_INT);
            RINT_Rolodex["GET_MAGLOCK_POWER_LEVEL_A"] = new Func<int>(data_collector.GetMaglockPowerLevel_A_INT);
            RINT_Rolodex["GET_MAGLOCK_POWER_LEVEL_B"] = new Func<int>(data_collector.GetMaglockPowerLevel_B_INT);
            RINT_Rolodex["GET_AIR_FILTER_STATUS_R1"] = new Func<int>(data_collector.GetAirFilter_R1_INT);
            RINT_Rolodex["GET_AIR_FILTER_STATUS_R2"] = new Func<int>(data_collector.GetAirFilter_R2_INT);
            RINT_Rolodex["GET_AIR_FILTER_STATUS_L1"] = new Func<int>(data_collector.GetAirFilter_L1_INT);
            RINT_Rolodex["GET_AIR_FILTER_STATUS_L2"] = new Func<int>(data_collector.GetAirFilter_L2_INT);

            RFLT_Rolodex["GET_SPEEDOMETER"] = new Func<float>(data_collector.GetSpeedometer_FLOAT);
            RFLT_Rolodex["GET_FUEL_LEVEL"] = new Func<float>(data_collector.GetFuelLevel_FLOAT);
            RFLT_Rolodex["GET_OXYGEN_LEVEL"] = new Func<float>(data_collector.GetOxygenLevel_FLOAT);
            RFLT_Rolodex["GET_CORE_POWER_LEVEL_C1"] = new Func<float>(data_collector.GetCorePowerLevel_C1_FLOAT);
            RFLT_Rolodex["GET_CORE_POWER_LEVEL_C2"] = new Func<float>(data_collector.GetCorePowerLevel_C2_FLOAT);
            RFLT_Rolodex["GET_SUIT_POWER_LEVEL"] = new Func<float>(data_collector.GetSuitPowerLevel_FLOAT);
            RFLT_Rolodex["GET_GRAVITY_POWER_LEVEL"] = new Func<float>(data_collector.GetGravityPowerLevel_FLOAT);
            RFLT_Rolodex["GET_LIFE_SUPPORT_POWER_LEVEL"] = new Func<float>(data_collector.GetLifeSupportPowerLevel_FLOAT);
            RFLT_Rolodex["GET_MAGLOCK_POWER_LEVEL_A"] = new Func<float>(data_collector.GetMaglockPowerLevel_A_FLOAT);
            RFLT_Rolodex["GET_MAGLOCK_POWER_LEVEL_B"] = new Func<float>(data_collector.GetMaglockPowerLevel_B_FLOAT);
            RFLT_Rolodex["GET_AIR_FILTER_STATUS_R1"] = new Func<float>(data_collector.GetAirFilter_R1_FLOAT);
            RFLT_Rolodex["GET_AIR_FILTER_STATUS_R2"] = new Func<float>(data_collector.GetAirFilter_R2_FLOAT);
            RFLT_Rolodex["GET_AIR_FILTER_STATUS_L1"] = new Func<float>(data_collector.GetAirFilter_L1_FLOAT);
            RFLT_Rolodex["GET_AIR_FILTER_STATUS_L2"] = new Func<float>(data_collector.GetAirFilter_L2_FLOAT);

            RBOOL_Rolodex["GET_HEADLIGHT_STATUS"] = new Func<bool>(data_collector.GetHeadLightsStatus_BOOL);
            RBOOL_Rolodex["GET_AUXLIGHT_STATUS"] = new Func<bool>(data_collector.GetAuxLightsStatus_BOOL);
            RBOOL_Rolodex["GET_ROOFLIGHT_STATUS"] = new Func<bool>(data_collector.GetRoofLightsStatus_BOOL);
            RBOOL_Rolodex["GET_FRONTLIGHT_STATUS"] = new Func<bool>(data_collector.GetFrontLightsStatus_BOOL);
            RBOOL_Rolodex["GET_LOWERLIGHT_STATUS"] = new Func<bool>(data_collector.GetLowerLightsStatus_BOOL);
            RBOOL_Rolodex["GET_UPPERLIGHT_STATUS"] = new Func<bool>(data_collector.GetUpperLightsStatus_BOOL);
        }

        public void ChannelMapper(int channel, Delegate action)
        {
            Channels[channel] = action;
        }
    }
}
