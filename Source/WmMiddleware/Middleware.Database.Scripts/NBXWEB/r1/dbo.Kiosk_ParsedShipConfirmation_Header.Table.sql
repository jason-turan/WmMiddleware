USE [NBXWEB]
GO
/****** Object:  Table [dbo].[Kiosk_ParsedShipConfirmation_Header]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Kiosk_ParsedShipConfirmation_Header](
	[Store_ID] [varchar](50) NULL,
	[UpdateDate] [datetime] NULL,
	[ShipmentConfirmationID] [int] NULL,
	[OrderNumber] [varchar](25) NULL,
	[DesignID] [varchar](25) NULL,
	[UpdateGP] [int] NULL,
	[UpdateAdmin] [int] NULL,
	[InterfaceStatus] [char](32) NULL,
	[TrackingNumber] [varchar](30) NULL,
	[ShipDate] [datetime] NULL,
	[ExpectedDeliveryDate] [datetime] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
