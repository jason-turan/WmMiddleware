using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using Ninject.Modules;
using WmMiddleware.Configuration;
using WmMiddleware.Pix.Repository;
using WmMiddleware.Shipment.Repository;
using WmMiddleware.StlInventoryUpdate.Repository;

namespace WmMiddleware.StlInventoryUpdate.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().To<Log4Net>();
            Bind<IStlInventoryUpdateJob>().To<StlInventoryUpdateJob>();
            Bind<IStlInventoryUpdateRepository>().To<StlInventoryUpdateRepository>();
            Bind<IShipmentRepository>().To<ShipmentRepository>();
            Bind<IShipmentInventoryAdjustmentRepository>().To<ShipmentInventoryAdjustmentRepository>();
            Bind<IPerpetualInventoryTransferRepository>().To<PerpetualInventoryTransferRepository>();
            Bind<IPixInventoryAdjustmentRepository>().To<PixInventoryAdjustmentRepository>();
            Bind<IJobRepository>().To<JobRepository>();
            Bind<IConfigurationManager>().To<MiddlewareConfigurationManager>();
        }
    }
}
