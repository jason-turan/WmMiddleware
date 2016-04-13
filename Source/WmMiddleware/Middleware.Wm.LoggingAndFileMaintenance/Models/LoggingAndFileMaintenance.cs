namespace Middleware.Wm.LoggingAndFileMaintenance.Models
{
    public class LoggingAndFileMaintenance
    {
        public string RollingFileDirectories { get; set; }
        public int RollingFileZipOlderThanDays { get; set; }
        public int DatabaseLogTrimOlderThanDays { get; set; }
        public int JobHistoryTrimOlderThanDays { get; set; }
    }
}