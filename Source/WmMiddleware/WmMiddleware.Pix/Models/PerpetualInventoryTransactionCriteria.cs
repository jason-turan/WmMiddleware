namespace WmMiddleware.Pix.Models
{
    public class PerpetualInventoryTransactionCriteria
    {
        public string TransactionCode { get; set; }

        public string TransactionType { get; set; }

        public bool? UnprocessedOnly { get; set; }
    }
}
