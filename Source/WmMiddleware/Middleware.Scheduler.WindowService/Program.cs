using System.Diagnostics;
using System.ServiceProcess;
using Middleware.Scheduler.WindowService.Scheduler;

namespace Middleware.Scheduler.WindowService
{
    internal static class Program
    {
        private static void Main()
        {
            if (Debugger.IsAttached)
            {
                Server.BootStrap().StartJobs();
            }
            else
            {
                var servicesToRun = new ServiceBase[]
                {
                    new WindowsServiceScheduler()
                };

                ServiceBase.Run(servicesToRun);
            }
        }
    }
}
