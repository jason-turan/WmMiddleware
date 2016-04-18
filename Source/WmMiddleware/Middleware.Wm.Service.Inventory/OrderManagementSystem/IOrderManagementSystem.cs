using Middleware.Wm.Service.Inventory.Domain.OrderManagementSystem.Models;
using Middleware.Wm.Service.Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.Wm.Service.Inventory.Domain.OrderManagementSystem
{
    public interface IOrderManagementSystemService
    {
        List<InventoryQuantity> GetAvailableToSellInventory(InventorySearchFilter filter);
        void UpdateAvailableInventory(UpdateInventoryRequest request);
    }
}
