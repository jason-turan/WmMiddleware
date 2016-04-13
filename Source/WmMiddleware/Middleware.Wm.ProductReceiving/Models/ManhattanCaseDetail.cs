using System;
using Middleware.Wm.Extensions;
using Middleware.Wm.Manhattan.Extensions;
using StringExtensions = Middleware.Wm.Manhattan.Extensions.StringExtensions;

namespace Middleware.Wm.ProductReceiving.Models
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
            SecDimension = StringExtensions.ConvertToManhattanSize(item.Size).Truncate(3);
            ShipmentNumber = shippingNotification.ExternalUid;
            ShippedAsnQuantity = item.UnitsShipped;
            PurchaseOrderNumber = shippingNotification.CustomerPurchaseOrderReference;
        }
        #region "Bl"
        #endregion
        public DateTime CreateDate
        {
            get { return MainframeExtensions.ParseDateTime(DateCreated, TimeCreated); }
            set
            {
                DateCreated = value.ToMainframeDate();
                TimeCreated = value.ToMainframeTime();
            }
        }
    }
}
