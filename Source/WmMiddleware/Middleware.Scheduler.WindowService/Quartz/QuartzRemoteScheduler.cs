using Quartz;
using Quartz.Impl;

namespace Middleware.Scheduler.WindowService.Quartz
{
    public sealed class QuartzRemoteScheduler
    {
        private static QuartzRemoteScheduler _instance;

        private static readonly object Padlock = new object();

        private readonly IScheduler _scheduler;

        QuartzRemoteScheduler()
        {
            _scheduler = new StdSchedulerFactory().GetScheduler();
        }

        public static IScheduler Instance
        {
            get
            {
                lock (Padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new QuartzRemoteScheduler();
                    }
                    return _instance._scheduler;
                }
            }
        }
    }
}