using System.Collections.Generic;
using WmMiddleware.StlInventorySync.Models;

namespace WmMiddleware.StlInventorySync.Repository
{
    public interface IStlInventoryRepository
    {
        IEnumerable<StlInventory> GetStlInventorySync();
        void InsertStlInventory(IList<StlInventory> stlInventory);
    }
}
