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

        public dynamic? Bind(string typeName, Dictionary<string, string> dictionary)
        {
            var type = TypeCheck(typeName);

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
                                member.SetValue(result, Int32.Parse(data.Value));
                                break;
                            case "Double":
                                member.SetValue(result, Double.Parse(data.Value));
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

        private static Type TypeCheck(string typeName)
        {
            if (String.IsNullOrEmpty(typeName))
            {
                throw new ArgumentException();
            }

            var type = Type.GetType(typeName);

            if (type == null)
            {
                throw new ArgumentNullException("This type does not exist", nameof(type));
            }

            if (type.GetConstructor(Type.EmptyTypes) == null)
            {
                throw new ArgumentOutOfRangeException(nameof(type), "Must have constructor without parameters");
            }

            return type;
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

