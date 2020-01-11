using System;
using System.ComponentModel;
using System.Reflection;

namespace TangerineCRM.Core.Helpers
{
    public static class Extensions
    {
        public static string GetStringValue(this Enum value)
        {

            Type type = value.GetType();


            FieldInfo fieldInfo = type.GetField(value.ToString());


            DescriptionAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(DescriptionAttribute), false) as DescriptionAttribute[];


            return attribs.Length > 0 ? attribs[0].Description : null;
        }

        public static string GetPolishValue(this bool value)
        {
            return value ? "Tak" : "Nie";
        }
    }
}
