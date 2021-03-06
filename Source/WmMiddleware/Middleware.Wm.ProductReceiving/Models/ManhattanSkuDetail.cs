﻿using System;
using Middleware.Wm.Extensions;
using Middleware.Wm.Manhattan.Extensions;

namespace Middleware.Wm.ProductReceiving.Models
{
    internal partial class ManhattanSkuDetail
    {
        public ManhattanSkuDetail()
        {
            
        }

        public ManhattanSkuDetail(PurchaseReturn purchaseReturn, PurchaseReturnLineItem item, string batchControlNumber, string companyNumber, string warehouseNumber)
        {
            BatchControlNumber = batchControlNumber;
            CreateDate = DateTime.Now;
            AsnType = AutomatedShippingNotificationType.PurchaseReturn;
            ShipmentNumber = purchaseReturn.OrderNumber;
            Company = companyNumber;
            Division = warehouseNumber;
            SeasonYear = item.StyleYear;
            Style = item.Style; 
            Color = item.ProductAttribute;
            SecDimension = item.ProductSize.ConvertToManhattanSize().Truncate(3);
            InventoryType = "F";
            UnitsShipped = item.TotalQuantity;
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
            SecDimension = item.Size.ConvertToManhattanSize().Truncate(3);
            InventoryType = "F";
            UnitsShipped = item.QuantityOrdered;
            Function = "2";
        }

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
