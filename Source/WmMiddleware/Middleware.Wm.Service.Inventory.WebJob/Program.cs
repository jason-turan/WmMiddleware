using Microsoft.Azure.WebJobs;
using Ninject;
using Middleware.Wm.Service.Inventory.Domain.Logging;
using Middleware.Wm.Service.Inventory.Domain;
using Middleware.Wm.Service.Inventory.Repository;

namespace Middleware.Wm.Service.Inventory.WebJob
{
    class Program
    {
        static void Main()
        {
            var kernel = new StandardKernel();
            RegisterServices(kernel);            
            var hostConfiguration = new JobHostConfiguration() {
                JobActivator = new NinjectJobActivator(kernel)
            };
            var host = new JobHost(hostConfiguration);
            host.RunAndBlock();
        }

        private static void RegisterServices(StandardKernel kernel)
        {
            kernel.Bind<ILogger>().To<Logger>();
            kernel.Bind<IQueue>().To<Queue>();
            kernel.Bind<IWebsiteInventoryRepository>().To<DeckOmsWebsiteInventoryRepository>();
        }
    }
}
