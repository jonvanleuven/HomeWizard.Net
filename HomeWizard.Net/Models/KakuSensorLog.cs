using HomeWizard.Net.Converters;
using Newtonsoft.Json;

namespace HomeWizard.Net
{
    public class KakuSensorLog : Device
    {
        [JsonConverter(typeof(BooleanConverter))]
        public bool Status { get; set; }
        [JsonProperty("t")]
        public string TimeStamp { get; set; }
    }
}
