using System;
using System.Collections.Generic;
using Middleware.Wm.Extensions;

namespace Middleware.Wm.Inventory
{
    public class Order
    {
        public Order()
        {
            Items = new List<LineItem>();
            SpecialInstructions = new List<string>();
        }

        public int HeaderId { get; set; }
        public ICollection<LineItem> Items { get; set; }
        public ICollection<string> SpecialInstructions { get; set; }
        public string Company { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime HeaderDownloadDate { get; set; }
        public string CustomerNumber { get; set; } 
        public string OrderPriority { get; set; } 
        public Address BillingAddress { get; set; }
        public string BillingPhone { get; set; }
        public Address ShippingAddress { get; set; }
        public string ShippingPhone { get; set; } 
        public string EmailAddress { get; set; } 
        public string TransactionType { get; set; }
        public string ShippingMethod { get; set; } 
        public double Discount { get; set; } 
        public double Freight { get; set; } 
        public double MiscHandling { get; set; } 
        public int? OriginalOrderId { get; set; } 
        public bool PaymentOnly { get; set; } 
        public string ShippingNote { get; set; } 
        public string GiftMessage1 { get; set; } 
        public string GiftMessage2 { get; set; } 
        public string OrderSource { get; set; } 
        public bool PaymentApplied { get; set; } 

        public string ControlNumber
        {
            get
            {
                var parts = OrderNumber.Split(new []{"-"}, StringSplitOptions.None);
                return parts[0] + parts[1].ConvertIntegerToCharacter();
            }
        }
    }
}
