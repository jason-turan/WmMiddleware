using Middleware.Jobs;
using Ninject.Modules;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using WmMiddleware.Configuration;
using WmMiddleware.Pix.Repository;
using WmMiddleware.TransferControl.Control;
using WmMiddleware.TransferControl.Repositories;

namespace WmMiddleware.Pix.DependencyInjection
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
       