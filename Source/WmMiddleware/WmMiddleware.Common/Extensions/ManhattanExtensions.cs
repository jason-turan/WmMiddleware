using System;
using System.Globalization;

namespace WmMiddleware.Common.Extensions
{
    public static class ManhattanExtensions
    {
        public static DateTime ParseDateTime(int date, int time, DateTimeStyles dateTimeStyles = DateTimeStyles.None)
        {
            return DateTime.ParseExact(date.ToString("D8") + time.ToString("D6"), "yyyyMMddhhmmss", CultureInfo.InvariantCulture, dateTimeStyles);
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
