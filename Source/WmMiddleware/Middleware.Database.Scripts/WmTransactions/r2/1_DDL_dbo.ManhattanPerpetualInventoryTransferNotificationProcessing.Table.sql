USE [WMTransactions]
GO

/****** Object:  Table [dbo].[ManhattanPerpetualInventoryTransferGeneralLedgerProcessing]    Script Date: 4/18/2016 2:13:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ManhattanPerpetualInventoryTransferNotificationProcessing](
	[NotificationProcessingId] [int] IDENTITY(1,1) NOT NULL,
	[ManhattanPerpetualInventoryTransferId] [int] NULL,
	[ProcessedDate] [datetime] NOT NULL
PRIMARY KEY CLUSTERED 
(
	[NotificationProcessingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ManhattanPerpetualInventoryTransferNotificationProcessing]  WITH CHECK ADD FOREIGN KEY([ManhattanPerpetualInventoryTransferId])
REFERENCES [dbo].[ManhattanPerpetualInventoryTransfer] ([ManhattanPerpetualInventoryTransferId])
GO


