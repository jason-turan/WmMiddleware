using Middleware.Wm.Inventory;

namespace WmMiddleware.Picking.Models
{
    public partial class DatabasePickTicket
    {
        public Order ToOrder()
        {
            return new Order
            {
                BillingAddress = new Address
                {
                    City = BillingCity,
                    Country = BillingCountry,
                    Line1 = BillingAddress1,
                    Line2 = BillingAddress2,
                    Line3 = BillingAddress3,
                    Name = BillingName,
                    State = BillingState,
                    Zip = BillingZip
                },
                ShippingAddress = new Address
                {
                    City = ShippingCity,
                    Country = ShippingCountry,
                    Line1 = ShippingAddress1,
                    Line2 = ShippingAddress2,
                    Line3 = ShippingAddress3,
                    Name = ShippingName,
                    State = ShippingState,
                    Zip = ShippingZip
                },
                BillingPhone = BillingPhone,
                Company = Company,
                CustomerNumber = CustomerNumber,
                Discount = Discount,
                EmailAddress = EmailAddress,
                Freight = Freight,
                GiftMessage1 = GiftMessage1,
                GiftMessage2 = GiftMessage2,
                OrderNumber = OrderNumber,
                OrderDate = OrderDate,
                ShippingMethod = ShippingMethod,
                OrderSource = OrderSource,
                OrderPriority = OrderPriority
            };
        }

        public LineItem ToLineItem()
        {
            return new LineItem
            {
                EachPrice = EachPrice,
                ExtendedPrice = ExtendedPrice,
                InventoryType = InventoryType,
                ItemComments = ItemComments,
                ItemDescription = ItemDescription,
                ItemDiscount = ItemDiscount,
                ItemNumber = ItemNumber,
                ItemSku = ItemSKU,
                Quantity = Quantity,
                ReturnTo = ReturnTo,
                ShipDate = ShipDate,
                UnitOfMeasure = UnitsOfMeasure,
                Color = Color,
                SeasonYear = SeasonYear,
                Style = Style,
                Size = Size
            };
        }
    }
}
