using HomeWizard.Net.Converters;
using Newtonsoft.Json;

namespace HomeWizard.Net
{
    public class KakuSensor : Device
    {
        [JsonConverter(typeof(BooleanConverter))]
        public bool Status { get; set; }
        public string TimeStamp { get; set; }
        public KakuSensorType Type { get; set; }
        public string CameraId { get; set; }
    }
}
