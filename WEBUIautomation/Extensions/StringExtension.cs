using System;

namespace WEBUIautomation.Extensions
{
    public  static partial class Extensions
    {
        public static bool Contains(this string source, string target, StringComparison stringComparison)
        {
            return source.IndexOf(target, stringComparison) >= 0;
        }

        public static int ToInt(this string source)
        {
            return string.IsNullOrEmpty(source) ? 0 : int.Parse(source);
        }
    }
}
