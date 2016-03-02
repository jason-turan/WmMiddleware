using System;

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
            //COPIED FROM SQL SERVER----------------

            string retSize = size.ToUpperInvariant().Trim();

            switch (retSize)
            {
                //--FOOTWEAR
                case "05": retSize = "5"; break;
                case "055": retSize = "5.5"; break;
                case "06": retSize = "6"; break;
                case "065": retSize = "6.5"; break;
                case "07": retSize = "7"; break;
                case "075": retSize = "7.5"; break;
                case "08": retSize = "8"; break;
                case "085": retSize = "8.5"; break;
                case "09": retSize = "9"; break;
                case "095": retSize = "9.5"; break;
                case "105": retSize = "10.5"; break;
                case "115": retSize = "11.5"; break;
                case "125": retSize = "12.5"; break;

                //--APPAREL
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
            ecommSize = ecommSize.ToUpperInvariant().Trim();
            switch (ecommSize)
            {
                case "5": return "05";
                case "5.5": return "055";
                case "6": return "06";
                case "6.5": return "065";
                case "7": return "07";
                case "7.5": return "075";
                case "8": return "08";
                case "8.5": return "085";
                case "9": return "09";
                case "9.5": return "095";
                case "10.5": return "105";
                case "11.5": return "115";
                case "12.5": return "125";
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
    }
}
