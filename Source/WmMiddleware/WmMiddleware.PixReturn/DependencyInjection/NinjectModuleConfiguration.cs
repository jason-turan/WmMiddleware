using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using Ninject.Modules;
using WmMiddleware.Configuration;

namespace WmMiddleware.PixReturn.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().To<Log4Net>();
            Bind<IPixReturnJob>().To<PixReturnJob>();
            Bind<IConfigurationManager>().To<MiddlewareConfigurationManager>();
            Bind<IJobRepository>().To<JobRepository>();
        }
    }
}
       