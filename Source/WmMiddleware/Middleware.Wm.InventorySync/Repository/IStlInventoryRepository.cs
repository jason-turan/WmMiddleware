using System.Collections.Generic;
using Middleware.Wm.InventorySync.Models;

namespace Middleware.Wm.InventorySync.Repository
{
    public interface IStlInventoryRepository
    {
        IEnumerable<StlInventory> GetLatestManhattanInventorySync();
        void InsertStlInventory(IList<StlInventory> stlInventory);
        IEnumerable<StlInventorySyncAudit> GetStlInventorySyncAudit();
    }
}
