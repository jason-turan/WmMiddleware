USE [WMTransactions]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ManhattanPerptualInventoryTransferPurchaseOrderNotification](
	[ManhattanPerptualInventoryTransferPurchaseOrderNotificationId] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseOrderNumber] NVarChar(20) NOT NULL,
	[NotificationDate] [datetime] NOT NULL
PRIMARY KEY CLUSTERED 
(
	[ManhattanPerptualInventoryTransferPurchaseOrderNotificationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


