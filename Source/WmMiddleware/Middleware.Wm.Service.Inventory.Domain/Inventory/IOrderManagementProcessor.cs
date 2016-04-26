using Middleware.Wm.Service.Inventory.Models;
using System.Collections.Generic;

namespace Middleware.Wm.Service.Inventory.Domain.OrderManagement
{
    public interface IOrderManagementProcessor
    {
        ICollection<ProductQuantity> CreateTransfer(TransferType transferType, ICollection<ProductQuantity> productsToTransfer, string losingStoreId, string gainingStoreId, Location fromLocation, Location toLocation);
    }
}
