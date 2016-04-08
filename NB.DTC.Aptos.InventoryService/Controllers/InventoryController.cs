using NB.DTC.Aptos.InventoryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NB.DTC.Aptos.InventoryService.Controllers
{
    public class InventoryController : ApiController
    {
        /// <summary>
        /// API used to send inventory quantity changes originating within the Warehouse Management layer to the downstream order and merch systems.
        /// </summary>
        /// <remarks>
        /// This service is used to handle the following scenarios. <br/>1) Untracked sale <br/>2) Cycle count <br/>3) Gifted <br/>4) Destroyed <br/> <br/>**Action Items** <br/>1) BNC orders need to have the export to OMS turned off in order to not double dip into site inventory - Dependent upon OMS order update logic <br/>2) **Steve/Jason/Kyle** - Determine fields currently associated with WM inventory changes
        /// </remarks>
        /// <param name="adjustment">The adjustment</param> 
        [HttpPost]
        [Route("Adjustment/PhysicalInventoryChange")]
        public void PhysicalInventoryChange(PhysicalAdjustment adjustment)
        { 
        }
        ///<summary>
        /// Inventory search by site and warehouse.
        ///</summary>
        /// <remarks>
        /// API used to search for Available To Sell inventory.  
        /// This service is used to confirm availability prior to processing orders or transfers that are sensitive to availability.  
        /// It also is used to identify the difference between what is Sellable and what is on-hand from a sales channel 
        /// perspective. 
        ///         
        /// </remarks>
        /// <returns>Inventory levels for the given parameters</returns>
        [HttpPost]
        [Route("Search/AvailableToSell")]
        public List<InventoryQuantity> SearchAvailableToSell(InventorySearchFilter filter)
        {
            return new List<InventoryQuantity>();
        }

        /// <summary>
        /// Execute a PO or Transfer against a specific site/store and location.
        /// </summary>
        /// <remarks>
        /// Any scenario that requires either an inventory ownership change or a location change 
        /// should create a transfer to execute that change with the Warehouse.  
        /// Transfers should be used to handle all of the move scenarios currently requested below. 
        /// -Site PO 
        /// -RTV 
        /// -Site to site transfers 
        /// Site to store transfers         
        /// </remarks>
        [HttpPost]
        [Route("Order/CreateTransfer")]
        public TransferResponse CreateTransfer(TransferRequest request)
        {
            return new TransferResponse();
        } 

        /// <summary>
        /// Execute workflow associated with the receipt of an Order into the Warehouse.
        /// </summary>
        /// <remarks>
        /// This flow is responsible for notification of a receipt of inventory into the warehouse.  
        /// It is responsible for updating merch with the change in inventory ownership and OMS with the change 
        /// of available inventory. 
        /// </remarks>
        [HttpPost]
        [Route("Order/LocationReceived")]
        public void LocationReceived(PurchaseOrderReceiptEvent purchaseOrderReceiptEvent)
        {

        }

        /// <summary>
        /// Execute workflow associated with the update of sellable inventory.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="stockedQuantities"></param>
        [HttpPost]
        [Route("Order/InventoryStocked")]
        public void InventoryStocked(List<ProductQuantity> stockedQuantities)
        { 

        }
    }
}
