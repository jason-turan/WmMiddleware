USE [WMTransactions]
GO
/****** Object:  UserDefinedTableType [dbo].[InventoryPixProcessingTable]    Script Date: 2/25/2016 1:50:20 PM ******/
CREATE TYPE [dbo].[InventoryPixProcessingTable] AS TABLE(
	[ManhattanPerpetualInventoryTransferId] [int] NOT NULL
)
GO
