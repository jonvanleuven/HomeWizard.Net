using Newtonsoft.Json.Linq;
using System;

namespace HomeWizard.Net.Converters
{
    internal class TriggerConverter : JsonCreationConverter<Trigger>
    {
        protected override Trigger Create(Type objectType, JObject jObject)
        {
            if (FieldExists("type", jObject))
            {
                string typeText = jObject["type"].ToString();
                if (typeText == "preset" || typeText == ((int)TriggerType.Preset).ToString())
                    return new PresetTrigger();
                if (typeText == "time" || typeText == ((int)TriggerType.Time).ToString())
                    return new TimeTrigger();
                if (typeText == "code" || typeText == ((int)TriggerType.Code).ToString())
                    return new CodeTrigger();
                if (typeText == "device" || typeText == ((int)TriggerType.Device).ToString())
                    return new DeviceTrigger();
                throw new Exception($"cannot parse Trigger: invalid type {typeText}");

            }
            throw new Exception("cannot parse Trigger: no type available");
        }
    }
}
