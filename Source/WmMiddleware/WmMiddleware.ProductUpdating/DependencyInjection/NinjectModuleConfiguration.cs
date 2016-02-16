﻿using Middleware.Jobs;
using Ninject.Modules;
using WmMiddleware.Configuration;
using WmMiddleware.Configuration.Mainframe;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using WmMiddleware.ProductUpdating.Configuration;
using WmMiddleware.ProductUpdating.Repositories;
using WmMiddleware.TransferControl.Control;
using WmMiddleware.TransferControl.Ftp;
using WmMiddleware.TransferControl.Repositories;

namespace WmMiddleware.ProductUpdating.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<ProductUpdatingJob>();
            Bind<IJobRepository>().To<JobRepository>();
            Bind<ILog>().To<Log4Net>();
            Bind<IProductReader>().To<DatabaseProductRepository>();
            Bind<IProductWriter>().To<ManhattanProductRepository>();
            Bind<IMainframeConfiguration>().To<MainframeConfiguration>();
            Bind<IProductUpdatingConfiguration>().To<ProductUpdatingConfiguration>();
            Bind<ITransferControlRepository>().To<TransferControlRepository>();
            Bind<ITransferControlManager>().To<TransferControlManager>();
            Bind<IManhattanFtp>().To<ManhattanFtp>();
            Bind<IConfigurationManager>().To<MiddlewareConfigurationManager>();
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}
