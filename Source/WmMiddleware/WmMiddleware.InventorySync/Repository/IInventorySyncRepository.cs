using System.Collections.Generic;

namespace WmMiddleware.InventorySync.Repository
{
    public interface IInventorySyncRepository
    {
        void InsertInventorySync(IList<Models.Generated.InventorySync> inventorySync);
    }
}