using Middleware.Wm.Service.Inventory.Models;
using System.Collections.Generic;

namespace Middleware.Wm.Service.Inventory.OrderManagement
{
    public interface IOrderManagementProcessor
    {
        ICollection<ProductQuantity> CreateTransfer(TransferType transferType, IEnumerable<ProductQuantity> productsToTransfer, Location fromLocation, Location toLocation);
    }
}
