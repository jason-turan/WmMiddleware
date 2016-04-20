using System;
using System.Collections.Generic;
using Middleware.Wm.Service.Inventory.Models;
using Middleware.Wm.Service.Inventory.Repository;

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

        public ICollection<ProductQuantity> CreateTransfer(TransferType transferType, IEnumerable<ProductQuantity> productsToTransfer, ILocation fromLocation, ILocation toLocation)
        {
            throw new NotImplementedException();
        }
    }
}