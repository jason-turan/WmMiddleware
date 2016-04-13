using System;
using System.Linq;
using System.Text;

namespace Middleware.Wm.Manhattan.Text
{
    public static class StringExtensions
    {
        private static readonly Encoding LatinHebrewEncoding = Encoding.GetEncoding("ISO-8859-8");
        private const byte SpaceByte = 0x20;

        public static string Englify(this string source)
        {
            if(source == null)
            {
                throw new ArgumentNullException("source");
            }

            // Latin/Hebrew codepage contains no accents.  Characters will be converted
            // to letters without accents as needed.
            var bytes = LatinHebrewEncoding.GetBytes(source);
            // Hebrew characters are only characters left that cannot be handled.  Replace with spaces.
            bytes = bytes.Select(b => b > 126 ? SpaceByte : b).ToArray();

            return Encoding.UTF8.GetString(bytes);
        }
    }
}
