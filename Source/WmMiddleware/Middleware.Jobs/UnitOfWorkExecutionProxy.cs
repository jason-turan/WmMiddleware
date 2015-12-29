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
        public static void ExecuteUnitOfWork(INinjectModule module, string[] args)
        {
            var kernel = new StandardKernel(new NinjectSettings { LoadExtensions = false }, module);
            var logger = kernel.Get<ILog>();
            var jobRepository = kernel.Get<IJobRepository>();

            if (args.Length != 1)
            {
                var exception = new NotSupportedException("Mismatch on job key argument.  Job key must be only argument provided by scheduler.  When debugging in Visual Studio job key must be set as a command argument. See http://stackoverflow.com/questions/298708/debugging-with-command-line-parameters-in-visual-studio");
                logger.Exception(exception);
                throw exception;
            }

            var jobKey = args[0];

            var job = jobRepository.GetJob(jobKey);

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            try
            {
                job.LastRunStatus = JobRunStatus.Running;
                jobRepository.UpdateJob(job);
                ((IUnitOfWork)kernel.Get(typeof(T))).RunUnitOfWork(jobKey);
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

                jobRepository.InsertJobHistory(new MiddlewareJobHistory
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
    }
}
