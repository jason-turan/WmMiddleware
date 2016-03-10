using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using Middleware.Log;
using Middleware.Log.Repository;
using Middleware.Wm.Aurora.PickTickets.Ftp;
using Middleware.Wm.Aurora.PickTickets.Repositories;
using Middleware.WM.Aurora.TransferControl.Configuration;
using Middleware.Wm.Configuration;
using Middleware.Wm.Configuration.Mainframe;
using Middleware.Wm.Inventory;
using Middleware.Wm.Locations;
using Middleware.Wm.Manhattan.Control;
using Middleware.Wm.Manhattan.Inventory;
using Middleware.Wm.Shipping;
using Middleware.Wm.TransferControl.Configuration;
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
            Bind<IFtpClientConfiguration>().To<OmsFtpClientConfiguration>();
            Bind<ICountryReader>().To<DatabaseCountryRepository>();
            Bind<IManhattanOrderRepository>().To<ManhattanOrderRepository>();
            Bind<IPickConfiguration>().To<PickConfiguration>();
            Bind<ITransferControlManager>().To<TransferControlManager>();
            Bind<IAuroraPickTicketRepository>().To<AuroraPickTicketRepository>();
            Bind<IMainframeOrderConfiguration>().To<ManhattanOrderConfiguration>();
            Bind<IOrderHistoryRepository>().To<OrderHistoryRepository>();
            Bind<ITransferControlConfigurationManager>().To<AuroraTransferControlConfigurationManager>();
        }
    }
}
       