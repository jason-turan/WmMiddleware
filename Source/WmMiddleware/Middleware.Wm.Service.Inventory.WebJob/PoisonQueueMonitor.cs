using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs;

namespace Middleware.Wm.Service.Inventory.WebJob
{
    class PoisonQueueMonitor
    {

        public void StartupJob(
[TimerTrigger("0 0 */2 * * *", RunOnStartup = true)] TimerInfo timerInfo)
        {
            Console.WriteLine("Timer job fired!");
        }
    }
}
