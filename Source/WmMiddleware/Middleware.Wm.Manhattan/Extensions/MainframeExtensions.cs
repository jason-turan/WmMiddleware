using System;
using System.Globalization;

namespace Middleware.Wm.Manhattan.Extensions
{
    public static class MainframeExtensions
    {
        public static DateTime ParseDateTime(int date, int time, DateTimeStyles dateTimeStyles = DateTimeStyles.None)
        {
            return DateTime.ParseExact(date.ToString("D8") + time.ToString("D6"), "yyyyMMddhhmmss", CultureInfo.InvariantCulture, dateTimeStyles);
        }

        public static int ToMainframeDate(this DateTime dateTime)
        {
            return int.Parse(dateTime.ToString("yyyyMMdd"));
        }

        public static int ToMainframeTime(this DateTime dateTime)
        {
            return int.Parse(dateTime.ToString("HHmmss"));
        }
    }
}
