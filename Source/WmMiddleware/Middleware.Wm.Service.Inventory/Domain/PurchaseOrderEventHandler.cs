using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Middleware.Wm.Service.Inventory.Models;
using Middleware.Wm.Service.Inventory.Repository;
using Middleware.Wm.Service.Inventory.RibaSystem;

namespace Middleware.Wm.Service.Inventory.Domain
{
    public class PurchaseOrderEventHandler : IPurchaseOrderEventHandler
    {
        IPurchaseOrderRepository _purchaseOrderRepository;
        IRibaSystem _ribaSystem;

        public void InventoryStocked(List<ProductQuantity> stockedQuantities)
        {
            throw new NotImplementedException();
        }

        public void ReceivedOnLocation(PurchaseOrderReceiptEvent purchaseOrderReceiptEvent)
        {
            var po = _purchaseOrderRepository.GetPurchaseOrder(purchaseOrderReceiptEvent.PurchaseOrderNumber);

            //TODO make this a reliable call
            _ribaSystem.ReceivedOnLocation(po);
        }
    }
}