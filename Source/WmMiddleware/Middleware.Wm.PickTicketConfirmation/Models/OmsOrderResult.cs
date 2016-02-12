using System;
using Middleware.Wm.Inventory;

namespace Middleware.Wm.PickTicketConfirmation.Models
{
    public partial class OmsOrderResult
    {
        public Order ToOrder()
        {
            return new Order
            {
                BillingAddress = new Address
                {
                    City = bill_city,
                    Country = bill_country,
                    Line1 = bill_address,
                    Line2 = bill_address2,
                    Line3 = bill_address3,
                    Name = bill_name,
                    State = bill_state,
                    Zip = bill_zip
                },
                ShippingAddress = new Address
                {
                    City = ship_city,
                    Country = ship_country,
                    Line1 = ship_address,
                    Line2 = ship_address2,
                    Line3 = ship_address3,
                    Name = ship_name,
                    State = ship_state,
                    Zip = ship_zip
                },
                BillingPhone = bill_phone,
                Company = company,
                CustomerNumber = customer_number,
                Discount = discount,
                EmailAddress = email_address,
                Freight = freight,
                GiftMessage1 = gift_message_1,
                GiftMessage2 = gift_message_2,
                MiscHandling = misc_handling,
                OrderDate = order_date,
                OrderNumber = order_number,
                OrderPriority = order_priority,
                OrderSource = order_source,
                OriginalOrderId = original_order,
                PaymentApplied = string.Equals(payment_applied, "yes", StringComparison.InvariantCultureIgnoreCase),
                PaymentOnly = string.Equals(payment_only, "yes", StringComparison.InvariantCultureIgnoreCase),
                ShippingMethod = shipping_method,
                ShippingNote = shipping_note,
                ShippingPhone = ship_phone,
                TransactionType = trans_type
            };
        }

        public LineItem ToLineItem()
        {
            return new LineItem
            {
                Color = Color,
                DetailCadreStatus = null,
                EachPrice = each_price,
                ExtendedPrice = ext_price,
                InventoryType = inventory_type,
                ItemComments = item_comments,
                ItemDescription = Description,
                ItemDiscount = item_discount,
                ItemNumber = item_number,
                ItemSku = item_sku,
                Quantity = qty,
                ReturnTo = return_to,
                SeasonYear = SeasonYear,
                ShipDate = ship_date,
                Size = Size,
                Style = Style,
                UnitOfMeasure = unit_of_measure,
            };
        }
    }
}
