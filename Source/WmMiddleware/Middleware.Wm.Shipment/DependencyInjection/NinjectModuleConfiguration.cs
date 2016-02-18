using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using Middleware.Wm.Configuration;
using Middleware.Wm.TransferControl.Control;
using Middleware.Wm.TransferControl.Repositories;
using Ninject.Modules;
using WmMiddleware.Shipment;
using WmMiddleware.Shipment.Repository;

namespace Middleware.Wm.Shipment.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<ShipmentJob>();
            Bind<IJobRepository>().To<JobRepository>();
            Bind<ILog>().To<Log4Net>();
            Bind<ITransferControlRepository>().To<TransferControlRepository>();
            Bind<IConfigurationManager>().To<MiddlewareConfigurationManager>();
            Bind<IShipmentRepository>().To<ShipmentRepository>();
            Bind<IFileIo>().To<FileIo>();
        }
    }
}
