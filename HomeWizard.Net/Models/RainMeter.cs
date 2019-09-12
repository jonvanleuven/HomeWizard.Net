using Newtonsoft.Json;

namespace HomeWizard.Net
{
    public class RainMeter : Device
    {
        public int Model { get; set; }
        public double Mm { get; set; }
        [JsonProperty(PropertyName = "3h")]
        public double _3h { get; set; }
    }
}
