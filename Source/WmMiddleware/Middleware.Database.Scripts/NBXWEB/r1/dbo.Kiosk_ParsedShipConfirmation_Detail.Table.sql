USE [NBXWEB]
GO
/****** Object:  Table [dbo].[Kiosk_ParsedShipConfirmation_Detail]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Kiosk_ParsedShipConfirmation_Detail](
	[UpdateDate] [datetime] NULL,
	[ShipmentConfirmationHeaderID] [int] NULL,
	[SKU] [char](15) NULL,
	[UnitsShipped] [int] NULL,
	[UnitsOrdered] [int] NULL,
	[TrackingNumber] [varchar](50) NULL,
	[DetailSeqNbr] [int] NULL,
	[InterfaceStatus] [char](32) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
