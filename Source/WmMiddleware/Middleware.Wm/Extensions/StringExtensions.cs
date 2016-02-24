using System;
using System.Globalization;

namespace Middleware.Wm.Extensions
{
    public static class StringExtensions
    {
        public static char ConvertIntegerToCharacter(this string value)
        {
            const string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var integer = int.Parse(value);
            return digits[integer];
        }

        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        public static string GetSeasonYear(this string style)
        {
            if (string.IsNullOrEmpty(style) || style.Length <= 2)
            {
                return style;
            }

            return style.Substring(0, 2);
        }

        public static string GetStyle(this string style)
        {
            if (string.IsNullOrEmpty(style) || style.Length <= 2)
            {
                return string.Empty;
            }

            return style.Substring(2);
        }
    }
}
