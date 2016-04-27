using Middleware.Wm.Service.Inventory.Models;
using System.Collections.Generic;

namespace Middleware.Wm.Service.Inventory.Repository
{
    public interface IWebsiteInventoryRepository
    {
        void UpdateAvailableInventory(ICollection<InventoryQuantity> inventoryQuantities);
        List<InventoryQuantity> GetAvailableToSellInventory(InventorySearchFilter filter);
    }
}
