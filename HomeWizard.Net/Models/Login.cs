using System.Collections.Generic;
using HomeWizard.Net.Converters;
using Newtonsoft.Json;

namespace HomeWizard.Net
{
    public class Login
    {
        [JsonProperty("session")]
        public string Session { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("response")]
        public List<LoginResponse> Response { get; set; }
        [JsonProperty("cloud")]
        [JsonConverter(typeof(BooleanConverter))]
        public bool Cloud { get; set; }
        [JsonProperty("version")]
        public string Version { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
