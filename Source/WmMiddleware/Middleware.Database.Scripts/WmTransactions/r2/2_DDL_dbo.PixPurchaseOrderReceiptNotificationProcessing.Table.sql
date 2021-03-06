USE [WMTransactions]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PixPurchaseOrderReceiptNotificationProcessing](
	[PurchaseOrderReceiptNotificationProcessingId] [int] IDENTITY(1,1) NOT NULL,
	[ManhattanPerpetualInventoryTransferId] [int] NOT NULL,
	[ProcessedDate] [datetime] NOT NULL
PRIMARY KEY CLUSTERED 
(
	[PurchaseOrderReceiptNotificationProcessingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[PixPurchaseOrderReceiptNotificationProcessing]  WITH CHECK ADD FOREIGN KEY([ManhattanPerpetualInventoryTransferId])
REFERENCES [dbo].[ManhattanPerpetualInventoryTransfer] ([ManhattanPerpetualInventoryTransferId])
GO

ALTER TABLE [dbo].[PixPurchaseOrderReceiptNotificationProcessing]  
ADD CONSTRAINT PixPurchaseOrderReceiptNotificationProcessing_ManhattanPerpetualInventoryTransferIdUnique 
UNIQUE NONCLUSTERED([ManhattanPerpetualInventoryTransferId])
GO

