USE [NBXWEB]
GO
/****** Object:  UserDefinedTableType [dbo].[OrderNumberTable]    Script Date: 2/25/2016 1:54:55 PM ******/
CREATE TYPE [dbo].[OrderNumberTable] AS TABLE(
	[OrderNumber] [varchar](15) NOT NULL
)
GO
