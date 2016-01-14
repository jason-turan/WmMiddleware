using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using Ninject.Modules;
using WmMiddleware.Configuration;
using WmMiddleware.Pix.Repository;
using WmMiddleware.PixReturn.Repository;

namespace WmMiddleware.PixReturn.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().To<Log4Net>();
            Bind<IPixReturnJob>().To<PixReturnJob>();
            Bind<IConfigurationManager>().To<MiddlewareConfigurationManager>();
            Bind<IDatabaseRowReturnRepository>().To<DatabaseRowReturnRepository>();
            Bind<IPerpetualInventoryTransferRepository>().To<PerpetualInventoryTransferRepository>();
            Bind<IManhattanConditionCodeRepository>().To<ManhattanConditionCodeRepository>();
            Bind<IPixReturnRepository>().To<PixReturnRepository>();
            Bind<IJobRepository>().To<JobRepository>();
        }
    }
}
       