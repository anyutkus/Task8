using System.Reflection;

namespace Task8._2
{
    public sealed class SimpleBinder
    {
        private static readonly SimpleBinder _instance = new SimpleBinder();

        private SimpleBinder()
        {
        }

        public static SimpleBinder GetInstance
        {
            get => _instance;
        }

        public dynamic? Bind<T>(Dictionary<string, string> dictionary) where T : new()
        {
            var type = typeof(T);

            if (dictionary is null)
            {
                throw new ArgumentNullException();
            }

            var result = Activator.CreateInstance(type);

            var flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.IgnoreCase;

            try
            {
                foreach (var data in dictionary)
                {
                    var propInfo = type.GetProperty(data.Key, flags);
                    var fieldInfo = type.GetField(data.Key, flags);

                    var memberType = propInfo?.PropertyType.Name ?? fieldInfo?.FieldType.Name;
                    var member = GetNotNullMember(propInfo, fieldInfo);

                    if (member is not null)
                    {
                        switch (memberType)
                        {
                            case "String":
                                member.SetValue(result, data.Value);
                                break;
                            case "Int32":
                                member.SetValue(result, int.Parse(data.Value));
                                break;
                            case "Double":
                                member.SetValue(result, double.Parse(data.Value));
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return result;
        }

        private static dynamic? GetNotNullMember(PropertyInfo? propertyInfo, FieldInfo? fieldInfo)
        {
            if (propertyInfo is not null)
            {
                return propertyInfo;
            }

            if (fieldInfo is not null)
            {
                return fieldInfo;
            }

            return null;
        }
    }
}

