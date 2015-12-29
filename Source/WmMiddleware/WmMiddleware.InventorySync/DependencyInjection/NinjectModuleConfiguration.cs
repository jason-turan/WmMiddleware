using Ninject.Modules;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;

namespace WmMiddleware.InventorySync.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().To<Log4Net>();
            Bind<IInventorySyncJob>().To<InventorySyncJob>();
            Bind<IJobRepository>().To<JobRepository>();
        }
    }
}
