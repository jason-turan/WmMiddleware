using System.Collections.Generic;
using WmMiddleware.InventorySync.Models;
using WmMiddleware.InventorySync.Models.Generated;

namespace WmMiddleware.InventorySync.Repository
{
    public interface IInventorySyncRepository
    {
        void InsertInventorySync(IList<Models.Generated.ManhattanInventorySync> inventorySync);

        IEnumerable<ManhattanInventorySync> FindManhattanInventorySync();

        void SetAsReceived(InventorySyncProcessing inventorySyncProcessing);

        void SetAsProcessed(InventorySyncProcessing inventorySyncProcessing);
    }
}