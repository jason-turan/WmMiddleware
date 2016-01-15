using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WmMiddleware.StlInventorySync.Models;

namespace WmMiddleware.StlInventorySync.Repository
{
    public interface IStlInventoryRepository
    {
        IEnumerable<StlInventory> GetStlInventorySync();

        void InsertStlInventory(IList<StlInventory> stlInventory);
    }
}
