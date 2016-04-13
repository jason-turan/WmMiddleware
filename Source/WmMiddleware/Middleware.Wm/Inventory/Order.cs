using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Middleware.Log;
using Middleware.Wm.Extensions;

namespace Middleware.Wm.Inventory
{
    public enum OrderType
    {
        BrickAndClick,
        Other
    }
    public class Order
    {
        public Order()
        {
            Items = new List<LineItem>();
            SpecialInstructions = new List<string>();
        }

        public int HeaderId { get; set; }
        public List<LineItem> Items { get; set; }
        public List<string> SpecialInstructions { get; set; }
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

        [XmlIgnore]
        public string ArAccountNumber { get; set; }
        
        [XmlIgnore]
        public string CustomerPurchaseOrderNumber { get; set; }
        
        [XmlIgnore]
        public OrderType? OrderType { get; set; }

        [XmlIgnore]
        public Dictionary<string, int> LineItems { get; set; }

        public string ControlNumber
        {
            get
            {
                var parts = OrderNumber.Split(new []{"-"}, StringSplitOptions.None);
                if (parts.Length == 1)
                {
                    return OrderNumber;
                }
                return parts[0] + parts[1].ConvertIntegerToCharacter();
            }
        }

        public IEnumerable<OrderHistory> CreateHistories(string note, string jobKey)
        {
            return Items.Select(i => new OrderHistory(OrderNumber, ControlNumber, i.ItemSku, note, jobKey));
        }
    }
}
