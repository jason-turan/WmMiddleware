USE [WMTransactions]
GO
/****** Object:  UserDefinedTableType [dbo].[OrderNumberTable]    Script Date: 2/25/2016 1:50:20 PM ******/
CREATE TYPE [dbo].[OrderNumberTable] AS TABLE(
	[OrderNumber] [varchar](15) NOT NULL
)
GO
