using System.Linq;
using Quartz;
using Middleware.Jobs.Repositories;
using Middleware.Log;

namespace Middleware.Scheduler.WindowService.Scheduler
{
    public class TriggerListener : ITriggerListener
    {
        private readonly IJobRepository _jobRepository;
        private readonly ILog _log;

        public TriggerListener(IJobRepository jobRepository, ILog log)
        {
            _jobRepository = jobRepository;
            _log = log;

            Name = "Triggerlistener";
        }

        public void TriggerFired(ITrigger trigger, IJobExecutionContext context)
        {
            var job = _jobRepository.GetJob(context.JobDetail.Key.Name);

            var nextFireTimeUtc = trigger.GetNextFireTimeUtc();

            if (nextFireTimeUtc == null) return;

            job.NextRunDateTime = nextFireTimeUtc.Value.LocalDateTime;
            _jobRepository.UpdateJob(job);
        }

        public void TriggerMisfired(ITrigger trigger)
        {
            _log.Warning(trigger.JobKey + " has misfired a trigger");
        }

        public bool VetoJobExecution(ITrigger trigger, IJobExecutionContext context)
        {
            if (context.Scheduler.GetCurrentlyExecutingJobs().Any(f => f.JobDetail.Key.Equals(context.JobDetail.Key)))
            {
                _log.Info(trigger.JobKey + " is already running and will be vetoed.  Will not execute.");
                return true;
            }
         
            return false;
        }

        public void TriggerComplete(ITrigger trigger, IJobExecutionContext context, SchedulerInstruction triggerInstructionCode)
        {
            // interface implemention not needed
        }

        public string Name { get; private set; }
    }
}
