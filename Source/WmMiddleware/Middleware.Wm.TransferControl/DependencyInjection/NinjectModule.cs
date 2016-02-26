using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using Middleware.Log;
using Middleware.Wm.Configuration;
using Middleware.Wm.Manhattan.Control;
using Middleware.Wm.TransferControl.Configuration;
using Middleware.Wm.TransferControl.Control;
using Middleware.Wm.TransferControl.Ftp;
using Middleware.Wm.TransferControl.Repositories;
using Ninject.Modules;

namespace Middleware.Wm.TransferControl.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().To<Log4Net>();
            Bind<IFileIo>().To<FileIo>();
            Bind<IUnitOfWork>().To<TransferControlJob>();
            Bind<IJobRepository>().To<JobRepository>();
            Bind<IMainframeFtp>().To<MainframeFtp>();
            Bind<ITransferControlOutbound>().To<TransferControlOutbound>();
            Bind<ITransferControlManager>().To<TransferControlManager>();
            Bind<ITransferControlInbound>().To<TransferControlInbound>();
            Bind<ITransferControlRepository>().To<TransferControlRepository>();
            Bind<IConfigurationManager>().To<MiddlewareConfigurationManager>();
            Bind<ITransferControlConfigurationManager>().To<TransferControlConfigurationManager>();
            Bind<IFtpClientFactory>().To<FtpClientFactory>();
            Bind<IFtpClientConfiguration>().To<MainframeFtpConfiguration>();
        }
    }
}