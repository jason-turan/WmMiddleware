using Middleware.Wm.Service.Inventory.Domain.Logging;
using Middleware.Wm.Service.Inventory.Domain.RibaSystem.Models;

namespace Middleware.Wm.Service.Inventory.Domain.RibaSystem
{
    public class StubbedRibaSystem : IRibaSystem
    {
        private ILogger _logger;

        public StubbedRibaSystem(ILogger logger)
        {
            _logger = logger;
        }

        public void SendPurchaseOrderReceipt(PurchaseOrderReceipt po)
        {
            _logger.DumpInfo<StubbedRibaSystem>(po);            
        }
    }
}
