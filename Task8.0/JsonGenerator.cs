using System.Text.Json;

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

            if ((name.Length < 5) || (name[^5..] != ".json"))
            {
                name += ".json";
            }

            var json = JsonSerializer.Serialize(data, options);

            new JsonWriter(name, json);
        }
    }
}

