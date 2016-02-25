using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MiddleWare.Log;
using Middleware.Wm.Configuration;
using Middleware.Wm.Configuration.Transaction;
using Middleware.Wm.GeneralLedgerReconcilliation.Models;
using Middleware.Wm.Manhattan.Shipment;
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
        private readonly IConfigurationManager _configurationManager;

        public GeneralLedgerReconcilliationRepository(ILog log, 
                                                      IDatabaseRepository databaseRepository,
                                                      IConfigurationManager configurationManager)
        {
            _log = log;
            _databaseRepository = databaseRepository;
            _configurationManager = configurationManager;
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
                        MarkPixAsProcessed(pix);
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
                using (var scope = Scope.CreateTransactionScope())
                {
                    try
                    {
                        var firstRecordInGrouping = new PurchaseOrderGeneralLedger(purchaseOrderGrouping.First());

                        var headerId = ProcessPurchaseOrderHeader(firstRecordInGrouping);
                        var detailId = ProcessPurchaseOrdersDetail(headerId, purchaseOrderGrouping, firstRecordInGrouping);

                        foreach (var pix in purchaseOrderGrouping.OrderBy(o => o.SequenceNumber))
                        {
                            ProcessPurchaseOrderDetailLineItem(pix, detailId);
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

        public void ProcessBrickAndClickShipments(IEnumerable<ManhattanShipment> unprocessed)
        {
            foreach (var manhattanShipment in unprocessed)
            {
                try
                {
                    foreach (var lineItem in manhattanShipment.LineItems)
                    {
                        var gl = new ShipmentGeneralLedgerInventoryTransaction(lineItem, _configurationManager);
                        _databaseRepository.InsertIntegrationInventoryAdjustment(new DatabaseIntegrationsInventoryAdjustment(gl));

                        _log.Debug("Processed " + manhattanShipment.Header.PickticketControlNumber + " sku " + lineItem.PackageBarcode);
                    }

                    MarkManhtattanShipmentBrickAndClickProcessed(manhattanShipment);
                    _log.Info("Completed GL for shipment bnc pick ticket control number " + manhattanShipment.Header.PickticketControlNumber);
                }
                catch (Exception exception)
                {
                    _log.Exception("Fatal error processing shipment bnc pick ticket control number " + manhattanShipment.Header.PickticketControlNumber, exception);
                }
            }
        }

        private void MarkManhtattanShipmentBrickAndClickProcessed(ManhattanShipment manhattanShipment)
        {
            _databaseRepository.InsertManhattanShipmentBrickAndClickProcessing(new ManhattanShipmentBrickAndClickProcessing
            {
                BatchControlNumber = manhattanShipment.Header.BatchControlNumber,
                PickticketControlNumber = manhattanShipment.Header.PickticketControlNumber
            });
        }

        private int ProcessPurchaseOrderHeader(PurchaseOrderGeneralLedger firstRecordInGrouping)
        {
            var header = new DatabasePurchaseOrderReceiptHeader
            {
                SenderID = PurchaseOrderInterfaceSenderId,
                RecipientID = PurchaseOrderInterfaceRecipientId,
                TransactionDate = firstRecordInGrouping.Shippeddatetimereference
            };

            return _databaseRepository.InsertDatabasePoReceiptHeader(header);
        }

        private void ProcessPurchaseOrderDetailLineItem(ManhattanPerpetualInventoryTransfer pix, int detailId)
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
            MarkPixAsProcessed(pix);
        }

        private int ProcessPurchaseOrdersDetail(int headerId, IGrouping<string, ManhattanPerpetualInventoryTransfer> purchaseOrderGrouping, PurchaseOrderGeneralLedger firstRecordInGrouping)
        {
            var detail = new DatabasePurchaseOrderReceiptDetail
            {
                POReceiptHeaderID = headerId,
                PONumber = purchaseOrderGrouping.Key,
                InvoiceNumber = firstRecordInGrouping.InvoiceNumber,
                NumberLineItems = purchaseOrderGrouping.Count().ToString(CultureInfo.InvariantCulture),
                shippeddatetimereference = firstRecordInGrouping.Shippeddatetimereference,
                IntegrationStatus = PurchaseOrderInterfaceIntegrationStatus,
                DateAdded = DateTime.Now
            };

            return _databaseRepository.InsertDatabasePurchaseOrderReceiptDetail(detail);
        }

        private void MarkPixAsProcessed(ManhattanPerpetualInventoryTransfer manhattanPerpetualInventoryTransfer)
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
            var glInterface = new PixGeneralLedgerInventoryTransaction(pix, glTransactionReasonMap, _configurationManager);

            if (glInterface.GeneralLedgerAccount == null)
            {
                _log.Warning("No GL mapping found for transaction " + pix.ManhattanPerpetualInventoryTransferId);
            }
            else
            {
                _databaseRepository.InsertIntegrationInventoryAdjustment(new DatabaseIntegrationsInventoryAdjustment(glInterface));
            }

            MarkPixAsProcessed(pix);
        }
    }
}