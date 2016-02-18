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

        public static string ToEcommSize(this string size)
        {
            //COPIED FROM SQL SERVER----------------

            string retSize = size.ToLower().Trim();

            switch (retSize)
            {
                //--FOOTWEAR
			    case "05" : retSize = "5"; break;
			    case "055": retSize = "5.5"; break;
			    case "06" : retSize = "6"; break;
			    case "065": retSize = "6.5"; break;
			    case "07" : retSize = "7"; break;
			    case "075": retSize = "7.5"; break;
			    case "08" : retSize = "8"; break;
			    case "085": retSize = "8.5"; break;
			    case "09" : retSize = "9"; break;
			    case "095": retSize = "9.5"; break;
			    case "105": retSize = "10.5"; break;
			    case "115": retSize = "11.5"; break;
			    case "125": retSize = "12.5"; break;

                //--APPAREL
                case "LXL": retSize = "L/XL"; break;
	            case "1SZ": retSize = "OSFA"; break;
	            case "OSZ": retSize = "OSFA"; break;
	            case "XXS": retSize = "2XS"; break;
	            case "XXL": retSize = "2XL"; break;
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

    }
}
