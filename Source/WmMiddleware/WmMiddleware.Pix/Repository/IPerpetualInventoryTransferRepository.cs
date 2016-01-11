using System.Collections.Generic;
using WmMiddleware.Pix.Models;
using WmMiddleware.Pix.Models.Generated;

namespace WmMiddleware.Pix.Repository
{
    public interface IPerpetualInventoryTransferRepository
    {
        void InsertPerpetualInventoryTransfer(IList<ManhattanPerpetualInventoryTransfer> perpetualInventoryTransfer);

        IEnumerable<ManhattanPerpetualInventoryTransfer> FindPerpetualInventoryTransfers(PerpetualInventoryTransactionCriteria criteria);

        void InsertManhattanPerpetualInventoryTransferProcessing(int manhattanPerpetualInventoryProcessingId);
    }
}