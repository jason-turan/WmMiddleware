using Middleware.Jobs;
using Ninject.Modules;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using WmMiddleware.Configuration;

namespace Middleware.Alerts.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().To<Log4Net>();
            Bind<IUnitOfWork>().To<AlertJob>();
            Bind<IJobRepository>().To<JobRepository>();
            Bind<IConfigurationManager>().To<MiddlewareConfigurationManager>();
        }
    }
}
