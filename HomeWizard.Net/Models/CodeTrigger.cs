using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HomeWizard.Net
{
    public class CodeTrigger : Trigger
    {
        public string Code { get; set; }
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public IList<Preset> Presets { get; set; } 
    }
}
