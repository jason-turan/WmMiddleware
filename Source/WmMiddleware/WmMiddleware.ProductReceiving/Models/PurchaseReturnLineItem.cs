namespace WmMiddleware.ProductReceiving.Models
{
    public class PurchaseReturnLineItem
    {
        public string StyleYear { get; set; }

        public string Style { get; set; }

        public string ProductSize { get; set; }
        
        public string ProductAttribute { get; set; }
        
        public string UnversalProductCode { get; set; }
        
        public int TotalQuantity { get; set; }
    }
}
