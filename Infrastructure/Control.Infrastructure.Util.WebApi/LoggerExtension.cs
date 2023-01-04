using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Text.Json;
using System.Xml;

namespace Control.Infrastructure.Util.WebApi
{
    public static class LoggerExtension
    {
        public static void LogMethodInfo(this ILogger<object> logger, MethodBase method, params object[] values)
        {
            ParameterInfo[] parms = method.GetParameters();
            object[] namevalues = new object[2 * parms.Length];

            string msg = $"Ejecutando el método {method.Name} de la clase {method.ReflectedType.Name} (";

            for (int i = 0, j = 0; i < parms.Length; i++, j += 2)
            {
                msg += "{" + j + "}={" + (j + 1) + "}, ";
                namevalues[j] = parms[i].Name;

                if (i < values.Length)
                {
                    var stringValue = values[i].StringRepresentation();
                    namevalues[j + 1] = stringValue;
                }
            }
            msg += ")";
            msg = msg.ReplaceLast(", ", "");
            logger.LogInformation(string.Format(msg, namevalues));
        }

        public static void LogReturn(this ILogger<object> logger, object dto)
        {
            string msg = string.Format("Método ejecutado correctamente (result = {0})",
                                        dto.StringRepresentation());
            logger.LogInformation(msg);
        }

        public static string StringRepresentation(this object myObject)
        {
            if (myObject == null)
            {
                return string.Empty;
            }
            else if (IntrospectionExtensions.GetTypeInfo(myObject.GetType()).IsSimple())
            {
                return myObject.ToString();
            }
            else
            {
                return JsonSerializer.Serialize(myObject);
            }
        }

        private static bool IsSimple(this TypeInfo type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                // nullable type, check if the nested type is simple.
                return IsSimple((type.GetGenericArguments()[0]).GetTypeInfo());
            }
            return type.IsPrimitive
                || type.IsEnum
                || type.Equals(typeof(string))
                || type.Equals(typeof(decimal));
        }

        private static string ReplaceLast(this string str, string find, string replace)
        {
            int lastIndex = str.LastIndexOf(find);

            if (lastIndex == -1)
            {
                return str;
            }

            string beginString = str.Substring(0, lastIndex);
            string endString = str.Substring(lastIndex + find.Length);

            return beginString + replace + endString;
        }
    }
}
