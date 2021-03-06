﻿using Newtonsoft.Json;
using System;

namespace HomeWizard.Net.Converters
{
    internal class BooleanConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = reader.Value;
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return false;
            }
            if ("yes".Equals(value.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }

        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(string) || objectType == typeof(bool))
            {
                return true;
            }
            return false;
        }
    }
}
