using System;
using System.ComponentModel;

namespace WEBUIautomation.Extensions
{
    public static partial class Extensions
    {
        public static string GetEnumDescription(this Enum value)
        {
            var fieldName = value.ToString();
            var fieldInfo = value.GetType().GetField(fieldName);
            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : fieldName;
        }

        public static T GetEnumFromString<T>(string strValue) where T : struct, IConvertible
        {
            return (T)Enum.Parse(typeof(T), strValue);
        }
    }

}
