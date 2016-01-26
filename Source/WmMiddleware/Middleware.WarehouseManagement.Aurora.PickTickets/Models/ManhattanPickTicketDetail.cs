namespace Middleware.WarehouseManagement.Aurora.PickTickets.Models
{
    internal partial class ManhattanPickTicketDetail
    {
        public LineItem ToLineItem()
        {
            return new LineItem
            {
                ItemSku = "Test",//PackageBarcode,
                Quantity = (int)OriginalPickticketQuantity
            };
        }
    }
}
