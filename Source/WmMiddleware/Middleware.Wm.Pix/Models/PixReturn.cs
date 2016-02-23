using System;
using WmMiddleware.Pix.Models.Generated;

namespace Middleware.Wm.Pix.Models
{
    public class PixReturn
    {
        private readonly ManhattanPerpetualInventoryTransfer _perpetualInventoryTransfer;

        public PixReturn(ManhattanPerpetualInventoryTransfer perpetualInventoryTransfer)
        {
            if (perpetualInventoryTransfer.TransactionCode != TransactionCode.Return)
            {
                throw new ArgumentException(perpetualInventoryTransfer.TransactionCode + " is not a valid pix return code");
            }

            if (perpetualInventoryTransfer.TransactionType != TransactionType.QuantityAdjust)
            {
                throw new ArgumentException(perpetualInventoryTransfer.TransactionType + " is not a valid pix return type");
            }

            _perpetualInventoryTransfer = perpetualInventoryTransfer;
        }

        public int ManhattanPerpetualInventoryTransferId()
        {
            return _perpetualInventoryTransfer.ManhattanPerpetualInventoryTransferId;
        }

        public bool ReturnToStock()
        {
            return ConditionCode.StartsWith("A");
        }

        public string StockKeepingUnit
        {
           get{  return _perpetualInventoryTransfer.PackageBarcode;}
        }

        public string Style
        {
            get { return _perpetualInventoryTransfer.SeasonYear + _perpetualInventoryTransfer.Style; }
        }

        public string User
        {
            get { return _perpetualInventoryTransfer.UserId; }
        }

        public string ConditionCode
        {
            get { return _perpetualInventoryTransfer.Reference4; }
        }

        public string OrderNumber
        {
            get { return _perpetualInventoryTransfer.Shipmentnumber; }
        }

        public string Width
        {
            get { return _perpetualInventoryTransfer.Color; }
        }

        public string Size
        {
            get { return _perpetualInventoryTransfer.SecDimension; }
        }

        public string Company
        {
            get { return _perpetualInventoryTransfer.Company; }
        }

        public string ReturnReason
        {
            get { return _perpetualInventoryTransfer.TransactionReasonCode; }
        }

        public string ReturnReasonDescription
        {
            get { return _perpetualInventoryTransfer.ReasonCodeShortDescription; }
        }
    }
}
