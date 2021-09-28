using System;
using System.Text.Json;

namespace Thunder.WebView.Windows
{
    public static class JsonElementExtensions
    {
        public static Object ToObject(this JsonElement element, Type resultType)
        {
            var json = element.GetRawText() ?? throw new InvalidOperationException("json cannot be null");
            return JsonSerializer.Deserialize(json, resultType, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }) ?? throw new InvalidOperationException("deserialization results cannot be null");
        }
        public static T ToObject<T>(this JsonElement element)
        {
            var json = element.GetRawText() ?? throw new InvalidOperationException("json cannot be null");
            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }) ?? throw new InvalidOperationException("deserialization results cannot be null");
        }
    }
}
