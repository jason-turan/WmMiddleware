using System.Globalization;
using WmMiddleware.Common.Extensions;

namespace Middleware.WarehouseManagement.Aurora.PickTickets.Models
{
    internal partial class ManhattanPickTicketHeader
    {
        public Order ToOrder()
        {
            return new Order
            {
                BillingAddress = new Address
                {
                    City = SoldToCity,
                    Country = SoldToCountry,
                    Line1 = SoldToAddr1,
                    Line2 = SoldToAddr2,
                    Line3 = SoldToAddr3,
                    Name = SoldToName,
                    State = SoldToState,
                    Zip = SoldToZip
                },
                ShippingAddress = new Address
                {
                    City = ShipToCity,
                    Country = ShipToCountry,
                    Line1 = ShipToAddr1,
                    Line2 = ShipToAddr2,
                    Line3 = ShipToAddr3,
                    Name = ShipToName,
                    State = ShipToState,
                    Zip = ShipToZip
                },
                OrderNumber = OrderNumber, //MiscellaneousIns20Byte11, ?
                OrderDate = (OrderDate != 0 ? ManhattanExtensions.ParseDateTime(OrderDate, 0, DateTimeStyles.AssumeUniversal) : ManhattanExtensions.ParseDateTime(DateCreated, 0, DateTimeStyles.AssumeUniversal)).ToUniversalTime(),
                BillingPhone = TelephoneNumber,
                ShippingPhone = TelephoneNumber,
                EmailAddress = "bncorder@newbalance.com",
                ShippingMethod = "Ground"
            };
        }
    }
}
