USE [NBXWEB]
GO
/****** Object:  UserDefinedTableType [dbo].[PurchaseOrderTable]    Script Date: 2/25/2016 1:54:55 PM ******/
CREATE TYPE [dbo].[PurchaseOrderTable] AS TABLE(
	[PONumber] [varchar](17) NOT NULL
)
GO
