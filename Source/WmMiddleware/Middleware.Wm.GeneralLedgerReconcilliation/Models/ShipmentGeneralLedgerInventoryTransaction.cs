using System;
using Middleware.Wm.Manhattan.Extensions;
using Middleware.Wm.Manhattan.Shipment;

namespace Middleware.Wm.GeneralLedgerReconcilliation.Models
{
    public class ShipmentGeneralLedgerInventoryTransaction : GeneralLedgerInventoryTransaction, IGeneralLedgerInventoryTransaction
    {
        private readonly ManhattanShipmentLineItem _shipmentLineItem;

        public ShipmentGeneralLedgerInventoryTransaction(ManhattanShipmentLineItem manhattanShipmentLineItem)
        {
            _shipmentLineItem = manhattanShipmentLineItem;
        }

        public string GeneralLedgerAccount
        {
            get { return "37850-01-0000"; }
        }

        public string VarianceAccount
        {
            get
            {
                if (_shipmentLineItem.ProductClass == null)
                {
                    return "17200-01-0000";
                }

                switch (_shipmentLineItem.ProductClass.ToUpper())
                {
                    case "FOOTWEAR":
                        return "17100-01-0000";
                    case "ACCESSORY":
                        return "17000-01-0000";
                    default:
                        return "17200-01-0000";
                }
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
