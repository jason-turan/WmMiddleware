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

            // TODO Process PO

            // TODO Process Return

            // TODO Process BnC
        }

        private void ProcessPixInventoryAdjustments()
        {
            var unprocessed =
                _perpetualInventoryTransferRepository.FindPerpetualInventoryTransfers(new PerpetualInventoryTransactionCriteria
                {
                    ProcessType = ProcessType.GeneralLedger,
                    TransactionType = TransactionType.InventoryAdjustment
                }).ToList();

            _log.Info(string.Format("{0} adjustment records found...", unprocessed.Count()));
            _generalLedgerReconcilliationRepository.ProcessInventoryAdjustments(unprocessed);
        }
    }
}
