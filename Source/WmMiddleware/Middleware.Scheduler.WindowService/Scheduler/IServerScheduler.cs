using Quartz;
using Middleware.Jobs.Models;

namespace Middleware.Scheduler.WindowService.Scheduler
{
    public interface IServerScheduler
    {
        void ScheduleJobs(IScheduler scheduler);
        void ScheduleJob(MiddlewareJob job, IScheduler scheduler);
    }
}