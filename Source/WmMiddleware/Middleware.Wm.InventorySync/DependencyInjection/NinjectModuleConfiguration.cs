using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using Middleware.Log;
using Middleware.Wm.Configuration;
using Middleware.Wm.InventorySync.Repository;
using Middleware.Wm.Manhattan.Shipment;
using Middleware.Wm.Pix.Repository;
using Middleware.Wm.Shipment.Repository;
using Middleware.Wm.StlInventoryUpdate.Repository;
using Middleware.Wm.TransferControl.Configuration;
using Middleware.Wm.TransferControl.Control;
using Middleware.Wm.TransferControl.Repositories;
using Ninject.Modules;

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
            Bind<ITransferControlConfigurationManager>().To<TransferControlConfigurationManager>();

            Bind<IStlInventoryRepository>().To<StlInventoryRepository>();
            Bind<IStlInventoryUpdateRepository>().To<StlInventoryUpdateRepository>();
            Bind<IShipmentRepository>().To<ShipmentRepository>();
            Bind<IShipmentInventoryAdjustmentRepository>().To<ShipmentInventoryAdjustmentRepository>();
            Bind<IPerpetualInventoryTransferRepository>().To<PerpetualInventoryTransferRepository>();
            Bind<IPixInventoryAdjustmentRepository>().To<PixInventoryAdjustmentRepository>();
        }
    }
}

