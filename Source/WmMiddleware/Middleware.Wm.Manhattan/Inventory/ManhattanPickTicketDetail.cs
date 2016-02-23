using System;
using Dapper.Contrib.Extensions;
using Middleware.Wm.Extensions;
using Middleware.Wm.Inventory;
using Middleware.Wm.Manhattan.Extensions;

namespace Middleware.Wm.Manhattan.Inventory
{
    public partial class ManhattanPickTicketDetail
    {
        public ManhattanPickTicketDetail()
        {
            
        }

        public ManhattanPickTicketDetail(LineItem item, string batchControlNumber, string pickticketControlNumber, string companyNumber, string warehouseNumber)
        {
            BatchControlNumber = batchControlNumber;
            CreateDate = DateTime.Now;
            Company = companyNumber;
            Division = warehouseNumber;
            PickticketControlNumber = pickticketControlNumber.Length > 10 ? pickticketControlNumber.Substring(0,10) : pickticketControlNumber;
            
            PickticketLineNumber = (int)item.ItemNumber;//stored as double? truncate?
            Warehouse = warehouseNumber;
            SeasonYear = item.SeasonYear;
            Style = item.Style;
            Color = item.Color;
            SecDimension = item.Size.ToManhattanSize().Truncate(3);
            PackageBarcode = item.ItemSku;
            InventoryType = "F";
            OriginalOrderQuantity = item.Quantity;
            OriginalPickticketQuantity = item.Quantity;
            PickticketQuantity = item.Quantity;
            CancelQuantity = 0;
            BoxQuantity = 1;
            PreCubeFlag = "0";
            RetailPrice = (decimal)item.EachPrice;
            RecordExpansionField = "N";
            CustomRecordExpansionField = item.ItemDescription;
        }
        
        [Write(false)]
        public DateTime CreateDate
        {
            get { return ManhattanExtensions.ParseDateTime(DateCreated, TimeCreated); }
            set
            {
                DateCreated = value.ToMainframeDate();
                TimeCreated = value.ToMainframeTime();
            }
        }

        public LineItem ToLineItem()
        {
            return new LineItem
            {
                ItemSku = PackageBarcode,
                Quantity = (int)OriginalPickticketQuantity
            };
        }
    }
}
