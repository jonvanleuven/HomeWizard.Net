using System;
using Newtonsoft.Json;
using HomeWizard.Net.Converters;

namespace HomeWizard.Net
{
    public class ThermoMeter : Device
    {
        public int Channel { get; set; }
        public int Model { get; set; }
        public string Code { get; set; }

        [JsonProperty("te")]
        public double Temperature { get; set; }
        [JsonProperty("te+")]
        public double HighestTemperature { get; set; }
        [JsonProperty("te+t")]
        public DateTime HighestTemperatureTime { get; set; }
        [JsonProperty("te-")]
        public double LowestTemperature { get; set; }
        [JsonProperty("te-t")]
        public DateTime LowsetTemperatureTime { get; set; }

        [JsonProperty("hu")]
        public int Humidity { get; set; }
        [JsonProperty("hu+")]
        public int HighestHumidity { get; set; }
        [JsonProperty("hu+t")]
        public DateTime HighestHumidityTime { get; set; }
        [JsonProperty("hu-")]
        public int LowestHumidity { get; set; }
        [JsonProperty("hu-t")]
        public DateTime LowestHumidityTime { get; set; }

        [JsonConverter(typeof(BooleanConverter))]
        public bool Outsite { get; set; }
    }
}
