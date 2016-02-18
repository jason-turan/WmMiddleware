using System;
using System.Globalization;

namespace Middleware.Wm.Manhattan.Extensions
{
    public static class StringExtensions
    {
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
