using Middleware.Wm.Service.Inventory.Models;
using System.Collections.Generic;

namespace Middleware.Wm.Service.Inventory.Repository
{
    public interface IWebsiteInventoryRepository
    {
        void UpdateAvailableInventory(UpdateInventoryRequest request);
        List<InventoryQuantity> GetAvailableToSellInventory(InventorySearchFilter filter);
    }
}
