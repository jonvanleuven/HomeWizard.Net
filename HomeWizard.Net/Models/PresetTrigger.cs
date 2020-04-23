using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HomeWizard.Net
{
    public class PresetTrigger : Trigger
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Preset Preset { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
