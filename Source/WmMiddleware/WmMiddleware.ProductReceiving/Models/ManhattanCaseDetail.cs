using System;
using Middleware.Wm.Extensions;

namespace WmMiddleware.ProductReceiving.Models
{
    internal partial class ManhattanCaseDetail
    {
        public ManhattanCaseDetail()
        {
            
        }

        public ManhattanCaseDetail(AutomatedShippingNotification shippingNotification, AutomatedShippingNotificationItem item, string batchControlNumber, string companyNumber, string warehouseNumber)
        {
            BatchControlNumber = batchControlNumber;
            CreateDate = DateTime.Now;
            Company = companyNumber;
            Division = warehouseNumber;
            InventoryType = "F";
            Function = "2";
            Warehouse = warehouseNumber;
            WarehouseTransferFlag = "N";
            StatusCode = "00";

            CaseNumber = item.ParentMuId;
            SeasonYear = item.SeasonYear;
            Style = item.Style;
            Color = item.Color;
            SecDimension = item.Size.ToManhattanSize().Truncate(3);
            ShipmentNumber = shippingNotification.ExternalUid;
            ShippedAsnQuantity = shippingNotification.TotalUnitsShipped;
            PurchaseOrderNumber = shippingNotification.CustomerPurchaseOrderReference;
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
