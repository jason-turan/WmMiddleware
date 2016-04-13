USE [WMTransactions]
GO
/****** Object:  UserDefinedTableType [dbo].[StlInventoryUpdateTable]    Script Date: 2/25/2016 1:50:20 PM ******/
CREATE TYPE [dbo].[StlInventoryUpdateTable] AS TABLE(
	[UPC] [char](13) NOT NULL,
	[Style] [varchar](50) NULL,
	[Size] [varchar](50) NULL,
	[Attribute] [varchar](50) NULL,
	[Quantity] [int] NOT NULL
)
GO
