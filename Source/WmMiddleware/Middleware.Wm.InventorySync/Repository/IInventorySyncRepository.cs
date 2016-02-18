using System.Collections.Generic;
using Middleware.Wm.InventorySync.Models;
using WmMiddleware.InventorySync.Models.Generated;

namespace Middleware.Wm.InventorySync.Repository
{
    public interface IInventorySyncRepository
    {
        void InsertInventorySync(IList<ManhattanInventorySync> inventorySync);

        IEnumerable<ManhattanInventorySync> FindManhattanInventorySync();

        void SetAsReceived(InventorySyncProcessing inventorySyncProcessing);

        void SetAsProcessed(InventorySyncProcessing inventorySyncProcessing);
    }
}