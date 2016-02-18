using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using Middleware.Wm.Configuration;
using Middleware.Wm.InventorySync.Repository;
using Middleware.Wm.Pix.Repository;
using Middleware.Wm.StlInventorySync.Repository;
using Middleware.Wm.StlInventoryUpdate.Repository;
using Ninject.Modules;
using WmMiddleware.Shipment.Repository;

namespace Middleware.Wm.StlInventorySync.DependencyInjection
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
            Bind<IStlInventoryUpdateRepository>().To<StlInventoryUpdateRepository>();
            Bind<IShipmentRepository>().To<ShipmentRepository>();
            Bind<IShipmentInventoryAdjustmentRepository>().To<ShipmentInventoryAdjustmentRepository>();
            Bind<IPerpetualInventoryTransferRepository>().To<PerpetualInventoryTransferRepository>();
            Bind<IPixInventoryAdjustmentRepository>().To<PixInventoryAdjustmentRepository>();
        }
    }
}
