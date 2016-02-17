using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WmMiddleware.StlInventoryUpdate.Repository
{
    public interface IStlInventoryUpdateRepository
    {

        void UpdateStlInventory(IList<Models.StlInventoryItem> stlInventoryList);

    }
}
