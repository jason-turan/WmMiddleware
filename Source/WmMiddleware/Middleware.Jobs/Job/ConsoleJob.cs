using System;
using System.Diagnostics;
using Quartz;
using Middleware.Jobs.Models;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;

namespace Middleware.Jobs.Job
{
    /// <summary>
    /// Proxy executed by quartz job scheduler
    /// </summary>
    public class ConsoleJob : IJob, IConsoleJob
    {
        private readonly ILog _logger;

        private readonly IJobRepository _jobRepository;

        public ConsoleJob(ILog logger, IJobRepository jobRepository)
        {
            _logger = logger;
            _jobRepository = jobRepository;
        }

        public void Execute(IJobExecutionContext context)
        {
            var job = _jobRepository.GetJob(context.JobDetail.Key.Name);
            
            if (!job.IsActive)
            {
                _logger.Info(job.JobKey + " is not active and job will not execute, but was triggered.");
                return;
            }

            Launch(context, job);
        }

        private void Launch(IJobExecutionContext context, MiddlewareJob job)
        {
            var process = new Process();

            try
            {
                var startInfo = new ProcessStartInfo
                {
                    FileName = job.JobExecutable,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                process.StartInfo = startInfo;
                process.Start();                
                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    throw new JobExecutionException(context.JobDetail.Description +
                                                    " returned with exit code " +
                                                    process.ExitCode);
                }

                job.LastRunStatus = JobRunStatus.Success;
            }
            catch (Exception exception)
            {
                _logger.Exception("Error launching or executing " + context.JobDetail.JobType.AssemblyQualifiedName, exception);
                throw new JobExecutionException(exception);
            }
        }
    }
}
