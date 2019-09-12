using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeWizard.Net
{
    public interface IHomeWizardClient
    {
        bool IsLocal { get; }
        Task<Discovery> Discover();
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
        Task<Sensors> GetStatus();
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
        Task DimSwitch(long id, int level);
        Task SomfyUp(long id);
        Task SomfyDown(long id);
        Task<long> AddSwitch(string name, SwitchType type, string code);
        Task EditSwitch(long id, string name, SwitchType type);
        Task RemoveSwitch(long id);
        Task RemoveTrigger(long id);
        Task SetTargetTemperature(long id, decimal temperature, int? minutes = null);
        Task SetPresetTemperatures(long id, string code, decimal home, decimal away, decimal comfort, decimal sleep);
        Task<IList<GraphData>> GetGraphMonths();
        Task<IList<GraphData>> GetGraphDays();
        Task<IList<Reading>> GetReadings();
        Task<IList<NotificationReceiver>> GetNotificationReceivers();
    }
}
