﻿using System;
using Middleware.Wm.Manhattan.Extensions;

namespace Middleware.Wm.ProductReceiving.Models
{
    internal partial class ManhattanReceivedProductHeader
    {
        public ManhattanReceivedProductHeader()
        {
            
        }

        public ManhattanReceivedProductHeader(string batchControlNumber, string warehouseNumber)
        {
            BatchControlNumber = batchControlNumber;
            CreateDate = DateTime.Now;
            ToLocation = warehouseNumber;
            Function = "2";
            WholesalerTransferFlag = "N";
            QcHoldUponReceipt = "N";
            SystemCreated = "N";
            OutSourceFlag = "N";
        }

        public ManhattanReceivedProductHeader(PurchaseOrder purchaseOrder, string batchControlNumber, string warehouseNumber)
            : this(batchControlNumber, warehouseNumber)
        {
            AsnType = "1";//1 for manual POs, 3 for inbound ASNs, 4 for returns
            ShipmentNumber = purchaseOrder.ExternalUid;
        }

        public ManhattanReceivedProductHeader(PurchaseReturn purchaseOrder, string batchControlNumber, string warehouseNumber)
            : this(batchControlNumber, warehouseNumber)
        {
            AsnType = "4";//1 for manual POs, 3 for inbound ASNs, 4 for returns
            ShipmentNumber = purchaseOrder.OrderNumber;
            MiscellaneousAlphaField3 = "NBUS";
            MiscellaneousAlphaField4 = "CDS";
        }

        public ManhattanReceivedProductHeader(AutomatedShippingNotification shippingNotification, string batchControlNumber, string warehouseNumber)
            : this(batchControlNumber, warehouseNumber)
        {
            AsnType = "3";//1 for manual POs, 3 for inbound ASNs, 4 for returns
            ShipmentNumber = shippingNotification.ExternalUid;
        }

        public DateTime CreateDate
        {
            get { return MainframeExtensions.ParseDateTime(DateCreated, TimeCreated); }
            set
            {
                DateCreated = value.ToMainframeDate();
                TimeCreated = value.ToMainframeTime();
                ProcessedDate = DateCreated;
                ProcessedTime = TimeCreated;
            }
        }
    }
}
