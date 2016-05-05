using System;
using Dapper.Contrib.Extensions;

namespace Middleware.Log
{
    [Table("OrderHistory")]
    public class OrderHistory
    {
        public OrderHistory()
        {
            Date = DateTime.Now;
        }

        public OrderHistory(string orderNumber, string controlNumber, string itemSku, string note, string jobKey)
            : this()
        {
            OrderNumber = orderNumber;
            ControlNumber = controlNumber;
            ItemSku = itemSku;
            Note = note;
            JobKey = jobKey;
        }

        [Key]
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string ControlNumber { get; set; }
        public string ItemSku { get; set; }
        public string Note { get; set; }
        public string JobKey { get; set; }
        public DateTime Date { get; set; } 
    }
}
