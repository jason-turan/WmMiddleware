using Middleware.Jobs;
using Ninject.Modules;
using WmMiddleware.Configuration;
using WmMiddleware.Configuration.Mainframe;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using WmMiddleware.ProductReceiving.Repositories;
using WmMiddleware.TransferControl.Control;
using WmMiddleware.TransferControl.Repositories;

namespace WmMiddleware.ProductReceiving.DependencyInjection
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
