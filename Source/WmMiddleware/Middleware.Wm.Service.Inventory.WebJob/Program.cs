using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Ninject;

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
        }
    }
}
