using System;
using System.Collections.Generic;
using System.Linq;
using Middleware.Wm.Manhattan.Extensions;
using WmMiddleware.Pix.Models.Generated;

namespace Middleware.Wm.GeneralLedgerReconcilliation.Models
{
    public class PixGeneralLedgerInventoryTransaction : GeneralLedgerInventoryTransaction, IGeneralLedgerInventoryTransaction
    {
        private readonly ManhattanPerpetualInventoryTransfer _pix;
        private readonly IList<GeneralLedgerTransactionReasonCodeMap> _generalLedgerTransactionReasonCodeMap;

        public PixGeneralLedgerInventoryTransaction(ManhattanPerpetualInventoryTransfer pix,
                                                          IList<GeneralLedgerTransactionReasonCodeMap> generalLedgerTransactionReasonCodeMap)
        {
            _pix = pix;
            _generalLedgerTransactionReasonCodeMap = generalLedgerTransactionReasonCodeMap;
        }

        public string GeneralLedgerAccount
        {
            get
            {
                var gl = _generalLedgerTransactionReasonCodeMap.SingleOrDefault(g => g.TransactionReasonCode == _pix.TransactionReasonCode);
                return gl == null ? null : gl.GeneralLedgerAccount;
            }
        }

        public string VarianceAccount
        {
            get
            {
                switch (_pix.ProductClass.ToUpper())
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
                return _pix.PackageBarcode;
            }
        }

        public int Quantity
        {
            get { return (int) _pix.InventoryAdjustmentQuantity; }
        }

        public string BatchIdentification
        {
            get { return "INVADJ-" + _pix.DateCreated; }
        }

        public string ReasonCode
        {
            get { return _pix.TransactionReasonCode; }
        }

        public DateTime InventoryDate
        {
            get { return MainframeExtensions.ParseDateTime(_pix.DateCreated,0); }
        }
    }
}
       