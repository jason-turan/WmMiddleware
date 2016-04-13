using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using Middleware.Log;
using Middleware.Wm.Configuration;
using Middleware.Wm.Configuration.Mainframe;
using Middleware.Wm.Manhattan.Control;
using Middleware.Wm.ProductReceiving.Repositories;
using Middleware.Wm.TransferControl.Control;
using Middleware.Wm.TransferControl.Repositories;
using Ninject.Modules;

namespace Middleware.Wm.ProductReceiving.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<ProductReceivingJob>();
            Bind<IJobRepository>().To<JobRepository>();
            Bind<ILog>().To<Log4Net>();
            Bind<IReceivedProductReader>().To<DatabaseReceivedProductRepository>();
            Bind<IReceivedProductWriter>().To<ManhattanReceivedProductRepository>();
            Bind<IMainframeConfiguration>().To<MainframeConfiguration>();
            Bind<ITransferControlRepository>().To<TransferControlRepository>();
            Bind<ITransferControlManager>().To<TransferControlManager>();
            Bind<IConfigurationManager>().To<MiddlewareConfigurationManager>();
        }
    }
}
