namespace HomeWizard.Net
{
    public class DeviceTrigger : Trigger
    {
        public KakuSensorType SensorType { get; set; }
        public int SensorId { get; set; }
        public int Event { get; set; }
        public YesNo CheckOnStart { get; set; }
    }
}