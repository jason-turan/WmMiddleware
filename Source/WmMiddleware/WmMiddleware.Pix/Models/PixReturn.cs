using System;
using WmMiddleware.Pix.Models.Generated;

namespace WmMiddleware.Pix.Models
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

            if (perpetualInventoryTransfer.TransactionType != TransactionType.Return)
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
           get{  return _perpetualInventoryTransfer.SkuBatchnumber;}
        }

        public string ConditionCode
        {
            get { return _perpetualInventoryTransfer.Reference4; }
        }

        public string OrderNumber
        {
            get { return _perpetualInventoryTransfer.Shipmentnumber; }
        }

        public string Size
        {
            get
            {
                return string.Format(Convert.ToInt32(_perpetualInventoryTransfer.SecDimension).ToString("N1"));
            }
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
