using Quartz;

namespace Middleware.Jobs.Job
{
    public interface IConsoleJob 
    {
        /// <summary>
        /// Quartz Scheduler will invoke via this method
        /// </summary>
        /// <param name="context"></param>
        void Execute(IJobExecutionContext context);
    }
}
