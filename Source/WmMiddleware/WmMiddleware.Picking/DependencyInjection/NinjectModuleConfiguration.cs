﻿using Middleware.Jobs;
using Ninject.Modules;
using Middleware.Jobs.Repositories;
using Middleware.Wm.Inventory;
using Middleware.Wm.Locations;
using Middleware.Wm.Shipping;
using MiddleWare.Log;
using WmMiddleware.Configuration;
using WmMiddleware.Picking.Configuration;
using WmMiddleware.Picking.Repositories;
using WmMiddleware.TransferControl.Control;
using WmMiddleware.TransferControl.Repositories;

namespace WmMiddleware.Picking.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().To<Log4Net>();
            Bind<IUnitOfWork>().To<PickJob>();
            Bind<IOrderReader>().To<DatabasePickRepository>();
            Bind<IOrderWriter>().To<ManhattanPickRepository>();
            Bind<ICountryReader>().To<DatabaseCountryRepository>();
            Bind<IJobRepository>().To<JobRepository>();
            Bind<IPickConfiguration>().To<PickConfiguration>();
            Bind<ITransferControlRepository>().To<TransferControlRepository>();
            Bind<ITransferControlManager>().To<TransferControlManager>();
            Bind<IConfigurationManager>().To<MiddlewareConfigurationManager>();
            Bind<ICarrierReadRepository>().To<WmDatabaseCarrierRepository>();
        }
    }
}
