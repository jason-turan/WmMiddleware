namespace WmMiddleware.ProductReceiving.Models
{
    public class PurchaseReturnLineItem
    {
        public string StyleNumber { get; set; }

        public string ProductSize { get; set; }
        
        public string ProductAttribute { get; set; }
        
        public string UnversalProductCode { get; set; }
        
        public int TotalQuantity { get; set; }
    }
}
