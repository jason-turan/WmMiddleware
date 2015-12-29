using Ninject.Modules;
using WmMiddleware.Configuration;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
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
            Bind<ITransferControlJob>().To<TransferControlJob>();
            Bind<IJobRepository>().To<JobRepository>();
            Bind<IManhattanFtp>().To<ManhattanFtp>();
            Bind<IFtpClient>().To<FtpClient>();
            Bind<ITransferControlOutbound>().To<TransferControlOutbound>();
            Bind<ITransferControlManager>().To<TransferControlManager>();
            Bind<ITransferControlInbound>().To<TransferControlInbound>();
            Bind<ITransferControlRepository>().To<TransferControlRepository>();
            Bind<IConfigurationManager>().To<MiddlewareConfigurationManager>();
        }
    }
}