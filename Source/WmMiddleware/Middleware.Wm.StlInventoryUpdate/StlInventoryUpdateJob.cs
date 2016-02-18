using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using MiddleWare.Log;
using Middleware.Wm.Pix.Models;
using Middleware.Wm.Pix.Repository;
using Middleware.Wm.Shipment.Models;
using Middleware.Wm.StlInventoryUpdate.Models;
using Middleware.Wm.StlInventoryUpdate.Repository;
using WmMiddleware.Shipment.Repository;

namespace Middleware.Wm.StlInventoryUpdate
{
    public class StlInventoryUpdateJob : IStlInventoryUpdateJob
    {
        private readonly IStlInventoryUpdateRepository _stlInventoryUpdateRepository;
        private readonly IShipmentInventoryAdjustmentRepository _shipmentInventoryAdjustmentRepository;
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IPixInventoryAdjustmentRepository _pixInventoryAdjustmentRepository;
        private readonly IPerpetualInventoryTransferRepository _perpetualInventoryTransferRepository;

        private readonly ILog _log;

        public StlInventoryUpdateJob(ILog log, IStlInventoryUpdateRepository stlInventoryUpdateRepository, 
            IShipmentRepository shipmentRepository, IShipmentInventoryAdjustmentRepository shipmentInventoryAdjustmentRepository,
            IPerpetualInventoryTransferRepository perpetualInventoryTransferRepository, IPixInventoryAdjustmentRepository pixInventoryAdjustmentRepository)
        {
            _log = log;
            _stlInventoryUpdateRepository = stlInventoryUpdateRepository;
            _shipmentRepository = shipmentRepository;
            _shipmentInventoryAdjustmentRepository = shipmentInventoryAdjustmentRepository;
            _perpetualInventoryTransferRepository = perpetualInventoryTransferRepository;
            _pixInventoryAdjustmentRepository = pixInventoryAdjustmentRepository;
        }

        public void RunUnitOfWork(string jobKey)
        {
            //--collect the adjustment data from raw manhattan data
            var pixInventoryAdjustments = _pixInventoryAdjustmentRepository.GetUnprocessedInventoryAdjustments().ToList();
            var shipmentInventoryAdjustments = _shipmentInventoryAdjustmentRepository.GetUnprocessedInventoryAdjustments().ToList();

            //--group the adjustments by UPC
            var stlInventoryItems = JoinAdjustments(pixInventoryAdjustments, shipmentInventoryAdjustments).GroupBy(d => d.Upc)
                        .Select(g => new StlInventoryItem
                            {
                                Upc = g.First().Upc,
                                Quantity = g.Sum(s => s.Quantity),
                                Style = g.First().Style,
                                Attribute = g.First().Attribute,
                                Size = g.First().Size
                            }).ToList();

            using (var transactionScope = new TransactionScope())
            {
                //--apply the adjustments to our inventory
                _stlInventoryUpdateRepository.UpdateStlInventory(stlInventoryItems);

                var logBuilder = new StringBuilder();
                logBuilder.AppendLine(string.Format("StlInventoryUpdate Processed: {0} PIX Entries and {1} Shipment Line Items",
                    pixInventoryAdjustments.ToList().Count, shipmentInventoryAdjustments.ToList().Count));

                //--log specific entries (SKU += Adjustment Quantity)
                if (pixInventoryAdjustments.Any())
                {
                    logBuilder.AppendLine("--Adjustments from PIX--");
                    foreach (var pix in pixInventoryAdjustments)
                    {
                        logBuilder.AppendLine(string.Format("{0} += {1}", pix.Upc, pix.Quantity));
                    }
                }
                if (shipmentInventoryAdjustments.Any())
                {
                    logBuilder.AppendLine("--Adjustments from Shipments--");
                    foreach (var shipment in shipmentInventoryAdjustments)
                    {
                        logBuilder.AppendLine(string.Format("{0} += {1}", shipment.Upc, shipment.Quantity));
                    }
                }
                _log.Debug(logBuilder.ToString());

                //--flag the raw manhattan data as processed. 
                _perpetualInventoryTransferRepository.InsertPixInventoryAdjustmentProcessing(pixInventoryAdjustments);
                _shipmentRepository.InsertShipmentInventoryAdjustmentProcessing(shipmentInventoryAdjustments);

                transactionScope.Complete();
            }
        }

        private IEnumerable<StlInventoryItem> JoinAdjustments(IEnumerable<PixInventoryAdjustment> pixAdjustments,
            IEnumerable<ShipmentInventoryAdjustment> shipmentAdjustments)
        {
            foreach (var x in pixAdjustments)
            {
                yield return new StlInventoryItem
                {
                    Upc = x.Upc,
                    Attribute = x.Attribute,
                    Quantity = x.Quantity,
                    Size = x.Size,
                    Style = x.Style
                };
            }

            foreach (var x in shipmentAdjustments)
            {
                yield return new StlInventoryItem
                {
                    Upc = x.Upc,
                    Attribute = x.Attribute,
                    Quantity = x.Quantity,
                    Size = x.Size,
                    Style = x.Style
                };
            }
        }

    }
}
