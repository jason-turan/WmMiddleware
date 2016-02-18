using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using Middleware.Wm.Configuration;
using Ninject.Modules;

namespace Middleware.Wm.GeneralLedgerReconcilliation.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<GeneralLedgerReconcilliationJob>();
            Bind<IJobRepository>().To<JobRepository>();
            Bind<ILog>().To<Log4Net>();
            Bind<IConfigurationManager>().To<MiddlewareConfigurationManager>();
        }
    }
}
