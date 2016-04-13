using System;
using System.Collections.Generic;
using System.Linq;
using Middleware.Wm.Configuration;
using Middleware.Wm.Manhattan.Extensions;
using WmMiddleware.Pix.Models.Generated;

namespace Middleware.Wm.GeneralLedgerReconcilliation.Models
{
    public class PixGeneralLedgerInventoryTransaction : GeneralLedgerInventoryTransaction, IGeneralLedgerInventoryTransaction
    {
        private readonly ManhattanPerpetualInventoryTransfer _pix;
        private readonly IList<GeneralLedgerTransactionReasonCodeMap> _generalLedgerTransactionReasonCodeMap;

        public PixGeneralLedgerInventoryTransaction(ManhattanPerpetualInventoryTransfer pix,
                                                    IList<GeneralLedgerTransactionReasonCodeMap> generalLedgerTransactionReasonCodeMap,
                                                    IConfigurationManager configurationManager) : base(configurationManager)
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
            get { return GetVarianceAccountByProductClass(_pix.ProductClass); }
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
       