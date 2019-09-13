using System;
using Newtonsoft.Json;

namespace HomeWizard.Net
{
    public class TemperatureGraphData
    {
        public DateTime T { get; set; }
        public decimal Te { get; set; }
        public decimal Hu { get; set; }
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