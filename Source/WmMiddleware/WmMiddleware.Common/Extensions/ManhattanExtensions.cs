using System;
using System.Globalization;

namespace WmMiddleware.Common.Extensions
{
    public static class ManhattanExtensions
    {
        public static DateTime ParseDateTime(int date, int time)
        {
            return DateTime.ParseExact(date.ToString("D8") + time.ToString("D8"), "yyyyMMddhhmmss", CultureInfo.InvariantCulture);
        }

        public static int ToManhattanDate(this DateTime dateTime)
        {
            return int.Parse(dateTime.ToString("yyyyMMdd"));
        }

        public static int ToManhattanTime(this DateTime dateTime)
        {
            return int.Parse(dateTime.ToString("HHmmss"));
        }
    }
}
