﻿using System.Linq;
using Middleware.Jobs;
using MiddleWare.Log;
using Middleware.Wm.Pix.Models;
using Middleware.Wm.Pix.Repository;
using WmMiddleware.Pix.Models;

namespace Middleware.Wm.GeneralLedgerReconcilliation
{
    public class GeneralLedgerReconcilliationJob : IUnitOfWork
    {
        private readonly ILog _log;

        private readonly IPerpetualInventoryTransferRepository _perpetualInventoryTransferRepository;

        public GeneralLedgerReconcilliationJob(ILog log, IPerpetualInventoryTransferRepository perpetualInventoryTransferRepository)
        {
            _log = log;
            _perpetualInventoryTransferRepository = perpetualInventoryTransferRepository;
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

            foreach (var manhattanPerpetualInventoryTransfer in unprocessed.Where(u => u.InventoryAdjustmentQuantity != 0))
            {
                if (manhattanPerpetualInventoryTransfer.TransactionType == TransactionType.InventoryAdjustment)
                {
                    var adjustment = new PixInventoryAdjustment(manhattanPerpetualInventoryTransfer);

                    if (adjustment.Quantity > 0)
                    {
                        // create PO
                    }
                    else
                    {
                        // write Integrations_Inventory_Adjustment
                    }
                }

                if (manhattanPerpetualInventoryTransfer.TransactionType == TransactionType.Return)
                {
                    var returnTransaction = new PixReturn(manhattanPerpetualInventoryTransfer);
                    
                }
            }
        }
    }
}
