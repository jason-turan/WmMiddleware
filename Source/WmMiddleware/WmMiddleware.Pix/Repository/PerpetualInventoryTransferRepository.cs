using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using WmMiddleware.Configuration.Database;
using WmMiddleware.Pix.Models.Generated;

namespace WmMiddleware.Pix.Repository
{
    public class PerpetualInventoryTransferRepository : IPerpetualInventoryTransferRepository
    {
        public void InsertPerpetualInventoryTransfer(IList<PerpetualInventoryTransfer> perpetualInventoryTransfer)
        {
            using (var connection = DatabaseConnectionFactory.GetWarehouseManagementTransactionConnection())
            {
                connection.Insert(perpetualInventoryTransfer);
            }
        }
    }
}
