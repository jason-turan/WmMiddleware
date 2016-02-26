using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using Middleware.Log;
using Middleware.Log.Repository;
using Middleware.Wm.Configuration;
using Middleware.Wm.Manhattan.Inventory;
using Middleware.Wm.Pix.Repository;
using Middleware.Wm.PixReturn.Repository;
using Ninject.Modules;

namespace Middleware.Wm.PixReturn.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().To<Log4Net>();
            Bind<IUnitOfWork>().To<PixReturnJob>();
            Bind<IConfigurationManager>().To<MiddlewareConfigurationManager>();
            Bind<IDatabaseRowReturnRepository>().To<DatabaseRowReturnRepository>();
            Bind<IPerpetualInventoryTransferRepository>().To<PerpetualInventoryTransferRepository>();
            Bind<IManhattanConditionCodeRepository>().To<ManhattanConditionCodeRepository>();
            Bind<IPixReturnRepository>().To<PixReturnRepository>();
            Bind<IJobRepository>().To<JobRepository>();
            Bind<IOmsManhattanOrderMapRepository>().To<OmsManhattanOrderMapRepositiory>();
            Bind<IOrderHistoryRepository>().To<OrderHistoryRepository>();
        }
    }
}
       