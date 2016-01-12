using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using Ninject.Modules;
using WmMiddleware.Configuration;
using WmMiddleware.Configuration.Manhattan;
using WmMiddleware.ProductReceiving.Repositories;
using WmMiddleware.TransferControl.Control;
using WmMiddleware.TransferControl.Repositories;

namespace WmMiddleware.ProductReturn.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductReturnJob>().To<ProductReturnJob>();
            Bind<IJobRepository>().To<JobRepository>();
            Bind<ILog>().To<Log4Net>();
            Bind<IReceivedProductReader>().To<DatabaseReceivedProductRepository>();
            Bind<IReceivedProductWriter>().To<ManhattanReceivedProductRepository>();
            Bind<IManhattanConfiguration>().To<ManhattanConfiguration>();
            Bind<ITransferControlRepository>().To<TransferControlRepository>();
            Bind<ITransferControlManager>().To<TransferControlManager>();
            Bind<IConfigurationManager>().To<MiddlewareConfigurationManager>();
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}
