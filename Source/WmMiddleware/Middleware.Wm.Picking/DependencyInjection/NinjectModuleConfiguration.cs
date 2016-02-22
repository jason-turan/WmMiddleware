using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using Middleware.Wm.Configuration;
using Middleware.Wm.Configuration.Mainframe;
using Middleware.Wm.Inventory;
using Middleware.Wm.Locations;
using Middleware.Wm.Manhattan.Control;
using Middleware.Wm.Manhattan.Inventory;
using Middleware.Wm.Picking.Repositories;
using Middleware.Wm.Shipping;
using Middleware.Wm.TransferControl.Control;
using Middleware.Wm.TransferControl.Repositories;
using Ninject.Modules;

namespace Middleware.Wm.Picking.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().To<Log4Net>();
            Bind<IUnitOfWork>().To<PickJob>();
            Bind<IOrderReader>().To<DatabasePickRepository>();
            Bind<IOrderWriter>().To<ManhattanPickRepository>();
            Bind<ICountryReader>().To<DatabaseCountryRepository>();
            Bind<IJobRepository>().To<JobRepository>();
            Bind<IPickConfiguration>().To<PickConfiguration>();
            Bind<ITransferControlRepository>().To<TransferControlRepository>();
            Bind<ITransferControlManager>().To<TransferControlManager>();
            Bind<IConfigurationManager>().To<MiddlewareConfigurationManager>();
            Bind<ICarrierReadRepository>().To<WmDatabaseCarrierRepository>().WithConstructorArgument("useThirdPartyBilling", false);

        }
    }
}
