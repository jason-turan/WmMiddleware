using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using Middleware.Log;
using Middleware.Wm.Pix.Repository;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.Wm.PixNotification.DependencyInjection
{
    public class NinjectModuleConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().To<Log4Net>();
            Bind<IUnitOfWork>().To<PixNotificationJob>();
            Bind<IJobRepository>().To<JobRepository>();
            Bind<IPerpetualInventoryTransferRepository>().To<PerpetualInventoryTransferRepository>();
        }
    }
}
