USE [WMTransactions]
GO

/****** Object:  UserDefinedTableType [dbo].[InventoryShipmentProcessingTable]    Script Date: 3/22/2016 3:09:26 PM ******/
CREATE TYPE [dbo].[InventoryShipmentProcessingTable] AS TABLE(
	[ManhattanShipmentLineItemId] [int] NOT NULL,
	[ManhattanDateCreated] [nvarchar](9) NULL,
	[ManhattanTimeCreated] [nvarchar](7) NULL
)
GO


