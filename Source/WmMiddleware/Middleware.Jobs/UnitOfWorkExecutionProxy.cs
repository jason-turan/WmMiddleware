using System;
using System.Diagnostics;
using System.Security.Principal;
using Ninject;
using Ninject.Modules;
using Middleware.Jobs.Models;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;

namespace Middleware.Jobs
{
    /// <summary>
    /// Proxy executed by jobs when quartz scheduler (Console Job) invokes it
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class UnitOfWorkExecutionProxy<T> where T : IUnitOfWork
    {
        public static void ExecuteUnitOfWork(INinjectModule module)
        {
            var kernel = new StandardKernel(new NinjectSettings { LoadExtensions = false }, module);
            var logger = kernel.Get<ILog>();
            var jobRepository = kernel.Get<IJobRepository>();

            var job = GetJob(jobRepository);

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            try
            {
                job.LastRunStatus = JobRunStatus.Running;
                jobRepository.UpdateJob(job);
                ((IUnitOfWork) kernel.Get(typeof (T))).RunUnitOfWork();
                job.LastRunStatus = JobRunStatus.Success;
                logger.Info("Successful execution of " + kernel.Get(typeof (T)));

            }
            catch (Exception exception)
            {
                job.LastRunStatus = JobRunStatus.Failure;
                logger.Exception(exception);
            }
            finally
            {
                stopWatch.Stop();
                job.LastRunDateTime = DateTime.Now;
                job.LastRunExecutionTime = stopWatch.ElapsedMilliseconds;  
               
                jobRepository.UpdateJob(job);

                jobRepository.InsertJobHistory(new MiddlewareJobHistory()
                {
                    JobId = job.JobId,
                    RunStatus = job.LastRunStatus,
                    RunDate = job.LastRunDateTime.Value,
                    MachineName = Environment.MachineName,
                    UserName = WindowsIdentity.GetCurrent() == null ? "Unknown" : WindowsIdentity.GetCurrent().Name
                });

                Environment.Exit(job.LastRunStatus == JobRunStatus.Failure ? 1 : 0);
            }
        }

        private static MiddlewareJob GetJob(IJobRepository jobRepository)
        {
            var executableName = AppDomain.CurrentDomain.FriendlyName.Replace(".vshost", string.Empty);
            var job = jobRepository.GetJobByExecutable(executableName);  // if running in visual studio, .vshost is appended to exe
            return job;
        }
    }
}
