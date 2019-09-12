using HomeWizard.Net.Converters;
using Newtonsoft.Json;

namespace HomeWizard.Net
{
    public class LoginResponse
    {
        [JsonProperty("serial")]
        public string Serial { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("online")]
        [JsonConverter(typeof(BooleanConverter))]
        public bool Online { get; set; }
        [JsonProperty("hops")]
        public int Hops { get; set; }
        [JsonProperty("local")]
        [JsonConverter(typeof(BooleanConverter))]
        public bool Local { get; set; }
    }
}