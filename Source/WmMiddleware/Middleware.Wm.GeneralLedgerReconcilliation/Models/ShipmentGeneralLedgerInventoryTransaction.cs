using System;
using Middleware.Wm.Configuration;
using Middleware.Wm.Manhattan.Extensions;
using Middleware.Wm.Manhattan.Shipment;

namespace Middleware.Wm.GeneralLedgerReconcilliation.Models
{
    public class ShipmentGeneralLedgerInventoryTransaction : GeneralLedgerInventoryTransaction, IGeneralLedgerInventoryTransaction
    {
        private readonly ManhattanShipmentLineItem _shipmentLineItem;
        private readonly IConfigurationManager _configurationManager;

        public ShipmentGeneralLedgerInventoryTransaction(ManhattanShipmentLineItem manhattanShipmentLineItem,
                                                         IConfigurationManager configurationManager) : base(configurationManager)
        {
            _shipmentLineItem = manhattanShipmentLineItem;
            _configurationManager = configurationManager;
        }

        public string GeneralLedgerAccount
        {
            get { return _configurationManager.GetKey<string>(ConfigurationKey.GeneralLedgeBrickAndClickAccount); }
        }

        public string VarianceAccount
        {
            get
            {
                return _shipmentLineItem.ProductClass == null ? _configurationManager.GetKey<string>(ConfigurationKey.GeneralLedgerVarianceAccountDefault) : GetVarianceAccountByProductClass(_shipmentLineItem.ProductClass);
            }
        }

        public string Sku
        {
            get
            {
                return _shipmentLineItem.PackageBarcode;
            }
        }

        public int Quantity
        {
            get { return (int)_shipmentLineItem.PickticketQuantity; }
        }

        public string BatchIdentification
        {
            get { return "INVADJ-" + _shipmentLineItem.DateCreated; }
        }

        public string ReasonCode
        {
            get { return string.Empty; }
        }

        public DateTime InventoryDate
        {
            get { return MainframeExtensions.ParseDateTime(_shipmentLineItem.DateCreated, 0); }
        }
    }
}
