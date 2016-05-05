using Middleware.Wm.Service.Contracts.Models;
using Middleware.Wm.Service.Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.Wm.Service.Contracts
{
    public interface IIventoryServiceApi
    {
        void PhysicalInventoryChanged(List<PhysicalAdjustment> adjustments);
        void PurchaseOrderReceived(PurchaseOrderReceiptEvent purchaseOrderReceiptEvent);
        void PurchaseOrderStocked(PurchaseOrderStockedEvent purchaseOrderStockedEvent);
    }
}
