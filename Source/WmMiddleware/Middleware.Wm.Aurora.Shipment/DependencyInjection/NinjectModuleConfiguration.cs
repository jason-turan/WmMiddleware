using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using Middleware.Log;
using Middleware.Log.Repository;
using Middleware.Wm.Aurora.Shipment.Repository;
using Middleware.Wm.Configuration;
using Middleware.Wm.Configuration.Mainframe;
using Middleware.Wm.Manhattan.Control;
using Middleware.Wm.Manhattan.Shipment;
using Middleware.Wm.TransferControl.Control;
using Middleware.Wm.TransferControl.Repositories;
using Ninject.Modules;

namespace Middleware.Wm.Aurora.Shipment.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().To<Log4Net>();
            Bind<IJobRepository>().To<JobRepository>();
            Bind<IConfigurationManager>().To<MiddlewareConfigurationManager>();
            Bind<IUnitOfWork>().To<AuroraShipmentJob>();
            Bind<IFileIo>().To<FileIo>();
            Bind<IDatabaseKioskOrderExportRepository>().To<DatabaseKioskOrderExportRepository>();
            Bind<IAuroraShipmentRepository>().To<AuroraShipmentRepository>();
            Bind<ITransferControlRepository>().To<TransferControlRepository>();
            Bind<ITransferControlManager>().To<TransferControlManager>();
            Bind<IMainframeConfiguration>().To<MainframeConfiguration>();
            Bind<IShipmentRepository>().To<ShipmentRepository>();
            Bind<IOrderHistoryRepository>().To<OrderHistoryRepository>();
        }
    }
}
       