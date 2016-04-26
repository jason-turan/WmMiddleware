using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Middleware.Wm.PixNotification;
using Middleware.Wm.Service.Contracts;
using Middleware.Wm.Pix.Repository;
using Middleware.Log;
using Rhino.Mocks;
using System.Collections.Generic;
using WmMiddleware.Pix.Models.Generated;
using Middleware.Wm.Pix.Models;
using static Middleware.Wm.Jobs.Tests.Helpers.RhinoMockExtensions;
using Middleware.Wm.Service.Inventory.Models;
using Middleware.Wm.Manhattan.Extensions;
using System.Linq;
using Middleware.Wm.Service.Contracts.Models;

namespace Middleware.Wm.Jobs.Tests
{
    [TestClass]
    public class PixNotificationJobTests
    {
        private PixNotificationJob _job;
        private ILog _mockLog;
        private IPerpetualInventoryTransferRepository _mockRepository;
        private IIventoryServiceApi _mockInventoryService;
        private List<ManhattanPerpetualInventoryTransfer> _testPixRecords;
        private string _jobKey = "PIX Notification Job";
        private string _testPoNumber = "123456";

        private string _testBarcode0 = "456789";
        private string _testBarcode1 = "789123";


        [TestInitialize]
        public void TestInitialize()
        {
            _mockLog = MockRepository.GenerateMock<ILog>();
            _mockRepository = MockRepository.GenerateStub<IPerpetualInventoryTransferRepository>();
            _mockInventoryService = MockRepository.GenerateMock<IIventoryServiceApi>();
            _testPixRecords = new List<ManhattanPerpetualInventoryTransfer>();
            _mockRepository.
                StubWithMethod(
                    x => x.FindPerpetualInventoryTransfers(Any<PerpetualInventoryTransactionCriteria>()),
                    (PerpetualInventoryTransactionCriteria crit) =>
                    {
                        var toReturn = _testPixRecords.Where(p => p.TransactionType == crit.TransactionType).ToList();
                        if (!String.IsNullOrWhiteSpace(crit.PurchaseOrderNumber))
                        {
                            toReturn = toReturn.Where(p => p.Ponumber == crit.PurchaseOrderNumber).ToList();
                        }
                        return toReturn;
                    });

            _job = new PixNotificationJob(_mockLog, _mockRepository, _mockInventoryService);
        }

        [TestMethod]
        public void PerformsNoActionWhenNoWorkItemsFound()
        {
            _job.RunUnitOfWork(_jobKey);
            _mockInventoryService.AssertWasNotCalled(api =>
                api.PurchaseOrderReceived(Any<PurchaseOrderReceiptEvent>()));
            _mockRepository.AssertWasCalled(r =>
                r.FindPerpetualInventoryTransfers(Any<PerpetualInventoryTransactionCriteria>()));
        }

        [TestMethod]
        public void NotifiesOnPurchaseOrderReceipt()
        {
            AddNotificationTestRecords();
            _job.RunUnitOfWork(_jobKey);
            _mockInventoryService.AssertWasCalled(api =>
                api.PurchaseOrderReceived(Any<PurchaseOrderReceiptEvent>()));
            _mockRepository.AssertWasCalled(r =>
                r.FindPerpetualInventoryTransfers(Any<PerpetualInventoryTransactionCriteria>()));
            _mockRepository.AssertWasCalled(r =>
                r.InsertPurchaseOrderNotified(_testPoNumber));            
        }
         
        [TestMethod]
        public void OnlyNotifiesServiceOfFirstPoReceipt()
        {
            _mockRepository.Stub(mr => mr.HasPurchaseOrderBeenNotified(_testPoNumber)).Return(true);
            _job.RunUnitOfWork(_jobKey);
            _mockInventoryService.AssertWasNotCalled(api =>
                api.PurchaseOrderReceived(Any<PurchaseOrderReceiptEvent>()));
            _mockRepository.AssertWasCalled(r =>
                r.FindPerpetualInventoryTransfers(Any<PerpetualInventoryTransactionCriteria>()));
            _mockRepository.AssertWasNotCalled(r =>
                r.InsertPurchaseOrderNotified(_testPoNumber));            
        }


