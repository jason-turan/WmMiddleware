using Middleware.Wm.Extensions;
using Middleware.Wm.Manhattan.Shipment;

namespace WmMiddleware.Shipment.Models
{
    public class ShipmentInventoryAdjustment
    {
        private readonly ManhattanShipmentLineItem _manhattanShipmentLineItem;

        public ShipmentInventoryAdjustment(ManhattanShipmentLineItem manhattanShipmentLineItem)
        {
            _manhattanShipmentLineItem = manhattanShipmentLineItem;
        }

        public string Upc
        {
            get { return _manhattanShipmentLineItem.PackageBarcode; }
        }

        public int Quantity
        {
            get
            {
                return (int)_manhattanShipmentLineItem.ShippedQuantity * -1;
            }
        }

        public string Style
        {
            get { return _manhattanShipmentLineItem.ShippedSeasonYear + _manhattanShipmentLineItem.ShippedStyle; }
        }

        public string Size
        {
            get { return _manhattanShipmentLineItem.ShippedSecDimn.ToEcommSize(); }
        }

        public string Attribute
        {
            get { return _manhattanShipmentLineItem.ShippedColor; }
        }

        public int ManhattanShipmentLineItemId
        {
            get { return _manhattanShipmentLineItem.ManhattanShipmentLineItemId; }
        }
    }
}
