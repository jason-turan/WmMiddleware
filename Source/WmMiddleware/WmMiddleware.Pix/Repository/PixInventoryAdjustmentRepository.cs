using System.Collections.Generic;
using System.Linq;
using WmMiddleware.Pix.Models;

namespace WmMiddleware.Pix.Repository
{
    public class PixInventoryAdjustmentRepository : IPixInventoryAdjustmentRepository
    {
        private readonly IPerpetualInventoryTransferRepository _perpetualInventoryTransferRepository;

        public PixInventoryAdjustmentRepository(IPerpetualInventoryTransferRepository perpetualInventoryTransferRepository)
        {
            _perpetualInventoryTransferRepository = perpetualInventoryTransferRepository;
        }

        public IEnumerable<PixInventoryAdjustment> GetUnprocessedInventoryAdjustments()
        {
            var inventoryAdjustmentCriteria = new PerpetualInventoryTransactionCriteria
            {
                ProcessType = ProcessType.InventoryAdjustment,
                TransactionType = TransactionType.InventoryAdjustment
            };

            var pixInventoryAdjustements = _perpetualInventoryTransferRepository.FindPerpetualInventoryTransfers(inventoryAdjustmentCriteria);

            return pixInventoryAdjustements.Select(pixInventoryAdjustement => new PixInventoryAdjustment(pixInventoryAdjustement)).ToList();
        }
    }
}
