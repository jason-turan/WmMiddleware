using System;
using System.Collections.Generic;
using MiddleWare.Log;
using Middleware.Wm.GeneralLedgerReconcilliation.Models;
using WmMiddleware.Pix.Models.Generated;

namespace Middleware.Wm.GeneralLedgerReconcilliation.Repository
{
    public class GeneralLedgerReconcilliationRepository : IGeneralLedgerReconcilliationRepository
    {
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

                    _databaseRepository.InsertPixGeneralLedgerProcessing(new PixGeneralLedgerProcessing
                    {
                        ManhattanPerpetualInventoryTransferId = pix.ManhattanPerpetualInventoryTransferId,
                        ProcessedDate = DateTime.Now
                    });
                }
                catch (Exception exception)
                {
                    _log.Exception("Fatal error processing pix transaction number " + pix.TransactionNumber, exception);
                }
            }
        }
    }
}