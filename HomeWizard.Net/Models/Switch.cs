using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HomeWizard.Net
{
    public class Switch : Device
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual SwitchType Type { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public OnOff Status { get; set; }

        public int OnStatus { get; set; }
        public int OffStatus { get; set; }

        public bool IsDimmer
        {
            get { return Type == SwitchType.Dimmer; }
        }

        public bool IsHue
        {
            get { return Type == SwitchType.Hue; }
        }

        public bool IsSomfy
        {
            get { return Type == SwitchType.Somfy; }
        }

        public bool IsVirtual
        {
            get { return Type == SwitchType.Virtual; }
        }
        public string Code { get; set; }
    }
}
