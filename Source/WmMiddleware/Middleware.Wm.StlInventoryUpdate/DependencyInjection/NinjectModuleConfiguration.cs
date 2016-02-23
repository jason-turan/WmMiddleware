using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using Middleware.Wm.Configuration;
using Middleware.Wm.Manhattan.Shipment;
using Middleware.Wm.Pix.Repository;
using Middleware.Wm.Shipment.Repository;
using Middleware.Wm.StlInventoryUpdate.Repository;
using Ninject.Modules;

namespace Middleware.Wm.StlInventoryUpdate.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().To<Log4Net>();
            Bind<IStlInventoryUpdateJob>().To<StlInventoryUpdateJob>();
            Bind<IStlInventoryUpdateRepository>().To<StlInventoryUpdateRepository>();
            Bind<IShipmentInventoryAdjustmentRepository>().To<ShipmentInventoryAdjustmentRepository>();
            Bind<IPerpetualInventoryTransferRepository>().To<PerpetualInventoryTransferRepository>();
            Bind<IPixInventoryAdjustmentRepository>().To<PixInventoryAdjustmentRepository>();
            Bind<IJobRepository>().To<JobRepository>();
            Bind<IConfigurationManager>().To<MiddlewareConfigurationManager>();
            Bind<IShipmentRepository>().To<ShipmentRepository>();
        }
    }
}
