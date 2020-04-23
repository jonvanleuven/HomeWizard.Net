namespace HomeWizard.Net
{
    public class DeviceTrigger : Trigger
    {
        private KakuSensorType SensorType { get; set; }
        private int SensorId { get; set; }
        private int Event { get; set; }
        private YesNo CheckOnStart { get; set; }
    }
}