using System;
using Middleware.Wm.Extensions;
using Middleware.Wm.Manhattan.Extensions;
using WmMiddleware.Pix.Models.Generated;

namespace Middleware.Wm.Pix.Models
{
    public class PixInventoryAdjustment
    {
        private readonly ManhattanPerpetualInventoryTransfer _perpetualInventoryTransfer;

        public PixInventoryAdjustment(ManhattanPerpetualInventoryTransfer perpetualInventoryTransfer)
        {
            if (perpetualInventoryTransfer.TransactionType != TransactionType.InventoryAdjustment)
            {
                throw new ArgumentException(perpetualInventoryTransfer.TransactionType + " is not a valid pix type");
            }

            _perpetualInventoryTransfer = perpetualInventoryTransfer;
        }

        public string Upc
        {
            get { return _perpetualInventoryTransfer.PackageBarcode; }
        }

        public int Quantity
        {
            get
            {
                if (_perpetualInventoryTransfer.InventoryAdjustmntType == "S")
                    return (int)_perpetualInventoryTransfer.InventoryAdjustmentQuantity * -1;
             
                return (int)_perpetualInventoryTransfer.InventoryAdjustmentQuantity;
            }
        }

        public string Style
        {
            get { return _perpetualInventoryTransfer.SeasonYear + _perpetualInventoryTransfer.Style; }
        }

        public string Size
        {
            get { return _perpetualInventoryTransfer.SecDimension.ConvertFromManhattanSize(); }
        }

        public string Attribute
        {
            get { return _perpetualInventoryTransfer.Color; }
        }

        public int ManhattanPerpetualInventoryTransferId
        {
            get { return _perpetualInventoryTransfer.ManhattanPerpetualInventoryTransferId; }
        }

    }
}
