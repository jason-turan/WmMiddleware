using Middleware.Jobs;
using Ninject.Modules;
using WmMiddleware.Configuration;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using WmMiddleware.Shipment.Repository;
using WmMiddleware.TransferControl.Control;
using WmMiddleware.TransferControl.Repositories;

namespace WmMiddleware.Shipment.DependencyInjection
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
