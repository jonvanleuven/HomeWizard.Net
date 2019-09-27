using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HomeWizard.Net
{
    public class Switch : Device
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public SwitchType Type { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public OnOff Status { get; set; }
        public int OnStatus { get; set; }
        public int OffStatus { get; set; }
        public string Code { get; set; }
    }

    public static class SwitchExtensions
    {
        public static bool IsDimmer(this Switch s)
        {
            return s.Type == SwitchType.Dimmer;
        }

        public static bool IsHue(this Switch s)
        {
            return s.Type == SwitchType.Hue;
        }

        public static bool IsSomfy(this Switch s)
        {
            return s.Type == SwitchType.Somfy;
        }

        public static bool IsVirtual(this Switch s)
        {
            return s.Type == SwitchType.Virtual;
        }
    }
}
