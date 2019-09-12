using HomeWizard.Net.Converters;
using Newtonsoft.Json;

namespace HomeWizard.Net
{
    public class KakuSensor : Device
    {
        [JsonConverter(typeof(BooleanConverter))]
        public bool Status { get; set; }
        public string TimeStamp { get; set; }
    }
}
