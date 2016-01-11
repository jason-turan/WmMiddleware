using System;
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

        public PixReturnJob(ILog log, 
                            IPixReturnRepository pixReturnRepository, 
                            IDatabaseRowReturnRepository databaseRowReturnRepository,
                            IPerpetualInventoryTransferRepository perpetualInventoryTransferRepository)
        {
            _log = log;
            _pixReturnRepository = pixReturnRepository;
            _databaseRowReturnRepository = databaseRowReturnRepository;
            _perpetualInventoryTransferRepository = perpetualInventoryTransferRepository;
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

            foreach (var unprocessedReturn in unprocessedReturns)
            {
                try
                {
                    using (var transactionScope = new TransactionScope())
                    {
                        // translate the manhattan file to a business object
                        var returnOnWeb = new ReturnOnWeb
                        {
                            Company = unprocessedReturn.Company,
                            Condition = unprocessedReturn.ConditionCode,
                            OrderNumber = unprocessedReturn.OrderNumber,
                            Reason = unprocessedReturn.ReturnReason,
                            Size = unprocessedReturn.Size,
                            Timestamp = DateTime.Now, 
                            StockKeepingUnit = unprocessedReturn.StockKeepingUnit,
                            
                            // Status = TODO
                            // ReturnLocation = TODO
                            // Exchange = TODO
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
    }
}
