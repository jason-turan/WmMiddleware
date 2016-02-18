using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using Middleware.Wm.Aurora.PickTickets.Ftp;
using Middleware.Wm.Aurora.PickTickets.Repositories;
using Middleware.Wm.Configuration;
using Middleware.Wm.Inventory;
using Middleware.Wm.Locations;
using Middleware.Wm.Manhattan.Inventory;
using Middleware.Wm.Picking.Configuration;
using Middleware.Wm.Shipping;
using MiddleWare.Log;
using Middleware.Wm.TransferControl.Control;
using Middleware.Wm.TransferControl.Ftp;
using Middleware.Wm.TransferControl.Repositories;
using Ninject.Modules;

namespace Middleware.Wm.Aurora.PickTickets.DependencyInjection
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
            Bind<ICarrierReadRepository>().To<WmDatabaseCarrierRepository>().WithConstructorArgument("useThirdPartyBilling", true);
            Bind<IFtpClientFactory>().To<SftpClientFactory>();
            Bind<IFtpClientConfiguration>().To<AuroraFtpClientConfiguration>();
            Bind<ICountryReader>().To<DatabaseCountryRepository>();
            Bind<IManhattanOrderRepository>().To<ManhattanOrderRepository>();
            Bind<IPickConfiguration>().To<PickConfiguration>();
            Bind<ITransferControlManager>().To<TransferControlManager>();
        }
    }
}
       