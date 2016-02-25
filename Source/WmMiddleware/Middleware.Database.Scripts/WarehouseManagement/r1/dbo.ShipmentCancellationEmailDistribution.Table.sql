USE [WarehouseManagement]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShipmentCancellationEmailDistribution](
	[Company] [nvarchar](20) NULL,
	[DistributionList] [nvarchar](250) NULL,
	[AdministrationSiteLink] [nvarchar](250) NULL
) ON [PRIMARY]

GO
INSERT [dbo].[ShipmentCancellationEmailDistribution] ([Company], [DistributionList], [AdministrationSiteLink]) VALUES (N'NBWE', N'kyle.williams@newbalance.com', N'https://nbwecsc.nbwebexpress.com/orders/order_home.asp?order_number=')
