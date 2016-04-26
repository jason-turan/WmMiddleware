using System.Collections.Generic;
using Middleware.Wm.Pix.Models;
using WmMiddleware.Pix.Models.Generated;

namespace Middleware.Wm.Pix.Repository
{
    public interface IPerpetualInventoryTransferRepository
    {
        void InsertPerpetualInventoryTransfer(IList<ManhattanPerpetualInventoryTransfer> perpetualInventoryTransfer);
        IEnumerable<ManhattanPerpetualInventoryTransfer> FindPerpetualInventoryTransfers(PerpetualInventoryTransactionCriteria criteria);
        void InsertManhattanPerpetualInventoryTransferProcessing(int manhattanPerpetualInventoryProcessingId);
        void InsertPixInventoryAdjustmentProcessing(IList<PixInventoryAdjustment> pixInventoryAdjustments);

        void InsertManhattanPerpetualInventoryNotificationProcessing(int manhattanPerpetualInventoryProcessingId);
        bool HasPurchaseOrderBeenNotified(string poNumber);
        void InsertPurchaseOrderNotified(string poNumber);
    }
}