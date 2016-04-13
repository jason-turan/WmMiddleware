using System.Collections.Generic;
using Middleware.Wm.StlInventoryUpdate.Models;

namespace Middleware.Wm.StlInventoryUpdate.Repository
{
    public interface IStlInventoryUpdateRepository
    {

        void UpdateStlInventory(IList<StlInventoryItem> stlInventoryList);

    }
}
