using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GuildfordBoroughCouncil.Json.Converters
{
    public class LongToStringConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return JValue.ReadFrom(reader).Value<long>();
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(long).Equals(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.ToString());
        }
    }

    public class ObjectToStringConverter<T> : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return JValue.ReadFrom(reader).Value<T>();
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(T).Equals(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.ToString());
        }
    }
}