using System.Collections.Generic;
using Middleware.Jobs.Repositories;
using WmMiddleware.Configuration.Manhattan;
using WmMiddleware.ProductReturn.Models;
using WmMiddleware.TransferControl.Control;

namespace WmMiddleware.ProductReturn.Repository
{
    public class ManhattanReturnedProductRepository : IReceivedPurchaseReturnWriter
    {
        private readonly IManhattanConfiguration _configuration;
        //private readonly DataFileRepository<ManhattanCaseDetail> _caseDetailFileRepository = new DataFileRepository<ManhattanCaseDetail>();
        //private readonly DataFileRepository<ManhattanSkuDetail> _skuDetailFileRepository = new DataFileRepository<ManhattanSkuDetail>();
        //private readonly DataFileRepository<ManhattanReceivedProductHeader> _headerFileRepository = new DataFileRepository<ManhattanReceivedProductHeader>();
        private readonly ITransferControlManager _transferControlManager;
        private readonly IJobRepository _jobRepository;

        public ManhattanReturnedProductRepository(ITransferControlManager transferControlManager, 
                                                  IManhattanConfiguration configuration,
                                                  IJobRepository jobRepository)
        {
            _transferControlManager = transferControlManager;
            _configuration = configuration;
            _jobRepository = jobRepository;
        }

        public void Save(IEnumerable<PurchaseReturn> receivedProducts)
        {
            throw new System.NotImplementedException();
        }
    }
}
