using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using Middleware.Log;
using Middleware.Log.Repository;
using Middleware.Wm.LoggingAndFileMaintenance.Repository;
using Ninject.Modules;

namespace Middleware.Wm.LoggingAndFileMaintenance.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().To<Log4Net>();
            Bind<IUnitOfWork>().To<LogAndFileMaintenanceJob>();
            Bind<ILoggingAndFileMaintenanceRepository>().To<LoggingAndFileMaintenanceRepository>();
            Bind<IJobRepository>().To<JobRepository>();
            Bind<ILogRepository>().To<LogRepository>();
        }
    }
}