namespace Middleware.Wm.ProductReceivingng.Models
{
    public class LineItem
    {
        public int IdPurchaseOrderHeaderInterface { get; set; }
        public int PurchaseOrderLineNumber { get; set; }
        public string Sku { get; set; }
        public string Upc { get; set; }
        public string Class { get; set; }
        public decimal QuantityOrdered { get; set; }
        public string VendorPartNumber { get; set; }
        public decimal Price { get; set; }
        public decimal Extension { get; set; }
        public string BuyerReference { get; set; }
        public string Uom { get; set; }
        public string SeasonYear { get; set; }
        public string Style { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }

        public override string ToString()
        {
            return string.Format("Line Number: {0}", PurchaseOrderLineNumber);
        }
    }
}
