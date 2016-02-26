using Middleware.Integration.Factories;
using Middleware.Integration.Repositories;
using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using Middleware.Log;
using Middleware.Wm.Configuration;
using Ninject.Modules;

namespace Middleware.Integration.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().To<Log4Net>();
            Bind<IConfigurationManager>().To<MiddlewareConfigurationManager>();
            Bind<IJobRepository>().To<JobRepository>();
            Bind<IIntegrationTaskRespository>().To<IntegrationTaskRespository>();
            Bind<IXmlRepositoryFactory>().To<XmlRepositoryFactory>();
            Bind<IUnitOfWork>().To<IntegrationJob>();
        }
    }
}
