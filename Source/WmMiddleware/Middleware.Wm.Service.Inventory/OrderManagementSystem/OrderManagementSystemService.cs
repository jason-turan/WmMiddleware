using NB.DTC.Aptos.InventoryService.Domain.OrderManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NB.DTC.Aptos.InventoryService.Domain.OrderManagementSystem.Models;
using NB.DTC.Aptos.InventoryService.Models;

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