using System.Text.Json;
using System.IO;

namespace Task8._0
{
    public class JsonGenerator
    {
        public JsonGenerator(string name, object data)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };

            if (!Path.HasExtension($"@{name}"))
            {
                name += ".json";
            }

            var json = JsonSerializer.Serialize(data, options);

            new JsonWriter(name, json);
        }
    }
}

