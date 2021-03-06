USE [NBXWEB]
GO
/****** Object:  Table [dbo].[ShipConfirmation_Detail_Archive]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ShipConfirmation_Detail_Archive](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[UpdateDate] [datetime] NULL,
	[IDInterfaceShipmentConfirmationHeader] [int] NULL,
	[SKU] [char](15) NULL,
	[UnitsShipped] [int] NULL,
	[UnitsOrdered] [int] NULL,
	[DetailSeqNbr] [int] NULL,
	[InterfaceStatus] [char](32) NULL,
	[ArchiveDate] [datetime] NULL,
 CONSTRAINT [PK_ShipConfirmation_Detail_Archive] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ShipConfirmation_Detail_Archive] ADD  CONSTRAINT [DF_ShipConfirmation_Detail_Archive_ArchiveDate]  DEFAULT (getdate()) FOR [ArchiveDate]
GO
