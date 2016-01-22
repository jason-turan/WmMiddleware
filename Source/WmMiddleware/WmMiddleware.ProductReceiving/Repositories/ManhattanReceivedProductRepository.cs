using System.Collections.Generic;
using System.Linq;
using Middleware.Jobs;
using Middleware.Jobs.Repositories;
using WmMiddleware.Common.DataFiles;
using WmMiddleware.Configuration;
using WmMiddleware.Configuration.Manhattan;
using WmMiddleware.ProductReceiving.Models;
using WmMiddleware.TransferControl.Control;

namespace WmMiddleware.ProductReceiving.Repositories
{
    public class ManhattanReceivedProductRepository : IReceivedProductWriter
    {
        private readonly IManhattanConfiguration _configuration;
        private readonly DataFileRepository<ManhattanCaseDetail> _caseDetailFileRepository = new DataFileRepository<ManhattanCaseDetail>();
        private readonly DataFileRepository<ManhattanSkuDetail> _skuDetailFileRepository = new DataFileRepository<ManhattanSkuDetail>();
        private readonly DataFileRepository<ManhattanReceivedProductHeader> _headerFileRepository = new DataFileRepository<ManhattanReceivedProductHeader>();
        private readonly ITransferControlManager _transferControlManager;
        private readonly IJobRepository _jobRepository;

        public ManhattanReceivedProductRepository(ITransferControlManager transferControlManager, 
                                                  IManhattanConfiguration configuration,
                                                  IJobRepository jobRepository)
        {
            _transferControlManager = transferControlManager;
            _configuration = configuration;
            _jobRepository = jobRepository;
        }

        public void Save(IEnumerable<IReceivedProduct> receivedProducts)
        {
            var receivedProductsCollection = receivedProducts.ToList();
            var purchaseOrderDetails = new List<ManhattanSkuDetail>();
            var purchaseReturnDetails = new List<ManhattanSkuDetail>();
            var automatedShippingNotificationDetails = new List<ManhattanCaseDetail>();
            var headerList = new List<ManhattanReceivedProductHeader>();

            var warehouseNumber = _configuration.GetKey<string>(ConfigurationKey.WarehouseNumber);
            var companyNumber = _configuration.GetKey<string>(ConfigurationKey.CompanyNumber);

            var controlNumber = _configuration.GetBatchControlNumber();
            var batchControlNumber = warehouseNumber + controlNumber.ToString("D8");

            foreach (var purchaseOrder in receivedProductsCollection.OfType<PurchaseOrder>())
            {
                headerList.Add(new ManhattanReceivedProductHeader(purchaseOrder, batchControlNumber, warehouseNumber));
                purchaseOrderDetails.AddRange(purchaseOrder.Items.Select(item => new ManhattanSkuDetail(purchaseOrder, item, batchControlNumber, companyNumber, warehouseNumber)));
            }

            foreach (var purchaseReturn in receivedProductsCollection.OfType<PurchaseReturn>())
            {
                headerList.Add(new ManhattanReceivedProductHeader(purchaseReturn, batchControlNumber, warehouseNumber));
                purchaseReturnDetails.AddRange(purchaseReturn.Items.Select(item => new ManhattanSkuDetail(purchaseReturn, item, batchControlNumber, companyNumber, warehouseNumber)));
            }

            foreach (var automatedShippingNotification in receivedProductsCollection.OfType<AutomatedShippingNotification>())
            {
                headerList.Add(new ManhattanReceivedProductHeader(automatedShippingNotification, batchControlNumber, warehouseNumber));
                automatedShippingNotificationDetails.AddRange(automatedShippingNotification.Items.Select(item => new ManhattanCaseDetail(automatedShippingNotification, item, batchControlNumber, companyNumber, warehouseNumber)));
            }

            var headerPath = _configuration.GetPath(ManhattanDataFileType.ProductReceivingHeader, controlNumber);
            var poDetailsPath = _configuration.GetPath(ManhattanDataFileType.ProductReceivingPoDetail, controlNumber);
            var asnDetailsPath = _configuration.GetPath(ManhattanDataFileType.ProductReceivingAsnDetail, controlNumber);

            _headerFileRepository.Save(headerList, headerPath);

            // I9 = purchase orders + purchase returns 
            var skuDetails = new List<ManhattanSkuDetail>();
            skuDetails.AddRange(purchaseOrderDetails);
            skuDetails.AddRange(purchaseReturnDetails);

            if (skuDetails.Count > 0)
            {
                _skuDetailFileRepository.Save(skuDetails, poDetailsPath);
            }

            // IB = shipping notification
            if (automatedShippingNotificationDetails.Count > 0)
            {
                _caseDetailFileRepository.Save(automatedShippingNotificationDetails, asnDetailsPath);
            }
       
            _transferControlManager.SaveTransferControl(batchControlNumber, 
                                                        new List<string> { headerPath, poDetailsPath, asnDetailsPath },
                                                        _jobRepository.GetJob(JobKey.ProductReceiving).JobId);
        }
    }
}
