USE [WMTransactions]
GO
/****** Object:  UserDefinedTableType [dbo].[InventoryShipmentProcessingTable]    Script Date: 2/25/2016 1:50:20 PM ******/
CREATE TYPE [dbo].[InventoryShipmentProcessingTable] AS TABLE(
	[ManhattanShipmentLineItemId] [int] NOT NULL
)
GO
