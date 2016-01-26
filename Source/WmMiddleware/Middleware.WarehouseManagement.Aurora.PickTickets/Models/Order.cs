using System;
using System.Collections.Generic;

namespace Middleware.WarehouseManagement.Aurora.PickTickets.Models
{
    public class Order
    {
        public Order()
        {
            Items = new List<LineItem>();
        }

        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public Address BillingAddress { get; set; }
        public string BillingPhone { get; set; }
        public Address ShippingAddress { get; set; }
        public string ShippingPhone { get; set; }
        public string EmailAddress { get; set; }
        public string ShippingMethod { get; set; }
        public List<LineItem> Items { get; set; }
    }
}
