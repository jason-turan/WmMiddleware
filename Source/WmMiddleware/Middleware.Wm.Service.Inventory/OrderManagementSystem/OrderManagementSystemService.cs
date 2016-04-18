using Middleware.Wm.Service.Inventory.Domain.OrderManagementSystem;
using Middleware.Wm.Service.Inventory.Domain.OrderManagementSystem.Models;
using Middleware.Wm.Service.Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Middleware.Wm.Service.Inventory.OrderManagementSystem
{
    public class OrderManagementSystemService : IOrderManagementSystem
    {
        public List<InventoryQuantity> GetAvailableToSellInventory(InventorySearchFilter filter)
        {
            throw new NotImplementedException();
        }

        public void UpdateAvailableInventory(UpdateInventoryRequest request)
        {
            throw new NotImplementedException();
        }
    }
}