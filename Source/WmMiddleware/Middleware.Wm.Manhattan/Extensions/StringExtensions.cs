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

        public static string ConvertFromManhattanSize(this string size)
        {
            var retSize = ConvertFromManhattanDecimalSize(size);
            if (retSize != null)
            {
                return retSize;
            }
            
            retSize = size.ToUpperInvariant().Trim();

            switch (retSize)
            {
                case "LXL": retSize = "L/XL"; break;
                case "1SZ": retSize = "OSFA"; break;
                case "OSZ": retSize = "OSFA"; break;
                case "32E": retSize = "32DD"; break;
                case "34E": retSize = "34DD"; break;
                case "36E": retSize = "36DD"; break;
                case "38E": retSize = "38DD"; break;
                case "40E": retSize = "40DD"; break;
                case "42E": retSize = "42DD"; break;
                case "44E": retSize = "44DD"; break;
            }

            return retSize;
        }

        public static string ConvertToManhattanSize(this string ecommSize)
        {
            var decimalSize = ConvertToManhattanDecimalSize(ecommSize);
            if (decimalSize != null)
            {
                return decimalSize;
            }

            ecommSize = ecommSize.ToUpperInvariant().Trim();
            switch (ecommSize)
            {
                case "XXS": return "2XS";
                case "XXL": return "2XL";
                case "L/XL": return "LXL";
                case "OSFA": return "OSZ";
                case "32DD": return "32E";
                case "34DD": return "34E";
                case "36DD": return "36E";
                case "38DD": return "38E";
                case "40DD": return "40E";
                case "42DD": return "42E";
                case "44DD": return "44E";
                default: return ecommSize;
            }
        }

        private static string ConvertFromManhattanDecimalSize(string size)
        {
            decimal decimalSize;
            if (!decimal.TryParse(size, out decimalSize))
            {
                return null;
            }

            return decimal.Parse(size.Substring(0, 2) + "." + size.Substring(2)).ToString();
        }

        private static string ConvertToManhattanDecimalSize(string size)
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

            return null;
        }
    }
}
