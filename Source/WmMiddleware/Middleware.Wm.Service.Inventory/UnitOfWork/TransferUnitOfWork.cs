using Middleware.Wm.Service.Inventory.Domain.OrderManagementSystem;
using Middleware.Wm.Service.Inventory.Domain.OrderManagementSystem.Models;
using Middleware.Wm.Service.Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Middleware.Wm.Service.Inventory.Domain
{
    public class TransferUnitOfWork : IUnitOfWork<TransferRequest, TransferResponse>
    {
        private IOrderManagementSystemService _omsService;
        private IStoreIdTranslator _translator;

        public TransferUnitOfWork(IOrderManagementSystemService omsService, IStoreIdTranslator translator)
        {
            _omsService = omsService;
            _translator = translator;
        }

        public TransferResponse Execute(TransferRequest model)
        {
            var toSiteId = _translator.TranslateStoreIdToSiteId(model.ToStore.StoreId);
            var fromSiteId = _translator.TranslateStoreIdToSiteId(model.FromStore.StoreId);
             
            List<InventoryQuantity> availableToSell = _omsService.GetAvailableToSellInventory(new InventorySearchFilter()
            {
                StoreIds = new List<string>() {toSiteId,fromSiteId}
            });
            var transferred = new List<ProductQuantity>();
            foreach (var p in model.ProductsToTransfer) {
                var decrementQuantity = new ProductQuantity(p, p.Quantity * -1);                
                var inventoryTransferred = availableToSell.FirstOrDefault(iq => iq.Product.UPC == p.UPC);

                _omsService.UpdateAvailableInventory(new UpdateInventoryRequest() {
                    Quantity = decrementQuantity,
                    SiteId = fromSiteId
                });
                _omsService.UpdateAvailableInventory(new UpdateInventoryRequest()
                {
                    Quantity = p,
                    SiteId = toSiteId
                });
                transferred.Add(p);
            } 
            
            switch (model.TransferType)
            {
                case TransferType.PurchaseOrder: 
                    if(model.FromLocation.LocationId != model.ToLocation.LocationId)
                    {
                        //Create PO in warehouse
                    } 
                    break;
                case TransferType.ReturnToVendor:
                    //Create RTV in warehouse
                    break;
                default:
                    throw new InvalidOperationException();
            }
                         
            return new TransferResponse()
            {
                QuantitiesTransferred = transferred
            };
        }
    }
}
