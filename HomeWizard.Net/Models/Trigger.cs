using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using HomeWizard.Net.Converters;

namespace HomeWizard.Net
{
    public abstract class Trigger
    {
        public long? Id { get; set; }
        public virtual TriggerType Type { get; set; }
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public IList<Day> Days { get; set; } 
        public IList<Action> Actions { get; set; }
        public TriggerNotification Notification { get; set; }
        [JsonConverter(typeof(BooleanConverter))]
        public bool Active { get; set; }

        public class Action
        {
            public long? Id { get; set; }
            public string DeviceType { get; set; }
            public long DeviceId { get; set; }
            public string Value { get; set; } //on|off for switch, 0-100 for dimmer, decimal for heatlink
            public int OffTime { get; set; } //turn off after x minutes
            public Preset? Preset { get; set; }
        }

        public class TriggerNotification
        {
            public IList<int> Receivers { get; set; }
            public long SoundId { get; set; }
        }
    }
}
