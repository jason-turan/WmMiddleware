using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using Ninject.Modules;
using WmMiddleware.Configuration;
using WmMiddleware.TransferControl.Control;
using WmMiddleware.TransferControl.Ftp;
using WmMiddleware.TransferControl.Repositories;

namespace Middleware.Wm.Aurora.Shipment.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().To<Log4Net>();
            Bind<IJobRepository>().To<JobRepository>();
            Bind<IConfigurationManager>().To<MiddlewareConfigurationManager>();
            Bind<IUnitOfWork>().To<AuroraShipmentJob>();
            Bind<IFileIo>().To<FileIo>();
            Bind<ITransferControlRepository>().To<TransferControlRepository>();
            Bind<IFtpClientFactory>().To<SftpClientFactory>();
          // TODO  Bind<IFtpClientConfiguration>().To<AuroraFtpClientConfiguration>();
        }
    }
}
       