using System;
using System.Collections.Generic;
using Middleware.Wm.Service.Inventory.Models;
using Middleware.Wm.Service.Inventory.Repository;
using System.Linq;

namespace Middleware.Wm.Service.Inventory.OrderManagement
{
    public class OrderManagementProcessor : IOrderManagementProcessor
    {
        private IWebsiteInventoryRepository _websiteInventoryRepository;
        private IWebsiteRepository _websiteRepository;

        public OrderManagementProcessor(IWebsiteRepository websiteRepository, IWebsiteInventoryRepository websiteInventoryRepository)
        {
            _websiteRepository = websiteRepository;
            _websiteInventoryRepository = websiteInventoryRepository;
        }

        public ICollection<ProductQuantity> CreateTransfer(TransferType transferType, ICollection<ProductQuantity> productsToTransfer, string losingStoreId, string gainingStoreId, Location fromLocation, Location toLocation)
        {
            List<ProductQuantity> updatedInventory = null;

            if(productsToTransfer.Any(p => p.Quantity <= 0))
            {
                throw new ArgumentOutOfRangeException("Quantities must be positive.");
            }

            if(losingStoreId != gainingStoreId)
            {
                var losingWebsite = _websiteRepository.GetByStoreId(losingStoreId);
                var gainingWebsite = _websiteRepository.GetByStoreId(gainingStoreId);

                if(losingWebsite == null || gainingWebsite == null)
                {
                    throw new ArgumentException("Could not find websites.");
                }

                //var availableToSell = _websiteInventoryRepository.GetAvailableToSellInventory(new InventorySearchFilter { SiteIds = new[] { losingWebsite.SiteId } });

                updatedInventory = _websiteInventoryRepository.UpdateAvailableInventory(new UpdateInventoryRequest { ProductUpdateQuantities = productsToTransfer, SiteId = losingWebsite.SiteId });
                foreach(var product in updatedInventory)
                {
                    product.Quantity = -product.Quantity;
                }

                _websiteInventoryRepository.UpdateAvailableInventory(new UpdateInventoryRequest { ProductUpdateQuantities = updatedInventory, SiteId = gainingWebsite.SiteId });
            }

            if(fromLocation != toLocation)
            {
                throw new NotImplementedException();
            }

            return updatedInventory;
        }
    }
}