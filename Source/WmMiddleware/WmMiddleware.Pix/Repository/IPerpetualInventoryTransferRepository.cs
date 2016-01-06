using System.Collections.Generic;
using WmMiddleware.Pix.Models.Generated;

namespace WmMiddleware.Pix.Repository
{
    public interface IPerpetualInventoryTransferRepository
    {
        void InsertPerpetualInventoryTransfer(IList<PerpetualInventoryTransfer> perpetualInventoryTransfer);
    }
}