using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using Middleware.Wm.Inventory;
using Middleware.Wm.Locations;
using Middleware.Wm.Manhattan.Inventory;
using Middleware.Wm.PickTicketConfirmation.Repositories;
using Middleware.Wm.Shipping;
using MiddleWare.Log;
using Ninject.Modules;
using WmMiddleware.Configuration;
using WmMiddleware.Picking.Configuration;
using WmMiddleware.TransferControl.Control;
using WmMiddleware.TransferControl.Repositories;

namespace Middleware.Wm.PickTicketConfirmation.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

            Bind<ILog>().To<Log4Net>();
            Bind<IJobRepository>().To<JobRepository>();
            Bind<IConfigurationManager>().To<MiddlewareConfigurationManager>();
            Bind<IUnitOfWork>().To<PickTicketConfirmationJob>();
            Bind<ICarrierReadRepository>().To<WmDatabaseCarrierRepository>();
            Bind<ICountryReader>().To<DatabaseCountryRepository>();
            Bind<IManhattanOrderConfiguration>().To<ManhattanOrderConfiguration>();
            Bind<IOrderWriter>().To<ManhattanOrderWriter>();
            Bind<IOrderReader>().To<OmsOrderReader>();
            Bind<IManhattanOrderRepository>().To<ManhattanOrderRepository>();
            Bind<IPickConfiguration>().To<PickConfiguration>();
            Bind<ITransferControlManager>().To<TransferControlManager>();
            Bind<ITransferControlRepository>().To<TransferControlRepository>();
        }
    }
}
       