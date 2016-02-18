using Middleware.Wm.Configuration.Mainframe;
using Ninject.Modules;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using Middleware.Jobs.Job;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using Middleware.Scheduler.WindowService.Scheduler;

namespace Middleware.Scheduler.WindowService.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().To<Log4Net>();
            Bind<IJobFactory>().To<NinjectQuartzFactory>();
            Bind<ISchedulerFactory>().To<StdSchedulerFactory>();
            Bind<IServer>().To<Server>();
            Bind<IMainframeConfiguration>().To<MainframeConfiguration>();
            Bind<IJobRepository>().To<JobRepository>();
            Bind<IConsoleJob>().To<ConsoleJob>();
            Bind<IServerScheduler>().To<ServerScheduler>();
        }
    }
}
