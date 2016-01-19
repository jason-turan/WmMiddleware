using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using Ninject.Modules;
using WmMiddleware.Configuration;
using WmMiddleware.ShipmentCancellationEmail.Repository;

namespace WmMiddleware.ShipmentCancellationEmail.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<IJobRepository>().To<JobRepository>();
            Bind<ILog>().To<Log4Net>();
            Bind<IConfigurationManager>().To<MiddlewareConfigurationManager>();
            Bind<IUnitOfWork>().To<ShipmentCancellationEmailJob>();
            Bind<ICancellationEmailDistributionRepository>().To<CancellationEmailDistributionRepository>();
        }
    }
}
