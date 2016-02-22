using System;
using System.Linq;
using Middleware.Jobs;
using MiddleWare.Log;
using Middleware.Wm.GeneralLedgerReconcilliation.Models;
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
            var unprocessed = 
                _perpetualInventoryTransferRepository.FindPerpetualInventoryTransfers(new PerpetualInventoryTransactionCriteria
                                                                                      {
                                                                                         ProcessType = ProcessType.GeneralLedger
                                                                                      }).ToList();

            _log.Info(string.Format("Processing {0} records", unprocessed.Count()));

            _log.Info("Processing " + unprocessed.Count() + " records");

            var generalLedgerTransactionReasonCodeMap = _generalLedgerReconcilliationRepository.GetGeneralLedgerTransactionReasonCodeMap();

            foreach (var manhattanPerpetualInventoryTransfer 
                     in unprocessed.Where(u => u.InventoryAdjustmentQuantity != 0).
                     Where(manhattanPerpetualInventoryTransfer => manhattanPerpetualInventoryTransfer.TransactionType == TransactionType.InventoryAdjustment).
                     Where(manhattanPerpetualInventoryTransfer => manhattanPerpetualInventoryTransfer.TransactionReasonCode != string.Empty))
            {
                var gl = generalLedgerTransactionReasonCodeMap.SingleOrDefault(g => g.TransactionReasonCode == manhattanPerpetualInventoryTransfer.TransactionReasonCode);

                var databaseIntegrationsInventoryAdjustment = new DatabaseIntegrationsInventoryAdjustment
                {
                    IntegrationDT = DateTime.Now, 
                    UOM = "Each", 
                    created_date = DateTime.Now,
                    gl_account = gl.GeneralLedgerAccount,

                };
            }
        }
    }
}
