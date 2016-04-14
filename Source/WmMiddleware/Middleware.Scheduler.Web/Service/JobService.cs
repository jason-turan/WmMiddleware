using System;
using System.Collections.Generic;
using System.Linq;
using Quartz;
using Middleware.Scheduler.WindowService.Quartz;
using Middleware.Scheduler.WindowService.Scheduler;
using Middleware.Jobs.Models;
using Middleware.Jobs.Repositories;
using Middleware.Log;

namespace Middleware.Scheduler.Web.Service
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly ILog _log;
        private readonly IServerScheduler _serverScheduler;

        public JobService(ILog log, 
                          IJobRepository jobRepository,
                          IServerScheduler serverScheduler)
        {
            _log = log;
            _jobRepository = jobRepository;
            _serverScheduler = serverScheduler;
        }

        public IList<MiddlewareJob> GetJobs()
        {
            return _jobRepository.GetJobs().ToList();
        }

        public bool SaveMiddlewareJobSchedule(string jobKey, string schedule)
        {
            var job = _jobRepository.GetJob(jobKey);
            job.Schedule = schedule;
            _jobRepository.UpdateJob(job);

            return RescheduleJob(job);
        }

        public void SaveMiddlewareJobActiveStatus(string jobKey, bool isActive)
        {
            _jobRepository.UpdateJobActiveInactive(_jobRepository.GetJob(jobKey).JobId, isActive);
        }

        public bool LaunchJob(string jobKey, string userName)
        {
            try
            {
                if (QuartzRemoteScheduler.Instance == null || !QuartzRemoteScheduler.Instance.IsStarted) return false;
 
                var job = _jobRepository.GetJob(jobKey);

                if (!job.IsActive)
                {                    
                    _log.Info("Activated " + jobKey);
                    SaveMiddlewareJobActiveStatus(jobKey, true);
                }
                
                QuartzRemoteScheduler.Instance.TriggerJob(new JobKey(jobKey));
              
                return true;
            }
            catch (Exception exception)
            {
                _log.Exception("Failed to launch " + jobKey, exception);
                return false;
            }
        }

        private bool RescheduleJob(MiddlewareJob job)
        {
            try
            {
                if (QuartzRemoteScheduler.Instance == null || !QuartzRemoteScheduler.Instance.IsStarted) return false;

                QuartzRemoteScheduler.Instance.UnscheduleJob(new TriggerKey(job.JobKey));
                QuartzRemoteScheduler.Instance.DeleteJob(new JobKey(job.JobKey));
                _log.Debug("Uncheduled job " + job.JobKey);
                
                _serverScheduler.ScheduleJob(job, QuartzRemoteScheduler.Instance);
  
                return true;
            }
            catch (Exception exception)
            {
                _log.Exception("Failed to reschedule " + job.JobKey, exception);
                return false;
            }
        }
    }
}