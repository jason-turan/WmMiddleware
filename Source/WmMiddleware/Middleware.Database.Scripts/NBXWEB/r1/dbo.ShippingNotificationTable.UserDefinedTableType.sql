USE [NBXWEB]
GO
/****** Object:  UserDefinedTableType [dbo].[ShippingNotificationTable]    Script Date: 2/25/2016 1:54:55 PM ******/
CREATE TYPE [dbo].[ShippingNotificationTable] AS TABLE(
	[IDInterfaceShipmentConfirmationHeader] [int] NOT NULL
)
GO
