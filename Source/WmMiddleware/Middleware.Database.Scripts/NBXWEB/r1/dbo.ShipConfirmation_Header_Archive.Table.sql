USE [NBXWEB]
GO
/****** Object:  Table [dbo].[ShipConfirmation_Header_Archive]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ShipConfirmation_Header_Archive](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[Company] [varchar](50) NULL,
	[UpdateDate] [datetime] NULL,
	[IDInterfaceShipmentConfirmation] [int] NULL,
	[CustomerPoRef] [varchar](17) NULL,
	[UpdateGP] [int] NULL,
	[UpdateAdmin] [int] NULL,
	[InterfaceStatus] [char](32) NULL,
	[CarrierCode] [char](10) NULL,
	[TrackingNumber] [varchar](30) NULL,
	[ShipDate] [datetime] NULL,
	[ExpectedDeliveryDate] [datetime] NULL,
	[ArchivedDate] [datetime] NULL,
 CONSTRAINT [PK_ShipConfirmation_Header_Archive] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ShipConfirmation_Header_Archive] ADD  CONSTRAINT [DF_ShipConfirmation_Header_Archive_ArchivedDate]  DEFAULT (getdate()) FOR [ArchivedDate]
GO
