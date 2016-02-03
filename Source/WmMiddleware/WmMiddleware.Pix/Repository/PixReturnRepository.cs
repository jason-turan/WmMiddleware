using System.Collections.Generic;
using System.Linq;
using WmMiddleware.Pix.Models;

namespace WmMiddleware.Pix.Repository
{
    public class PixReturnRepository : IPixReturnRepository
    {
        private readonly IPerpetualInventoryTransferRepository _perpetualInventoryTransferRepository;

        public PixReturnRepository(IPerpetualInventoryTransferRepository perpetualInventoryTransferRepository)
        {
            _perpetualInventoryTransferRepository = perpetualInventoryTransferRepository;
        }

        public IEnumerable<PixReturn> GetUnprocessedReturns()
        {
            var returnCriteria = new PerpetualInventoryTransactionCriteria
            {
                TransactionCode = TransactionCode.Return, 
                TransactionType = TransactionType.Return, 
                ProcessType = ProcessType.Return
            };

            var pixReturns = _perpetualInventoryTransferRepository.FindPerpetualInventoryTransfers(returnCriteria);

            return pixReturns.Select(pixReturn => new PixReturn(pixReturn)).ToList();
        }
    }
}
