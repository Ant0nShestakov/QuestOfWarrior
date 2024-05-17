using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using UnityEngine;

public class ScriptableObjectConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return typeof(ScriptableObject).IsAssignableFrom(objectType);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null)
            return null;

        JObject jsonObject = JObject.Load(reader);
        ScriptableObject scriptableObject = ScriptableObject.CreateInstance(objectType);
        serializer.Populate(jsonObject.CreateReader(), scriptableObject);
        return scriptableObject;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        if (value == null)
        {
            writer.WriteNull();
            return;
        }

        JObject jsonObject = JObject.FromObject(value, serializer);
        jsonObject.WriteTo(writer);
    }
}

