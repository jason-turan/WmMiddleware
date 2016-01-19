using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using Ninject.Modules;
using WmMiddleware.InventorySync.Repository;
using WmMiddleware.StlInventorySync.Repository;
using WmMiddleware.Configuration;

namespace WmMiddleware.StlInventorySync.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().To<Log4Net>();
            Bind<IUnitOfWork>().To<StlInventorySyncJob>();
            Bind<IStlInventoryRepository>().To<StlInventoryRepository>();
            Bind<IInventorySyncRepository>().To<InventorySyncRepository>();
            Bind<IJobRepository>().To<JobRepository>();
            Bind<IConfigurationManager>().To<MiddlewareConfigurationManager>();
        }
    }
}
