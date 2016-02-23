using System;
using System.Collections.Generic;
using MiddleWare.Log;
using Middleware.Wm.GeneralLedgerReconcilliation.Models;
using Middleware.Wm.Pix.Models;
using WmMiddleware.Pix.Models.Generated;

namespace Middleware.Wm.GeneralLedgerReconcilliation.Repository
{
    public class GeneralLedgerReconcilliationRepository : IGeneralLedgerReconcilliationRepository
    {
        private const string CharityTransactionCode = "90";
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

        public void ProcessPurchaseorders(IEnumerable<ManhattanPerpetualInventoryTransfer> unprocessed)
        {
            foreach (var pix in unprocessed)
            {
                try
                {

                }
                catch (Exception exception)
                {
                    _log.Exception("Fatal error processing pix transaction number " + pix.TransactionNumber, exception);
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