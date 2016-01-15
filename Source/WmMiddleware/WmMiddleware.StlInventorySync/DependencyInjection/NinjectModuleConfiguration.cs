using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Middleware.Jobs.Repositories;
using MiddleWare.Log;
using Ninject.Modules;
using WmMiddleware.InventorySync.Repository;
using WmMiddleware.StlInventorySync.Repository;
using WmMiddleware.TransferControl.Repositories;
using WmMiddleware.Configuration;

namespace WmMiddleware.StlInventorySync.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().To<Log4Net>();
            Bind<IStlInventorySyncJob>().To<StlInventorySyncJob>();
            Bind<IStlInventoryRepository>().To<StlInventoryRepository>();
            Bind<IInventorySyncRepository>().To<InventorySyncRepository>();
            Bind<IJobRepository>().To<JobRepository>();
            Bind<IConfigurationManager>().To<MiddlewareConfigurationManager>();
        }
    }
}
