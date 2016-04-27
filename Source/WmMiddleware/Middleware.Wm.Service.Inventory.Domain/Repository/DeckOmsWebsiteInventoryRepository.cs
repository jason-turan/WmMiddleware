using System.Collections.Generic;
using Middleware.Wm.Service.Inventory.Models;

namespace Middleware.Wm.Service.Inventory.Repository
{
    public class DeckOmsWebsiteInventoryRepository : IWebsiteInventoryRepository
    {
        public List<InventoryQuantity> GetAvailableToSellInventory(InventorySearchFilter filter)
        {
            return new List<InventoryQuantity> { new InventoryQuantity("storeId", "locationId", new Product("UPC123"), 5, 3) };
        }

        public void UpdateAvailableInventory(ICollection<InventoryQuantity> inventoryQuantities)
        {
        }
    }
}