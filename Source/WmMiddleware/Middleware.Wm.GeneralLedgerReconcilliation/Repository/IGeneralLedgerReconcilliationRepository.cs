using System.Collections.Generic;
using Middleware.Wm.Manhattan.Shipment;
using WmMiddleware.Pix.Models.Generated;

namespace Middleware.Wm.GeneralLedgerReconcilliation.Repository
{
    public interface IGeneralLedgerReconcilliationRepository
    {
        void ProcessInventoryAdjustments(IEnumerable<ManhattanPerpetualInventoryTransfer> unprocessed);
        void ProcessPurchaseReturns(IEnumerable<ManhattanPerpetualInventoryTransfer> unprocessed);
        void ProcessPurchaseOrders(IList<ManhattanPerpetualInventoryTransfer> unprocessed);
        void ProcessBrickAndClickShipments(IEnumerable<ManhattanShipment> unprocessed);
    }
}