        [TestMethod]
        public void WillNotifyWebserviceOfStockedPurchaseOrders()
        {
            AddTestRecords();
            var capturedWebserviceCall = _mockInventoryService
                .Capture()
                .Args<PurchaseOrderStockedEvent>((api, arg) => api.PurchaseOrderStocked(Any<PurchaseOrderStockedEvent>()));
            _job.RunUnitOfWork(_jobKey);

            _mockInventoryService.AssertWasCalled(api =>
                api.PurchaseOrderReceived(Any<PurchaseOrderReceiptEvent>()));
            _mockRepository.AssertWasCalled(r =>
                r.FindPerpetualInventoryTransfers(Any<PerpetualInventoryTransactionCriteria>()));
            _mockRepository.AssertWasCalled(r =>
                r.InsertManhattanPerpetualInventoryNotificationProcessing(
                    AnyInt()),
                    options => options.Repeat.Times(
                        _testPixRecords.Where(r =>
                            r.TransactionType == TransactionType.InventoryAdjustment ||
                            r.TransactionType == TransactionType.QuantityAdjust).Count()));
            var receiptEvent = capturedWebserviceCall.First();

            Assert.AreEqual(receiptEvent.PurchaseOrderNumber, _testPoNumber);
            var stockedInventory0 = receiptEvent.ReceiptList.First(r => r.UPC == _testBarcode0);
            var stockedInventory1 = receiptEvent.ReceiptList.First(r => r.UPC == _testBarcode1);

            Assert.AreEqual(_testBarcode0, stockedInventory0.UPC);
            Assert.AreEqual(_testBarcode1, stockedInventory1.UPC);
            Assert.AreEqual(30, stockedInventory0.Quantity);
            Assert.AreEqual(10, stockedInventory1.Quantity);
        }

        private void AddTestRecords()
        {
            _testPixRecords.Add(CreatePixRecord(
               TimeSpan.FromMinutes(-10),
               TransactionType.NonAllocatable,
               "",
               _testBarcode0,
               10,
               _testPoNumber));

            _testPixRecords.Add(CreatePixRecord(
               TimeSpan.FromMinutes(-10),
               TransactionType.NonAllocatable,
               "",
               _testBarcode1,
               10,
               _testPoNumber));

            _testPixRecords.Add(CreatePixRecord(
                TimeSpan.FromMinutes(-9),
                TransactionType.NonAllocatable,
                "",
                _testBarcode0,
                5,
                _testPoNumber));

            _testPixRecords.Add(CreatePixRecord(
                TimeSpan.FromMinutes(-8),
                TransactionType.NonAllocatable,
                "",
                _testBarcode0,
                15,
                _testPoNumber));

            _testPixRecords.Add(CreatePixRecord(
               TimeSpan.FromMinutes(-4),
               TransactionType.NonAllocatable,
               "",
               _testBarcode0,
               -20,
               _testPoNumber));

            _testPixRecords.Add(CreatePixRecord(
             TimeSpan.FromMinutes(-4),
             TransactionType.NonAllocatable,
             "",
             _testBarcode1,
             -10,
             _testPoNumber));

            _testPixRecords.Add(CreatePixRecord(
               TimeSpan.FromMinutes(-4),
               TransactionType.InventoryAdjustment,
               "",
               _testBarcode0,
               +20,
               _testPoNumber));

            _testPixRecords.Add(CreatePixRecord(
               TimeSpan.FromMinutes(-4),
               TransactionType.InventoryAdjustment,
               "",
               _testBarcode1,
               +10,
               _testPoNumber));

            _testPixRecords.Add(CreatePixRecord(
              TimeSpan.FromMinutes(-2),
              TransactionType.NonAllocatable,
              "",
              _testBarcode0,
              -10,
              _testPoNumber));
            _testPixRecords.Add(CreatePixRecord(
               TimeSpan.FromMinutes(-2),
               TransactionType.InventoryAdjustment,
               "",
               _testBarcode0,
               +10,
               _testPoNumber));

            _testPixRecords.Add(CreatePixRecord(
                TimeSpan.FromMinutes(-1),
                TransactionType.QuantityAdjust,
                TransactionCode.PurchaseOrder,
                "",
                null,
                _testPoNumber));
        }

        private void AddNotificationTestRecords()
        {
            AddTestRecords();
            foreach (var item in
                _testPixRecords.Where(
                    r => r.TransactionType == TransactionType.QuantityAdjust ||
                         r.TransactionType == TransactionType.InventoryAdjustment).ToList())
            {
                _testPixRecords.Remove(item);
            }
        }

        private ManhattanPerpetualInventoryTransfer CreatePixRecord(
            TimeSpan timeEventStarted,
            string transactionType,
            string transactionCode,
            string upc,
            int? adjustmentAmount,
            string poNumber)
        {
            var eventDate = DateTime.Now - timeEventStarted;
            return new ManhattanPerpetualInventoryTransfer()
            {
                PackageBarcode = upc,
                TransactionCode = transactionCode,
                TransactionType = transactionType,
                InventoryAdjustmentQuantity = adjustmentAmount.HasValue ? Math.Abs(adjustmentAmount.Value) : 0m,
                InventoryAdjustmntType = adjustmentAmount.HasValue ? adjustmentAmount > 0 ? "A" : "S" : "",
                Ponumber = poNumber,
                DateCreated = eventDate.ToMainframeDate(),
                TimeCreated = eventDate.ToMainframeTime()
            };

        }
    }
}
