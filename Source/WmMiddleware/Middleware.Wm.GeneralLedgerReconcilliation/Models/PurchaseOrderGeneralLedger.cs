using System;
using WmMiddleware.Pix.Models.Generated;

namespace Middleware.Wm.GeneralLedgerReconcilliation.Models
{
    public class PurchaseOrderGeneralLedger
    {
        private readonly ManhattanPerpetualInventoryTransfer _pix;

        public PurchaseOrderGeneralLedger(ManhattanPerpetualInventoryTransfer pix)
        {
            _pix = pix;
        }

        public string VendorOrderNumber { get; set; }

        public string Sku
        {
            get
            {
                return _pix.PackageBarcode;
            }
        }

        public string QuantityInvoiced { get; set; }

        public string UnitOfMeasure
        {
            get { return "Each"; }
        }

        public int NumberUnitsShipped
        {
            get { return (int)_pix.UnitsShipped; }
        }

        public string PoNumber
        {
            get { return _pix.Ponumber; }
        }


        public string InvoiceNumber { get; set; }

        public DateTime InvoiceIssuedDate { get; set; }

        public DateTime PurchaserPoDate { get; set; }

        public string Shippeddatetimereference { get; set; }

        public int NumberLineItems { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
