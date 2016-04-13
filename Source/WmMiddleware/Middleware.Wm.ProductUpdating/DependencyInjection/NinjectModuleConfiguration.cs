using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using Middleware.Log;
using Middleware.Wm.Configuration;
using Middleware.Wm.Configuration.Mainframe;
using Middleware.Wm.Manhattan.Control;
using Middleware.Wm.ProductUpdating.Configuration;
using Middleware.Wm.ProductUpdating.Repositories;
using Middleware.Wm.TransferControl.Control;
using Middleware.Wm.TransferControl.Ftp;
using Middleware.Wm.TransferControl.Repositories;
using Ninject.Modules;

namespace Middleware.Wm.ProductUpdating.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<ProductUpdatingJob>();
            Bind<IJobRepository>().To<JobRepository>();
            Bind<ILog>().To<Log4Net>();
            Bind<IProductReader>().To<DatabaseProductRepository>();
            Bind<IProductWriter>().To<ManhattanProductRepository>();
            Bind<IMainframeConfiguration>().To<MainframeConfiguration>();
            Bind<IProductUpdatingConfiguration>().To<ProductUpdatingConfiguration>();
            Bind<ITransferControlRepository>().To<TransferControlRepository>();
            Bind<ITransferControlManager>().To<TransferControlManager>();
            Bind<IMainframeFtp>().To<MainframeFtp>();
            Bind<IConfigurationManager>().To<MiddlewareConfigurationManager>();
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}
