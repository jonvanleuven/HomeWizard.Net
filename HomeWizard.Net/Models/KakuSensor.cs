using System;
using HomeWizard.Net.Converters;
using Newtonsoft.Json;

namespace HomeWizard.Net
{
    public class KakuSensor : Device
    {
        [JsonConverter(typeof(BooleanConverter))]
        public bool Status { get; set; }
        public string TimeStamp { get; set; }
        public KakuSensorType Type { get; set; }
        public string CameraId { get; set; }
        [JsonConverter(typeof(BooleanConverter))]
        public bool? LowBattery { get; set; }
        public DateTime? LastSeen { get; set; }
    }

    public static class KakuSensorExtensions
    {
        public static bool IsContact(this KakuSensor s)
        {
            return s.Type == KakuSensorType.Contact || s.Type == KakuSensorType.Contact868;
        }
        public static bool IsMotion(this KakuSensor s)
        {
            return s.Type == KakuSensorType.Motion;
        }

        public static bool IsDoorbell(this KakuSensor s)
        {
            return s.Type == KakuSensorType.Doorbell;
        }
        public static bool IsSmoke(this KakuSensor s)
        {
            return s.Type == KakuSensorType.Smoke;
        }
        public static bool IsCamera(this KakuSensor s)
        {
            return s.Type == KakuSensorType.Camera;
        }
    }
}
