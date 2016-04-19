using System;
using System.Collections.Generic;
using Middleware.Wm.Service.Inventory.Models;

namespace Middleware.Wm.Service.Inventory.Repository
{
    public class DeckOmsWebsiteInventoryRepository : IWebsiteInventoryRepository
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