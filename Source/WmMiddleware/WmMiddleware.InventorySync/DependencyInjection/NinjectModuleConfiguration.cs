using Ninject.Modules;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using WmMiddleware.Configuration;
using WmMiddleware.InventorySync.Repository;
using WmMiddleware.TransferControl.Control;
using WmMiddleware.TransferControl.Repositories;

namespace WmMiddleware.InventorySync.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().To<Log4Net>();
            Bind<IInventorySyncJob>().To<InventorySyncJob>();
            Bind<IJobRepository>().To<JobRepository>();
            Bind<ITransferControlRepository>().To<TransferControlRepository>();
            Bind<IConfigurationManager>().To<MiddlewareConfigurationManager>();
            Bind<IInventorySyncRepository>().To<InventorySyncRepository>();
            Bind<IFileIo>().To<FileIo>();
        }
    }
}

