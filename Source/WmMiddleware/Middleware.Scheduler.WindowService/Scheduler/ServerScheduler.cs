using System;
using Quartz;
using Middleware.Jobs.Job;
using Middleware.Jobs.Models;
using Middleware.Jobs.Repositories;
using Middleware.Log;

namespace Middleware.Scheduler.WindowService.Scheduler
{
    public class ServerScheduler : IServerScheduler
    {
        private readonly ILog _logger;
        private readonly IJobRepository _jobRepository;

        public ServerScheduler(ILog logger,
                               IJobRepository jobRepository)
        {
            _logger = logger;
            _jobRepository = jobRepository;
        }

        public void ScheduleJobs(IScheduler scheduler)
        {
            foreach (var job in _jobRepository.GetJobs())
            {
                ScheduleJob(job, scheduler);
            }
        }

        public void ScheduleJob(MiddlewareJob job, IScheduler scheduler)
        {
            var jobKey = new JobKey(job.JobKey);

            var trigger = CreateTrigger(job);

            var jobDetail = JobBuilder.
                Create(typeof(ConsoleJob)).
                WithIdentity(jobKey).
                WithDescription("Scheduled " + job.JobKey + " to run on schedule " + job.Schedule).
                StoreDurably(). // specifies job should stick around even if not scheduled (allows reschedule)
                Build();

            scheduler.ScheduleJob(jobDetail, trigger);
            _logger.Info("Scheduled " + job.JobKey + " to run on schedule " + job.Schedule);
        }

        private ITrigger CreateTrigger(MiddlewareJob job)
        {
            ITrigger trigger;

            if (job.Schedule.Contains("M"))
            {
                int minutes = Convert.ToInt32(job.Schedule.Replace("M", string.Empty));

                trigger = TriggerBuilder
                    .Create()
                    .WithSimpleSchedule(s => s.WithIntervalInMinutes(minutes).RepeatForever())
                    .WithIdentity(new TriggerKey(job.JobKey))
                    .Build();
            }
            else if (job.Schedule.Contains("S"))
            {
                int seconds = Convert.ToInt32(job.Schedule.Replace("S", string.Empty));

                trigger = TriggerBuilder
                    .Create()
                    .WithSimpleSchedule(s => s.WithIntervalInSeconds(seconds).RepeatForever())
                    .WithIdentity(new TriggerKey(job.JobKey))
                    .Build();
            }
            else if (job.Schedule.Contains("H"))
            {
                int hours = Convert.ToInt32(job.Schedule.Replace("H", string.Empty));

                trigger = TriggerBuilder.Create()
                    .WithSimpleSchedule(s => s.WithIntervalInHours(hours).RepeatForever())
                    .WithIdentity(new TriggerKey(job.JobKey))
                    .Build();
            }
            else
            {
                trigger = TriggerBuilder.Create()
                    .WithCronSchedule(job.Schedule)
                    .WithIdentity(new TriggerKey(job.JobKey))
                    .StartNow()
                    .Build();
            }

            return trigger;
        }
    }
}
