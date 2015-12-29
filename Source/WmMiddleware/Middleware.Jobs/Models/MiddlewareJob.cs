using System;

namespace Middleware.Jobs.Models
{
    public class MiddlewareJob 
    {
        public int JobId { get; set; }

        public string JobKey { get; set; }

        public string Schedule { get; set; }

        public string JobExecutable { get; set; }

        public bool IsActive { get; set; }

        public string LastRunStatus { get; set; }

        public double? LastRunExecutionTime { get; set; }

        public DateTime? LastRunDateTime { get; set; }

        public DateTime? NextRunDateTime { get; set; }

        public string JobType { get; set; }

        public bool IsAlerted { get; set; }
    }
}