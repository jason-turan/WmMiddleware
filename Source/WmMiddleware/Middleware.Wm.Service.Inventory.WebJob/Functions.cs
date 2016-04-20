using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure.Storage.Queue;
using System;

namespace Middleware.Wm.Service.Inventory.WebJob
{
    public class Functions
    {
        public static void HandleQueue([QueueTrigger("queue")] string message)
        {
            var actual = new Random().Next(0, 100);
            if (actual < 80)
            {
                throw new InvalidOperationException(String.Format("To bad try again. Actual {0} needed 50.", actual));
            }
        }

    }
}
