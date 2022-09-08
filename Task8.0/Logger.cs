using System.Reflection;

namespace Task8._0
{
    public class Logger
    {
        public static void Track<T>(string name, T item)
        {
            Type _type = typeof(T);

            if (item == null)
            {
                throw new ArgumentNullException();
            }

            if (_type.GetCustomAttribute<TrackingEntityAttribute>() != null)
            {
                Dictionary<string, string> _data = new();

                var flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

                var properties = _type.GetProperties(flags);
                var fields = _type.GetFields(flags);

                AttributeCheck(_data, properties, item);
                AttributeCheck(_data, fields, item);
                new JsonGenerator(name, _data);
            }
        }

        private static void AttributeCheck(Dictionary<string, string> data, dynamic info, dynamic item)
        {
            foreach (var inf in info)
            {
                TrackingPropertyAttribute MyAttribute = (TrackingPropertyAttribute)Attribute.GetCustomAttribute(inf, typeof(TrackingPropertyAttribute));

                if (MyAttribute != null)
                {
                    data.Add(MyAttribute.PropertyName ?? inf.Name, inf.GetValue(item)?.ToString() ?? "");
                }
            }
        }
    }
}

