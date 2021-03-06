﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeWizard.Net
{
    public interface IHomeWizardClient
    {
        bool IsLocal { get; }
        Task<bool> IsValidPassword();
        Task<Handshake> GetHandshake();
        Task<SunTimes> GetSunTimesForToday();
        Task<IList<SunTimes>> GetSunTimesForWeek();
        Task<IList<Switch>> GetSwitches();
        Task<IList<ThermoMeter>> GetThermoMeters();
        Task<IList<EnergyMeter>> GetEnergyMeters();
        Task<IList<UvMeter>> GetUvMeters();
        Task<IList<WindMeter>> GetWindMeters();
        Task<IList<RainMeter>> GetRainMeters();
        Task<IList<Scene>> GetScenes();
        Task<Sensors> GetSensors();
        Task<List<KakuSensorLog>> GetKaKuSensorLogs(long id);
        Task<Sensors> GetStatus(); //TODO Status object van maken en niet verkeerd hergebruik van Sensors object met de objecten daarbinnen!
        Task<IList<Trigger>> GetTriggers();
        Task SwitchPreset(Preset preset);
        Task SceneOn(long id);
        Task SceneOff(long id);
        Task<IList<Switch>> GetSceneSwitches(long id);
        Task<IList<string>> GetSwitchCodes(long id);
        Task RemoveSwitchCode(long id, string code);
        Task EditSwitchCode(long id, string oldCode, string newCode);
        Task<string> GenerateSwitchCode();
        Task<string> LearnSwitchCode();
        Task SwitchOn(long id, int? level = null);
        Task SwitchOff(long id);
        Task SwitchOn(string code, int? level = null);
        Task SwitchOff(string code);
        Task DimSwitch(long id, int level);
        Task HueSwitch(long id, int hue, int saturation, int brightness);
        Task SomfyUp(long id);
        Task SomfyDown(long id);
        Task<long> AddSwitch(string name, SwitchType type, string code);
        Task EditSwitch(long id, string name, SwitchType type);
        Task RemoveSwitch(long id);
        Task RemoveTrigger(long id);
        Task SetTargetTemperature(long id, decimal temperature, int? minutes = null);
        Task SetPresetTemperatures(long id, string code, decimal home, decimal away, decimal comfort, decimal sleep);
        Task<IList<EnergyLinkGraphData>> GetGraphEneryLinkDay(long id);
        Task<IList<EnergyLinkGraphData>> GetGraphEneryLinkWeek(long id);
        Task<IList<EnergyLinkGraphData>> GetGraphEneryLinkMonth(long id);
        Task<IList<EnergyLinkGraphData>> GetGraphEneryLinkYear(long id);
        Task<IList<TemperatureGraphData>> GetGraphTemperatureDay(long id);
        Task<IList<TemperatureGraphData>> GetGraphTemperatureWeek(long id);
        Task<IList<TemperatureMinMaxGraphData>> GetGraphTemperatureMonth(long id);
        Task<IList<TemperatureMinMaxGraphData>> GetGraphTemperatureYear(long id);
        Task<IList<Reading>> GetReadings(long id);
        Task<IList<NotificationReceiver>> GetNotificationReceivers();
        Task RemoveNotificationReciever(long id);
        Task<NotificationReceiver> GetNotificationReceiver(long id);
        Task SendTestMessageNotificationReceiver(long id);
    }
}
