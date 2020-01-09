using System;
using System.ComponentModel;
using System.Reflection;

namespace TangerineCRM.Core.Helpers
{
    public static class Extensions
    {
        public static string GetStringValue(this Enum value)
        {
            // Get the type
            Type type = value.GetType();

            // Get fieldinfo for this type
            FieldInfo fieldInfo = type.GetField(value.ToString());

            // Get the stringvalue attributes
            DescriptionAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            // Return the first if there was a match.
            return attribs.Length > 0 ? attribs[0].Description : null;
        }

        public static string GetResultStringValue(this bool value)
        {
            return value ? "Pozytywny" : "Negatywny";
        }
    }
}
