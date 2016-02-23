using System.Collections.Generic;
using WmMiddleware.Pix.Models.Generated;

namespace Middleware.Wm.GeneralLedgerReconcilliation.Repository
{
    public interface IGeneralLedgerReconcilliationRepository
    {
        void ProcessInventoryAdjustments(IEnumerable<ManhattanPerpetualInventoryTransfer> unprocessed);

        void ProcessPurchaseReturns(IEnumerable<ManhattanPerpetualInventoryTransfer> unprocessed);

        void ProcessPurchaseorders(IEnumerable<ManhattanPerpetualInventoryTransfer> unprocessed);
    }
}
