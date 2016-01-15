using System;
using System.Globalization;

namespace WmMiddleware.Common.Extensions
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

        public static string FromManhattanShoeSize(this string size)
        {
            String padded = size.PadRight(3, '0');
            return padded.Insert(padded.Length - 1, ".").TrimStart('0');
        }

        public static string ToManhattanSize(this string size)
        {
            int intSize;
            if (int.TryParse(size, out intSize))
            {
                return intSize.ToString("D2") + " ";
            }

            decimal numberSize;
            if (decimal.TryParse(size, out numberSize))
            {
                return ((int)(numberSize * 10)).ToString("D3", CultureInfo.InvariantCulture);
            }

            return size;
        }
    }
}
