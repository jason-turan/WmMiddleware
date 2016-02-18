using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using Middleware.Wm.Configuration;
using Middleware.Wm.InventorySync.Repository;
using Middleware.Wm.TransferControl.Control;
using Middleware.Wm.TransferControl.Repositories;
using Ninject.Modules;
using WmMiddleware.InventorySync;

namespace Middleware.Wm.InventorySync.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().To<Log4Net>();
            Bind<IUnitOfWork>().To<InventorySyncJob>();
            Bind<IJobRepository>().To<JobRepository>();
            Bind<ITransferControlRepository>().To<TransferControlRepository>();
            Bind<IConfigurationManager>().To<MiddlewareConfigurationManager>();
            Bind<IInventorySyncRepository>().To<InventorySyncRepository>();
            Bind<IFileIo>().To<FileIo>();
        }
    }
}

