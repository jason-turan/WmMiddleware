﻿using System.Collections.Generic;
using System.Linq;
using MiddleWare.Log;
using WmMiddleware.Pix.Repository;
using WmMiddleware.Shipment.Repository;
using WmMiddleware.StlInventoryUpdate.Repository;
using System.Transactions;

namespace WmMiddleware.StlInventoryUpdate
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
                        .Select(g => new Models.StlInventoryItem
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

                _log.Debug(string.Format("Consumed {0} PIX Entries and {1} Shipment Line Items into StlInventory!",
                    pixInventoryAdjustments.ToList().Count, shipmentInventoryAdjustments.ToList().Count));

                //--flag the raw manhattan data as processed. 
                _perpetualInventoryTransferRepository.InsertPixInventoryAdjustmentProcessing(pixInventoryAdjustments);
                _shipmentRepository.InsertShipmentInventoryAdjustmentProcessing(shipmentInventoryAdjustments);

                transactionScope.Complete();
            }
        }

        private IEnumerable<Models.StlInventoryItem> JoinAdjustments(IEnumerable<Pix.Models.PixInventoryAdjustment> pixAdjustments,
            IEnumerable<Shipment.Models.ShipmentInventoryAdjustment> shipmentAdjustments)
        {
            foreach (var x in pixAdjustments)
            {
                yield return new Models.StlInventoryItem
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
                yield return new Models.StlInventoryItem
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
