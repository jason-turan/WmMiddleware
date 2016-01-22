namespace WmMiddleware.ProductReceiving.Models
{
    public partial class DatabasePurchaseReturn 
    {
        public PurchaseReturn ToPurchaseReturn()
        {
            return new PurchaseReturn
            {
                OrderNumber = order_number,
                ReturnReason = return_reason,
                ReturnReasonAdditionalInformation = additional_return_reason,
                ToBeExchange = to_be_exchange,
                CustomerReturnDate = row_submit_date,
                TrackingNumber = tracking
            };
        }

        public PurchaseReturnLineItem ToLineItem()
        {
            return new PurchaseReturnLineItem
            {
                StyleNumber = style_number,
                ProductSize = prod_size,
                ProductAttribute = attribute,
                UnversalProductCode = UPC,
            };
        }
    }
}
