using Middleware.Jobs;
using Ninject.Modules;
using WmMiddleware.Configuration;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using WmMiddleware.TransferControl.Configuration;
using WmMiddleware.TransferControl.Control;
using WmMiddleware.TransferControl.Ftp;
using WmMiddleware.TransferControl.Repositories;

namespace WmMiddleware.TransferControl.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().To<Log4Net>();
            Bind<IFileIo>().To<FileIo>();
            Bind<IUnitOfWork>().To<TransferControlJob>();
            Bind<IJobRepository>().To<JobRepository>();
            Bind<IManhattanFtp>().To<ManhattanFtp>();
            Bind<ITransferControlOutbound>().To<TransferControlOutbound>();
            Bind<ITransferControlManager>().To<TransferControlManager>();
            Bind<ITransferControlInbound>().To<TransferControlInbound>();
            Bind<ITransferControlRepository>().To<TransferControlRepository>();
            Bind<IConfigurationManager>().To<MiddlewareConfigurationManager>();
            Bind<ITransferControlConfigurationManager>().To<TransferControlConfigurationManager>();
            Bind<IFtpClientFactory>().To<FtpClientFactory>();
            Bind<IFtpClientConfiguration>().To<ManhattanFtpConfiguration>();
        }
    }
}