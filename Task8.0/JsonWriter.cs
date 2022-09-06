using System.Text.Json;

namespace Task8._0
{
    public class JsonWriter
    {
        public JsonWriter(string name, string json)
        {
            File.WriteAllText(name, json);
        }
    }
}

