using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using Middleware.WarehouseManagement.Aurora.PickTickets.Ftp;
using Middleware.WarehouseManagement.Aurora.PickTickets.Repositories;
using Middleware.Wm.Inventory;
using Middleware.Wm.Locations;
using Middleware.Wm.Shipping;
using MiddleWare.Log;
using Ninject.Modules;
using WmMiddleware.Configuration;
using WmMiddleware.TransferControl.Control;
using WmMiddleware.TransferControl.Ftp;
using WmMiddleware.TransferControl.Repositories;

namespace Middleware.WarehouseManagement.Aurora.PickTickets.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().To<Log4Net>();
            Bind<IJobRepository>().To<JobRepository>();
            Bind<IConfigurationManager>().To<MiddlewareConfigurationManager>();
            Bind<IUnitOfWork>().To<PickTicketJob>();
            Bind<IOrderWriter>().To<XmlOrderWriter>();
            Bind<IFileIo>().To<FileIo>();
            Bind<ITransferControlRepository>().To<TransferControlRepository>();
            Bind<ICarrierReadRepository>().To<WmDatabaseCarrierRepository>();
            Bind<IFtpClientFactory>().To<SftpClientFactory>();
            Bind<IFtpClientConfiguration>().To<AuroraFtpClientConfiguration>();
            Bind<ICountryReader>().To<DatabaseCountryRepository>();
        }
    }
}
       