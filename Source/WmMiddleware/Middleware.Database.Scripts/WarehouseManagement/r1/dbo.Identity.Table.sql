USE [WarehouseManagement]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Identity](
	[BatchControlNumber] [numeric](18, 0) NOT NULL
) ON [PRIMARY]

GO
INSERT [dbo].[Identity] ([BatchControlNumber]) VALUES (CAST(4453 AS Numeric(18, 0)))
