using Newtonsoft.Json;

namespace HomeWizard.Net
{
    public class TemperatureMinMaxGraphData : GraphData
    {
        [JsonProperty("te-")]
        public decimal TeMin { get; set; }
        [JsonProperty("te+")]
        public decimal TeMax { get; set; }
        [JsonProperty("hu-")]
        public decimal HuMin { get; set; }
        [JsonProperty("hu+")]
        public decimal HuMax { get; set; }
    }
}