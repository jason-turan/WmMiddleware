using Middleware.Integration.Factories;
using Middleware.Integration.Repositories;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using Ninject.Modules;
using WmMiddleware.Configuration;

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
        }
    }
}
