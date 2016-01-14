using System;
using Dapper.Contrib.Extensions;

namespace WmMiddleware.PixReturn.Models
{
    [Table("Row_Return")]
    public class DatabaseRowReturn
    {
        public DatabaseRowReturn(ReturnOnWeb returnOnWeb)
        {
            Order_Number = returnOnWeb.OrderNumber;
            Company = returnOnWeb.Company;
            Condition = returnOnWeb.Condition;
            Reason = returnOnWeb.Reason;
            Size = returnOnWeb.Size;
            SKU = returnOnWeb.StockKeepingUnit;
            Style = returnOnWeb.Style;
            Width = returnOnWeb.Width;
            Timestamp = returnOnWeb.Timestamp;
            UserName = returnOnWeb.UserName;
            Status = returnOnWeb.Status;
        }

        public long id { get; set; }
        public string Company { get; set; }
        public string Order_Number { get; set; }
        public string SKU { get; set; }
        public string Style { get; set; }
        public string Size { get; set; }
        public string Width { get; set; }
        public string Condition { get; set; }
        public string Reason { get; set; }
        public DateTime? Timestamp { get; set; }
        public string Status { get; set; }
        public string UserName { get; set; }
    }
}
