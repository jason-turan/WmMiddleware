using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Quartz;
using Middleware.Scheduler.WindowService.Quartz;
using Middleware.Scheduler.WindowService.Scheduler;
using Middleware.Jobs.Models;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;

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
            var job = _jobRepository.GetJob(jobKey);
            job.IsActive = isActive;
            _jobRepository.UpdateJob(job);
        }

        public bool LaunchJob(string jobKey, string userName)
        {
            try
            {
                if (QuartzRemoteScheduler.Instance == null || !QuartzRemoteScheduler.Instance.IsStarted) return false;
                var timeOut = new Stopwatch();
                timeOut.Start();

                var job = _jobRepository.GetJob(jobKey);

                if (!job.IsActive)
                {                    
                    _log.Info("Activated " + jobKey);
                    SaveMiddlewareJobActiveStatus(jobKey, true);
                }
                
                QuartzRemoteScheduler.Instance.TriggerJob(new JobKey(jobKey));
               
                bool jobLaunched = false;

                while (!jobLaunched)
                {
                     Thread.Sleep(1000);

                    if (timeOut.ElapsedMilliseconds > 60000)
                    {
                        _log.Warning("Could not launch job because timeout expired");
                        return false;
                    }

                    jobLaunched = JobLaunched(job);

                    if (jobLaunched)
                    {
                        _log.Info("Successfully manually launched " + jobKey + " invoked by " + userName);
                    }
                }

                if (job.IsActive) return true;

                job.IsActive = false;
                _jobRepository.UpdateJob(job);
                _log.Info("Deactivated " + jobKey);

                return true;
            }
            catch (Exception exception)
            {
                _log.Exception("Failed to launch " + jobKey, exception);
                return false;
            }
        }

        private bool JobLaunched(MiddlewareJob job)
        {
            bool jobLaunched = false;

            var update = _jobRepository.GetJob(job.JobKey);

            if (!job.LastRunDateTime.HasValue &&
                update.LastRunDateTime.HasValue)
            {
                _log.Debug("Job will be marked as launched because job was launched for first time");
                jobLaunched = true;
            }

            if (job.LastRunDateTime.HasValue &&
                update.LastRunDateTime.HasValue &&
                job.LastRunDateTime.Value != update.LastRunDateTime.Value)
            {
                _log.Debug("Job will be marked as launched because last run date has been updated");
                jobLaunched = true;
            }

            if (Process.GetProcesses().Any(p => p.ProcessName.Contains(job.JobExecutable.Replace(".exe",string.Empty))))
            {
                _log.Debug("Job is running and will be marked as launched");
                jobLaunched = true;
            }

            return jobLaunched;
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