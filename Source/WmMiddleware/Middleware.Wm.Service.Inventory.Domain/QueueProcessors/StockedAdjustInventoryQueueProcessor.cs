using Middleware.Wm.Service.Contracts.Models;
using Middleware.Wm.Service.Inventory.Domain.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.Wm.Service.Inventory.Domain.QueueProcessors
{
    public class StockedAdjustInventoryQueueProcessor
    {
        private ILogger _logger;

        public StockedAdjustInventoryQueueProcessor(ILogger logger) {
            _logger = logger;
        }

        public void Execute(PurchaseOrderStockedEvent model)
        {
            _logger.DumpInfo<StockedAdjustInventoryQueueProcessor>(model);
                        
        }
    }
}
