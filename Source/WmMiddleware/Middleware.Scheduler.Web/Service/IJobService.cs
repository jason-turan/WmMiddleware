using System.Collections.Generic;
using Middleware.Jobs.Models;

namespace Middleware.Scheduler.Web.Service
{
    public interface IJobService
    {
        IList<MiddlewareJob> GetJobs();
        bool SaveMiddlewareJobSchedule(string jobKey, string schedule);
        void SaveMiddlewareJobActiveStatus(string jobKey, bool isActive);
        bool LaunchJob(string jobKey, string userName);
    }
}
