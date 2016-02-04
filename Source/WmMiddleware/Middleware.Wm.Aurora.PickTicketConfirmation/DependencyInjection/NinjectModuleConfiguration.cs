using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using Middleware.Wm.Locations;
using Middleware.Wm.Shipping;
using MiddleWare.Log;
using Ninject.Modules;
using WmMiddleware.Configuration;

namespace Middleware.Wm.Aurora.PickTicketConfirmation.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().To<Log4Net>();
            Bind<IJobRepository>().To<JobRepository>();
            Bind<IConfigurationManager>().To<MiddlewareConfigurationManager>();
            Bind<IUnitOfWork>().To<PickTicketConfirmationJob>();
            Bind<ICarrierReadRepository>().To<WmDatabaseCarrierRepository>();
            Bind<ICountryReader>().To<DatabaseCountryRepository>();
        }
    }
}
       