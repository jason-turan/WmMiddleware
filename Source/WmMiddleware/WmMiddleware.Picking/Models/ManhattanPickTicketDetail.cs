using System;
using WmMiddleware.Common.Extensions;

namespace WmMiddleware.Picking.Models
{
    internal partial class ManhattanPickTicketDetail
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
            PickticketControlNumber = pickticketControlNumber;
            
            PickticketLineNumber = (int)item.ItemNumber;//stored as double? truncate?
            Warehouse = warehouseNumber;
            //WaveProcessingType = ??
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
            //AssortmentNumber = ??
            //NumberUnitsInPpacks = ??
            PreCubeFlag = "0";
            //Price = ??
            RetailPrice = (decimal)item.EachPrice;
            //InventoryAllocationType = ??
            //MiscField1 = ??
            //MiscField2 = ??
            //MiscField3 = ??
            RecordExpansionField = "N";
            CustomRecordExpansionField = item.ItemDescription;
            //MiscNumber8 = ??
        }

        public DateTime CreateDate
        {
            get { return ManhattanExtensions.ParseDateTime(DateCreated, TimeCreated); }
            set
            {
                DateCreated = value.ToManhattanDate();
                TimeCreated = value.ToManhattanTime();
            }
        }
    }
}
