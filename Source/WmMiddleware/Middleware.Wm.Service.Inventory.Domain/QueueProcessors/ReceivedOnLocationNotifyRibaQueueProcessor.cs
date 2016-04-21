using Middleware.Wm.Service.Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.Wm.Service.Inventory.Domain.QueueProcessors
{
    public class ReceivedOnLocationNotifyRibaQueueProcessor : IQueueProcessor<PurchaseOrder>
    {
        public void Execute(PurchaseOrder model)
        {
            throw new NotImplementedException();
        }
    }
}
