using Ninject.Modules;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using WmMiddleware.Pix.Repository;
using WmMiddleware.TransferControl.Repositories;

namespace WmMiddleware.Pix.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().To<Log4Net>();
            Bind<IPixJob>().To<PixJob>();
            Bind<IJobRepository>().To<JobRepository>();
            Bind<ITransferControlRepository>().To<TransferControlRepository>();
            Bind<IPerpetualInventoryTransferRepository>().To<PerpetualInventoryTransferRepository>();
        }
    }
}