using NB.DTC.Aptos.InventoryService.Domain.OrderManagementSystem.Models;
using NB.DTC.Aptos.InventoryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NB.DTC.Aptos.InventoryService.Domain.OrderManagementSystem
{
    public interface IOrderManagementSystemService
    {
        List<InventoryQuantity> GetAvailableToSellInventory(InventorySearchFilter filter);
        void UpdateAvailableInventory(UpdateInventoryRequest request);
    }
}
