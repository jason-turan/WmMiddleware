using System;
using System.Globalization;
using Middleware.Wm.Manhattan.Extensions;
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
            get { return _pix.PackageBarcode; }
        }

        public string UnitOfMeasure
        {
            get { return "Each"; }
        }

        public int NumberUnitsShipped
        {
            get { return (int) _pix.UnitsShipped; }
        }

        public string PoNumber
        {
            get { return _pix.Ponumber; }
        }
        
        public string InvoiceNumber
        {
            get { return _pix.TransactionNumber.ToString(CultureInfo.InvariantCulture); }
        }
        
        public DateTime InvoiceIssuedDate 
        {
            get { return MainframeExtensions.ParseDateTime(_pix.DateCreated, _pix.TimeCreated); }
        }

        public DateTime PurchaserPoDate { get; set; }

        public string Shippeddatetimereference
        {
            get { return DateTime.Now.ToString("yyyyMMdd"); }
        }

        public int LineItemNumber
        {
            get { return _pix.SequenceNumber; }
        }
    }
}
