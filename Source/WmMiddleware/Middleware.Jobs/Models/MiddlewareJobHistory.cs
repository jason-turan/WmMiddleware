using System;

namespace Middleware.Jobs.Models
{
    public class MiddlewareJobHistory
    {
        public int JobHistoryId { get; set; }

        public int JobId { get; set; }

        public string RunStatus { get; set; }

        public DateTime RunDate { get; set; }

        public string MachineName { get; set; }

        public string UserName { get; set; }
    }
}
