using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WmMiddleware.StlInventoryUpdate.Repository
{
    public interface IStlInventoryUpdateRepository
    {

        IEnumerable<Models.StlInventoryUpdate> GetStlInventoryPix();

        IEnumerable<Models.StlInventoryUpdate> GetStlInventoryShipments();

        void UpdateStlInventory(IList<Models.StlInventoryUpdate> stlInventoryList);

        void SetPixAsProcessed(IList<Models.StlInventoryUpdate> stlInvenotryList);

        void SetShipmentsAsProcessed(IList<Models.StlInventoryUpdate> stlInvenotryList);
    }
}
