using System;
using WmMiddleware.Common.Extensions;

namespace WmMiddleware.ProductReceiving.Models
{
    internal partial class ManhattanSkuDetail
    {
        public ManhattanSkuDetail()
        {
            
        }

        public ManhattanSkuDetail(PurchaseReturn purchaseReturn, LineItem item, string batchControlNumber, string companyNumber, string warehouseNumber)
        {
            BatchControlNumber = batchControlNumber;
            CreateDate = DateTime.Now;
            AsnType = AutomatedShippingNotificationType.PurchaseReturn;
            ShipmentNumber = purchaseReturn.ExternalUid;
            Company = companyNumber;
            Division = warehouseNumber;
            SeasonYear = item.SeasonYear;
            Style = item.Style;
            Color = item.Color;
            SecDimension = item.Size.ToManhattanSize().Truncate(3);
            InventoryType = "F";
            UnitsShipped = item.QuantityOrdered;
            Function = "2";
        }

        public ManhattanSkuDetail(PurchaseOrder purchaseOrder, LineItem item, string batchControlNumber, string companyNumber, string warehouseNumber)
        {
            BatchControlNumber = batchControlNumber;
            CreateDate = DateTime.Now;
            AsnType = AutomatedShippingNotificationType.PurchaseOrder;
            ShipmentNumber = purchaseOrder.ExternalUid;
            Company = companyNumber;
            Division = warehouseNumber;
            SeasonYear = item.SeasonYear;
            Style = item.Style;
            Color = item.Color;
            SecDimension = item.Size.ToManhattanSize().Truncate(3);
            InventoryType = "F";
            UnitsShipped = item.QuantityOrdered;
            Function = "2";
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
