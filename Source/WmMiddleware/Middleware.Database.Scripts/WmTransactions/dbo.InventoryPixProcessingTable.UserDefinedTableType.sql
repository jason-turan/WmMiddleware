USE [WMTransactions]
GO

/****** Object:  UserDefinedTableType [dbo].[InventoryPixProcessingTable]    Script Date: 3/22/2016 3:08:29 PM ******/
CREATE TYPE [dbo].[InventoryPixProcessingTable] AS TABLE(
	[ManhattanPerpetualInventoryTransferId] [int] NOT NULL,
	[ManhattanDateCreated] [nvarchar](9) NULL,
	[ManhattanTimeCreated] [nvarchar](7) NULL
)
GO


