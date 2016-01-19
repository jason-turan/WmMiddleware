using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiddleWare.Log;
using WmMiddleware.StlInventoryUpdate.Repository;

namespace WmMiddleware.StlInventoryUpdate
{
    public class StlInventoryUpdateJob : IStlInventoryUpdateJob
    {
        private readonly IStlInventoryUpdateRepository _stlInventoryUpdateRepository;
        private readonly ILog _log;

        public StlInventoryUpdateJob(ILog log, IStlInventoryUpdateRepository stlInventoryUpdateRepository)
        {
            _log = log;
            _stlInventoryUpdateRepository = stlInventoryUpdateRepository;
        }

        public void RunUnitOfWork(string jobKey)
        {

            var stlInvetoryPix = _stlInventoryUpdateRepository.GetStlInventoryPix().ToList();           
            var stlInvetoryShipments = _stlInventoryUpdateRepository.GetStlInventoryShipments().ToList();

            var stlInventoryUpdate = SumQuantitiesByUpc(stlInvetoryPix.Concat(stlInvetoryShipments).ToList());

            _stlInventoryUpdateRepository.UpdateStlInventory(stlInventoryUpdate);

            _log.Debug(string.Format("Consumed {0} PIX Entries and {1} Shipment Line Items into StlInventory!",
                stlInvetoryPix.Count, stlInvetoryShipments.Count));

            _stlInventoryUpdateRepository.SetPixAsProcessed(stlInvetoryPix);
            _stlInventoryUpdateRepository.SetShipmentsAsProcessed(stlInvetoryShipments);

        }

        private IList<Models.StlInventoryUpdate> SumQuantitiesByUpc(IEnumerable<Models.StlInventoryUpdate> stlInventoryUpdates)
        {

            var upcQuantityLookup = new Dictionary<string, Models.StlInventoryUpdate>();
            foreach (var stlInv in stlInventoryUpdates)
            {
                if (upcQuantityLookup.ContainsKey(stlInv.Upc))
                {
                    var tmp = upcQuantityLookup[stlInv.Upc];
                    tmp.Qty += stlInv.Qty;
                    upcQuantityLookup[stlInv.Upc] = tmp;
                }
                else
                    upcQuantityLookup.Add(stlInv.Upc, stlInv);               
            }

            var stlInventoryConcat = new List<Models.StlInventoryUpdate>();
            foreach (var upcStlInv in upcQuantityLookup)
            {
                stlInventoryConcat.Add(upcStlInv.Value);
            }

            return stlInventoryConcat;
        }

    }
}
