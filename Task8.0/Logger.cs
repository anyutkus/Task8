using System.Reflection;

namespace Task8._0
{
    public class Logger<T>
    {
        private static readonly Type _type = typeof(T);

        public Logger(string name, T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            if (_type.GetCustomAttribute<TrackingEntityAttribute>() != null)
            {
                new JsonGenerator(name, Track(item));
            }
        }

        public Dictionary<string, string> Track(T item)
        {
            Dictionary<string, string> _data = new();

            var members = _type.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var el in members)
            {
                var attr = el.GetCustomAttribute<TrackingPropertyAttribute>();

                if (attr != null)
                {
                    _data.Add(attr.PropertyName ?? el.Name, GetMemberValue(el, item) ?? "");
                }
            }
            return _data;
        }

        private static string? GetMemberValue(MemberInfo memberInfo, T item)
        {
            switch (memberInfo.MemberType)
            {
                case MemberTypes.Field:
                    return ((FieldInfo)memberInfo).GetValue(item)?.ToString();
                case MemberTypes.Property:
                    return ((PropertyInfo)memberInfo).GetValue(item)?.ToString();
                default:
                    return null;
            }
        }
    }
}

