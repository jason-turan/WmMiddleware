using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using Middleware.Log;
using Middleware.Wm.Configuration;
using Middleware.Wm.GeneralLedgerReconcilliation.Repository;
using Middleware.Wm.Manhattan.Shipment;
using Middleware.Wm.Pix.Repository;
using Ninject.Modules;

namespace Middleware.Wm.GeneralLedgerReconcilliation.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<GeneralLedgerReconcilliationJob>();
            Bind<IJobRepository>().To<JobRepository>();
            Bind<ILog>().To<Log4Net>();
            Bind<IConfigurationManager>().To<MiddlewareConfigurationManager>();
            Bind<IPerpetualInventoryTransferRepository>().To<PerpetualInventoryTransferRepository>();
            Bind<IGeneralLedgerReconcilliationRepository>().To<GeneralLedgerReconcilliationRepository>();
            Bind<IDatabaseRepository>().To<DatabaseRepository>();
            Bind<IShipmentRepository>().To<ShipmentRepository>();
        }
    }
}
