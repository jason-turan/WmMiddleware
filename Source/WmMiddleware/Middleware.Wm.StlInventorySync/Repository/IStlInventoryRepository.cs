using System.Collections.Generic;
using Middleware.Wm.StlInventorySync.Models;

namespace Middleware.Wm.StlInventorySync.Repository
{
    public interface IStlInventoryRepository
    {
        IEnumerable<StlInventory> GetLatestManhattanInventorySync();
        void InsertStlInventory(IList<StlInventory> stlInventory);
        IEnumerable<StlInventorySyncAudit> GetStlInventorySyncAudit();
    }
}
