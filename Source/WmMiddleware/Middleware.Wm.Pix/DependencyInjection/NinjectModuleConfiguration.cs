using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using Middleware.Wm.Configuration;
using Middleware.Wm.Pix.Repository;
using Middleware.Wm.TransferControl.Control;
using Middleware.Wm.TransferControl.Repositories;
using Ninject.Modules;
using WmMiddleware.Pix;

namespace Middleware.Wm.Pix.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().To<Log4Net>();
            Bind<IUnitOfWork>().To<PixJob>();
            Bind<IJobRepository>().To<JobRepository>();
            Bind<ITransferControlRepository>().To<TransferControlRepository>();
            Bind<IPerpetualInventoryTransferRepository>().To<PerpetualInventoryTransferRepository>();
            Bind<IConfigurationManager>().To<MiddlewareConfigurationManager>();
            Bind<IFileIo>().To<FileIo>();
        }
    }
}
       