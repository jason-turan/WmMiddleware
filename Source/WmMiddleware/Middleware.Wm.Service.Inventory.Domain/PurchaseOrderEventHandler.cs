using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Middleware.Wm.Service.Inventory.Models;
using Middleware.Wm.Service.Inventory.Repository;

namespace Middleware.Wm.Service.Inventory.Domain
{
    public class PurchaseOrderEventHandler : IPurchaseOrderEventHandler
    {
        private IPurchaseOrderRepository _purchaseOrderRepository;
        private IQueue _queue;

        public PurchaseOrderEventHandler(IQueue queue, IPurchaseOrderRepository repository)
        {
            _queue = queue;
            _purchaseOrderRepository = repository;
        }


        public void InventoryStocked(List<ProductQuantity> stockedQuantities)
        {
            throw new NotImplementedException();
        }
        
        public void ReceivedOnLocation(PurchaseOrderReceiptEvent purchaseOrderReceiptEvent)
        {
            var po = _purchaseOrderRepository.GetPurchaseOrder(purchaseOrderReceiptEvent.PurchaseOrderNumber);
            if(po != null)
            {
                _queue.QueueWorkItem(QueueNames.ReceivedOnLocationNotifyRiba, po);
            }
            else
            {
                throw new InvalidOperationException();
            }
             
            //Get purchase order from repository. It should have been created when the transfer request was made.
            //If purchase order was found. 
            //Send Po Receipt to Riba
            //Else
            //Log warning
            //Probably invalid case. PO received at warehouse without a prior ASN
            //Insert PO into database 
            //var po = _purchaseOrderRepository.GetPurchaseOrder(purchaseOrderReceiptEvent.PurchaseOrderNumber);
            ////TODO make this a reliable call
            //_ribaSystem.ReceivedOnLocation(po);
        }
    }
}