﻿using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using Middleware.Wm.Aurora.Shipment.Repository;
using Ninject.Modules;
using WmMiddleware.Configuration;
using WmMiddleware.Configuration.Mainframe;
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
            Bind<IDatabaseKioskOrderExportRepository>().To<DatabaseKioskOrderExportRepository>();
            Bind<IAuroraShipmentRepository>().To<AuroraShipmentRepository>();
            Bind<ITransferControlRepository>().To<TransferControlRepository>();
            Bind<ITransferControlManager>().To<TransferControlManager>();
            Bind<IMainframeConfiguration>().To<MainframeConfiguration>();
           // Bind<IFtpClientConfiguration>().To<AuroraFtpClientConfiguration>();
        }
    }
}
       