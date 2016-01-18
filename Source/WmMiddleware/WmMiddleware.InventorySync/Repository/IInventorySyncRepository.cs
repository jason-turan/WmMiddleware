using System.Collections.Generic;
using WmMiddleware.InventorySync.Models;

namespace WmMiddleware.InventorySync.Repository
{
    public interface IInventorySyncRepository
    {
        void InsertInventorySync(IList<Models.Generated.ManhattanInventorySync> inventorySync);

        void SetAsReceived(InventorySyncProcessing inventorySyncProcessing);

        void SetAsProcessed(InventorySyncProcessing inventorySyncProcessing);
    }
}