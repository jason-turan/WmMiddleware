using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using Ninject.Modules;

namespace Middleware.Wm.LoggingAndFileMaintenance.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().To<Log4Net>();
            Bind<IUnitOfWork>().To<LogAndFileMaintenanceJob>();
            Bind<IJobRepository>().To<JobRepository>();
        }
    }
}