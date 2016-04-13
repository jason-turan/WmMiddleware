using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Middleware.Jobs;
using Middleware.Log;
using Middleware.Log.Repository;
using Middleware.Wm.Configuration.Transaction;
using Middleware.Wm.Manhattan.Extensions;
using Middleware.Wm.Manhattan.Inventory;
using Middleware.Wm.Pix.Repository;
using Middleware.Wm.PixReturn.Models;
using Middleware.Wm.PixReturn.Repository;

namespace Middleware.Wm.PixReturn
{
    public class PixReturnJob : IUnitOfWork
    {
        private readonly ILog _log;
        private readonly IPixReturnRepository _pixReturnRepository;
        private readonly IPerpetualInventoryTransferRepository _perpetualInventoryTransferRepository;
        private readonly IDatabaseRowReturnRepository _databaseRowReturnRepository;
        private readonly IManhattanConditionCodeRepository _manhattanConditionCodeRepository;
        private readonly IOmsManhattanOrderMapRepository _omsManhattanOrderMapRepository;
        private readonly IOrderHistoryRepository _orderHistoryRepository;

        public PixReturnJob(ILog log, 
                            IPixReturnRepository pixReturnRepository, 
                            IDatabaseRowReturnRepository databaseRowReturnRepository,
                            IPerpetualInventoryTransferRepository perpetualInventoryTransferRepository,
                            IManhattanConditionCodeRepository manhattanConditionCodeRepository,
                            IOmsManhattanOrderMapRepository omsManhattanOrderMapRepository,
                            IOrderHistoryRepository orderHistoryRepository)
        {
            _log = log;
            _pixReturnRepository = pixReturnRepository;
            _databaseRowReturnRepository = databaseRowReturnRepository;
            _perpetualInventoryTransferRepository = perpetualInventoryTransferRepository;
            _manhattanConditionCodeRepository = manhattanConditionCodeRepository;
            _omsManhattanOrderMapRepository = omsManhattanOrderMapRepository;
            _orderHistoryRepository = orderHistoryRepository;
        }

        public void RunUnitOfWork(string jobKey)
        {
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
            _orderHistoryRepository.Save(unprocessedReturns.Select(r => new OrderHistory(r.OrderNumber, null, null, "Pix return", "Pix Return Job")));
            foreach (var unprocessedReturn in unprocessedReturns)
            {
                try
                {
                    using (var transactionScope = Scope.CreateTransactionScope())
                    {
                        var condition = unprocessedReturn.ReturnToStock() ? "INVENTORY" : "DEFECT";

                        var reason = GetConditionCode(conditionCodes, unprocessedReturn);

                        // translate the manhattan file to a business object
                        var returnOnWeb = new ReturnOnWeb
                        {
                            Company = GetCompany(unprocessedReturn.OrderNumber),
                            Condition = condition,
                            Reason = reason,
                            Style = unprocessedReturn.Style,
                            OrderNumber = unprocessedReturn.OrderNumber,
                            Width = unprocessedReturn.Width,
                            Size = unprocessedReturn.Size.FromManhattanShoeSize(),
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

        private string GetCompany(string orderNumber)
        {
            var lookup = _omsManhattanOrderMapRepository.GetOmsManhattanOrderMap(new OmsManhattanOrderMapFindCriteria
            {
                ManhattanOrderNumber = orderNumber
            });

            if (lookup != null) return lookup.Company;

            if (orderNumber.Length < 2)
            {
                return "UNKNOWN";
            }

            var prefix = orderNumber.Substring(0, 2);

            switch (prefix)
            {
                case "NA":
                    return "NBAU";
                case "WS":
                    return "WAR";
                case "NS":
                    return "NBUS";
                case "PS":
                    return "PF";
                case "DS":
                    return "DRY";
                default:
                    return char.IsDigit(orderNumber[0]) ? "JBNO" : "UNKNOWN";
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
