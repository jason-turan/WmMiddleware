using System.Linq;
using Middleware.Jobs;
using MiddleWare.Log;
using Middleware.Wm.GeneralLedgerReconcilliation.Repository;
using Middleware.Wm.Pix.Models;
using Middleware.Wm.Pix.Repository;

namespace Middleware.Wm.GeneralLedgerReconcilliation
{
    public class GeneralLedgerReconcilliationJob : IUnitOfWork
    {
        private readonly ILog _log;

        private readonly IPerpetualInventoryTransferRepository _perpetualInventoryTransferRepository;
        private readonly IGeneralLedgerReconcilliationRepository _generalLedgerReconcilliationRepository;

        public GeneralLedgerReconcilliationJob(ILog log,
                                               IPerpetualInventoryTransferRepository perpetualInventoryTransferRepository,
                                               IGeneralLedgerReconcilliationRepository generalLedgerReconcilliationRepository)
        {
            _log = log;
            _perpetualInventoryTransferRepository = perpetualInventoryTransferRepository;
            _generalLedgerReconcilliationRepository = generalLedgerReconcilliationRepository;
        }

        public void RunUnitOfWork(string jobKey)
        {
            ProcessPixInventoryAdjustments();

            ProcessPixPurchaseOrders();

            ProcessReturns();

            // TODO Process BnC
        }

        private void ProcessReturns()
        {
            var unprocessed =
            _perpetualInventoryTransferRepository.FindPerpetualInventoryTransfers(new PerpetualInventoryTransactionCriteria
            {
                ProcessType = ProcessType.GeneralLedgerPurchaseReturn,
                TransactionType = TransactionType.QuantityAdjust,
                TransactionCode = TransactionCode.Return
            }).ToList();

            _log.Info(string.Format("{0} purchase return records found process...", unprocessed.Count()));

            if (unprocessed.Count == 0)
            {
                return;
            }

            _generalLedgerReconcilliationRepository.ProcessPurchaseReturns(unprocessed);
        }

        private void ProcessPixInventoryAdjustments()
        {
            var unprocessed =
                _perpetualInventoryTransferRepository.FindPerpetualInventoryTransfers(new PerpetualInventoryTransactionCriteria
                {
                    ProcessType = ProcessType.GeneralLedgerInventoryAdjustment,
                    TransactionType = TransactionType.InventoryAdjustment
                }).ToList();

            _log.Info(string.Format("{0} inv. adjustment records found to process...", unprocessed.Count()));

            if (unprocessed.Count == 0)
            {
                return;
            }

            _generalLedgerReconcilliationRepository.ProcessInventoryAdjustments(unprocessed);
        }

        private void ProcessPixPurchaseOrders()
        {
            var unprocessed =
                _perpetualInventoryTransferRepository.FindPerpetualInventoryTransfers(new PerpetualInventoryTransactionCriteria
                {
                    ProcessType = ProcessType.GeneralLedgerPurchaseOrder,
                    TransactionType = TransactionType.QuantityAdjust,
                    TransactionCode = TransactionCode.PurchaseOrder
                }).ToList();

            _log.Info(string.Format("{0} purchase order records found process...", unprocessed.Count()));

            if (unprocessed.Count == 0)
            {
                return;
            }
        }

    }
}
