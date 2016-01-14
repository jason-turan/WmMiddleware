using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using MiddleWare.Log;

using WmMiddleware.Pix.Repository;
using WmMiddleware.PixReturn.Models;
using WmMiddleware.PixReturn.Repository;

namespace WmMiddleware.PixReturn
{
    public class PixReturnJob : IPixReturnJob
    {
        private readonly ILog _log;
        private readonly IPixReturnRepository _pixReturnRepository;
        private readonly IPerpetualInventoryTransferRepository _perpetualInventoryTransferRepository;
        private readonly IDatabaseRowReturnRepository _databaseRowReturnRepository;
        private readonly IManhattanConditionCodeRepository _manhattanConditionCodeRepository;

        public PixReturnJob(ILog log, 
                            IPixReturnRepository pixReturnRepository, 
                            IDatabaseRowReturnRepository databaseRowReturnRepository,
                            IPerpetualInventoryTransferRepository perpetualInventoryTransferRepository,
                            IManhattanConditionCodeRepository manhattanConditionCodeRepository)
        {
            _log = log;
            _pixReturnRepository = pixReturnRepository;
            _databaseRowReturnRepository = databaseRowReturnRepository;
            _perpetualInventoryTransferRepository = perpetualInventoryTransferRepository;
            _manhattanConditionCodeRepository = manhattanConditionCodeRepository;
        }

        public void RunUnitOfWork(string jobKey)
        {
            // read pix
            var unprocessedReturns = _pixReturnRepository.GetUnprocessedReturns().ToList();
            
            if (unprocessedReturns.Any())
            {
                _log.Info("Processing " + unprocessedReturns.Count() + " PIX returns");
            }
            else
            {
                _log.Info("No PIX returns to process.");
                return;
            }

            var conditionCodes = _manhattanConditionCodeRepository.GetConditionCodes().ToList();

            foreach (var unprocessedReturn in unprocessedReturns)
            {
                try
                {
                    using (var transactionScope = new TransactionScope())
                    {
                        var condition = unprocessedReturn.ReturnToStock() ? "INVENTORY" : "DEFECT";

                        var reason = GetConditionCode(conditionCodes, unprocessedReturn);

                        // translate the manhattan file to a business object
                        var returnOnWeb = new ReturnOnWeb
                        {
                            Company = unprocessedReturn.Company,
                            Condition = condition,
                            Reason = reason,
                            Style = unprocessedReturn.Style,
                            OrderNumber = unprocessedReturn.OrderNumber,
                            Width = unprocessedReturn.Width,
                            Size = unprocessedReturn.Size,
                            Timestamp = DateTime.Now, 
                            StockKeepingUnit = unprocessedReturn.StockKeepingUnit,
                            Status = "NEW",
                            UserName = unprocessedReturn.User
                        };

                        // map business object to row return and write to NBXWEB
                        _databaseRowReturnRepository.InsertRowReturn(new DatabaseRowReturn(returnOnWeb));

                        // insert processed row
                        _perpetualInventoryTransferRepository.InsertManhattanPerpetualInventoryTransferProcessing(unprocessedReturn.ManhattanPerpetualInventoryTransferId());

                        transactionScope.Complete();
                    }
                }
                catch (Exception exception)
                {
                    _log.Exception("Error processing Manhattan PIX with id of " + unprocessedReturn.ManhattanPerpetualInventoryTransferId(), 
                                   exception);
                }
            }
        }

        private static string GetConditionCode(IEnumerable<ManhattanConditionCode> conditionCodes, Pix.Models.PixReturn unprocessedReturn)
        {
            var conditionCode = conditionCodes.SingleOrDefault(cc => cc.Code == unprocessedReturn.ConditionCode);
            var reason = string.Empty;

            if (conditionCode != null)
            {
                reason = conditionCode.Reason;
            }
            return reason;
        }
    }
}
