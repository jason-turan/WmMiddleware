using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Transactions;
using MiddleWare.Log;
using Middleware.Wm.GeneralLedgerReconcilliation.Models;
using Middleware.Wm.Pix.Models;
using WmMiddleware.Pix.Models.Generated;

namespace Middleware.Wm.GeneralLedgerReconcilliation.Repository
{
    public class GeneralLedgerReconcilliationRepository : IGeneralLedgerReconcilliationRepository
    {
        private const string CharityTransactionCode = "90";
        private const string PurchaseOrderInterfaceSenderId = "NONEDI";
        private const string PurchaseOrderInterfaceRecipientId = "RNETR222";
        private const string PurchaseOrderInterfaceIntegrationStatus = "NEW";
        private readonly ILog _log;
        private readonly IDatabaseRepository _databaseRepository;

        public GeneralLedgerReconcilliationRepository(ILog log, IDatabaseRepository databaseRepository)
        {
            _log = log;
            _databaseRepository = databaseRepository;
        }

        public void ProcessInventoryAdjustments(IEnumerable<ManhattanPerpetualInventoryTransfer> unprocessed)
        {
            foreach (var pix in unprocessed)
            {
                try
                {
                    WriteGeneralLedger(pix);
                }
                catch (Exception exception)
                {
                    _log.Exception("Fatal error processing pix transaction number " + pix.TransactionNumber, exception);
                }
            }
        }

        public void ProcessPurchaseReturns(IEnumerable<ManhattanPerpetualInventoryTransfer> unprocessed)
        {
            foreach (var pix in unprocessed)
            {
                try
                {
                    var pixReturn = new PixReturn(pix);

                    if (pixReturn.ReturnToStock())
                    {
                        // no action - will be accounted for in return processing
                        MarkAsProcessed(pix);
                    }
                    else
                    {
                        // map to charity
                        pix.TransactionReasonCode = CharityTransactionCode;
                        WriteGeneralLedger(pix);    
                    }
                }
                catch (Exception exception)
                {
                    _log.Exception("Fatal error processing pix transaction number " + pix.TransactionNumber, exception);
                }
            }
        }

        public void ProcessPurchaseOrders(IList<ManhattanPerpetualInventoryTransfer> unprocessed)
        {
            foreach (var purchaseOrderGrouping in unprocessed.GroupBy(g => g.Ponumber))
            {
                using (var scope = new TransactionScope())
                {
                    try
                    {
                        var firstRecordInGrouping = new PurchaseOrderGeneralLedger(purchaseOrderGrouping.First());

                        var header = new DatabasePurchaseOrderReceiptHeader
                        {
                            SenderID = PurchaseOrderInterfaceSenderId,
                            RecipientID = PurchaseOrderInterfaceRecipientId,
                            TransactionDate = firstRecordInGrouping.Shippeddatetimereference
                        };

                        var detail = new DatabasePurchaseOrderReceiptDetail
                        {
                            POReceiptHeaderID = _databaseRepository.InsertDatabasePoReceiptHeader(header),
                            PONumber = purchaseOrderGrouping.Key,
                            InvoiceNumber = firstRecordInGrouping.InvoiceNumber,
                            NumberLineItems = purchaseOrderGrouping.Count().ToString(CultureInfo.InvariantCulture),
                            shippeddatetimereference = firstRecordInGrouping.Shippeddatetimereference,
                            IntegrationStatus = PurchaseOrderInterfaceIntegrationStatus,
                            DateAdded = DateTime.Now
                        };

                        var detailId = _databaseRepository.InsertDatabasePurchaseOrderReceiptDetail(detail);

                        foreach (var pix in purchaseOrderGrouping.OrderBy(o => o.SequenceNumber))
                        {
                            var purchaseOrderGl = new PurchaseOrderGeneralLedger(pix);
                            var databasePurchaseOrderReceiptDetailLineItem = new DatabasePurchaseOrderReceiptDetailLineItem
                            {
                                PoReceiptDetailId = detailId,
                                LineNumber = purchaseOrderGl.LineItemNumber.ToString(CultureInfo.InvariantCulture),
                                Upc = purchaseOrderGl.Sku,
                                Uom = purchaseOrderGl.UnitOfMeasure,
                                QuantityInvoiced = purchaseOrderGl.NumberUnitsShipped.ToString(CultureInfo.InvariantCulture),
                                DateAdded = DateTime.Now
                            };

                            _databaseRepository.InsertDatabasePurchaseOrderReceiptDetailLineItem(databasePurchaseOrderReceiptDetailLineItem);
                            MarkAsProcessed(pix);
                        }

                        scope.Complete();
                    }
                    catch (Exception exception)
                    {
                        _log.Exception("Fatal error processing pix transaction number " + purchaseOrderGrouping.Key, exception);
                    }
                }
            }
        }

        private void MarkAsProcessed(ManhattanPerpetualInventoryTransfer manhattanPerpetualInventoryTransfer)
        {
            _databaseRepository.InsertPixGeneralLedgerProcessing(new PixGeneralLedgerProcessing
            {
                ManhattanPerpetualInventoryTransferId = manhattanPerpetualInventoryTransfer.ManhattanPerpetualInventoryTransferId,
                ProcessedDate = DateTime.Now
            });
        }

        private void WriteGeneralLedger(ManhattanPerpetualInventoryTransfer pix)
        {
            var glTransactionReasonMap = _databaseRepository.GetGeneralLedgerTransactionReasonCodeMap();
            var glInterface = new GeneralLedgerInventoryTransactionInterface(pix, glTransactionReasonMap);

            if (glInterface.GeneralLedgerAccount == null)
            {
                _log.Warning("No GL mapping found for transaction " + pix.ManhattanPerpetualInventoryTransferId);
            }
            else
            {
                _databaseRepository.InsertIntegrationInventoryAdjustment(new DatabaseIntegrationsInventoryAdjustment(glInterface));
            }

            MarkAsProcessed(pix);
        }
    }
}