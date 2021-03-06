﻿using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Middleware.Wm.Service.Contracts;
using Middleware.Wm.Service.Inventory.Domain;
using Middleware.Wm.Service.Inventory.Models;
using Middleware.Wm.Service.Inventory.Repository;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;  
using Middleware.Wm.Service.Contracts.Models;
using System.Linq;
using Middleware.Wm.Service.Inventory.WebJob.Models;

namespace Middleware.Wm.Service.Inventory.Controllers
{
    public class InventoryController : ApiController, IIventoryServiceApi
    {
        private IQueue _queue;
        private IWebsiteRepository _websiteRepository;
        private IPurchaseOrderEventHandler _poEventHandler;
        private IWebsiteInventoryRepository _websiteInventoryRepository;
        private IPhysicalAdjustmentEventHandler _physicalAdjustmentEventHandler;

        public InventoryController(
            IQueue queue,
            IWebsiteRepository websiteRepository,
            IWebsiteInventoryRepository websiteInventoryRepository,
            IPurchaseOrderEventHandler purchaseOrderEventHandler,
            IPhysicalAdjustmentEventHandler physicalAdjustmentEventHandler)
        {
            _queue = queue;
            _websiteRepository = websiteRepository;
            _websiteInventoryRepository = websiteInventoryRepository;
            _poEventHandler = purchaseOrderEventHandler;
            _physicalAdjustmentEventHandler = physicalAdjustmentEventHandler;
        }

        /// <summary>
        /// API used to send inventory quantity changes originating within the Warehouse Management layer to the downstream order and merch systems.
        /// </summary>
        /// <remarks>
        /// This service is used to handle the following scenarios. <br/>1) Untracked sale <br/>2) Cycle count <br/>3) Gifted <br/>4) Destroyed <br/> <br/>**Action Items** <br/>1) BNC orders need to have the export to OMS turned off in order to not double dip into site inventory - Dependent upon OMS order update logic <br/>2) **Steve/Jason/Kyle** - Determine fields currently associated with WM inventory changes
        /// </remarks>
        /// <param name="adjustments">The adjustment</param> 
        [HttpPost]
        [Route("Adjustment/PhysicalInventoryChanged")]
        public void PhysicalInventoryChanged(List<PhysicalAdjustment> adjustments)
        {
            _physicalAdjustmentEventHandler.PhysicalInventoryChanged(adjustments);
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
            var losingWebsite = _websiteRepository.GetByStoreId(request.FromStoreId);
            var gainingWebsite = _websiteRepository.GetByStoreId(request.ToStoreId);

            var availableToSell = _websiteInventoryRepository.GetAvailableToSellInventory(new InventorySearchFilter { SiteIds = new[] { losingWebsite.SiteId } });

            var updatedProducts = 
                availableToSell
                .Concat(
                    availableToSell
                    .Select(
                        ats =>  new InventoryQuantity(ats.StoreId, ats.LocationId, ats.Product, -ats.QuantityOnHand, -ats.QuantityAvailableToSell)
                    )
                ).ToList();

            _websiteInventoryRepository.UpdateAvailableInventory(updatedProducts);

            return new TransferResponse { QuantitiesTransferred = null };
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
        [Route("Order/ReceivedOnLocation")]
        public void PurchaseOrderReceived(PurchaseOrderReceiptEvent purchaseOrderReceiptEvent)
        {            
            _poEventHandler.PurchaseOrderReceived(purchaseOrderReceiptEvent);
        }

        /// <summary>
        /// Execute workflow associated completion of stocking of a purchase order into the warehouse.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="stockedQuantities"></param>
        [HttpPost]
        [Route("Order/Stocked")]
        public void PurchaseOrderStocked(PurchaseOrderStockedEvent stockedQuantities)
        {
            _poEventHandler.PurchaseOrderStocked(stockedQuantities);
        }

        [HttpGet]
        [Route("HealthCheck")]
        public HealthCheckModel HealthCheck()
        {
            var hcm = new HealthCheckModel()
            {
                Version = System.Diagnostics.FileVersionInfo.GetVersionInfo(typeof(InventoryController).Assembly.Location).ProductVersion,
                Running = true,
                Components = new List<ComponentCheckModel>()
                {
                    new ComponentCheckModel()
                    {
                        ComponentName= "TEST",
                        Status= ComponentStatus.Running,
                        Message = ""
                    }
                }
            };
            return hcm;           
        }
         
    }
}
