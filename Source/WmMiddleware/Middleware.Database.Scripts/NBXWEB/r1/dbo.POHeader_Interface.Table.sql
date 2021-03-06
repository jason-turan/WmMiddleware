USE [NBXWEB]
GO
/****** Object:  Table [dbo].[POHeader_Interface]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[POHeader_Interface](
	[ActionCode] [varchar](1) NULL,
	[Direction] [varchar](3) NULL,
	[UpdatePID] [varchar](10) NULL,
	[InterfaceStatus] [varchar](32) NULL,
	[InterfaceDate] [datetime] NULL,
	[CreateDate] [datetime] NULL,
	[ExternalUID] [varchar](17) NULL,
	[POSTATUS] [smallint] NULL,
	[POTYPE] [smallint] NULL,
	[PODate] [datetime] NULL,
	[FacilityNbr] [varchar](2) NULL,
	[VendorAcct] [varchar](15) NULL,
	[AmtCost] [numeric](19, 5) NULL,
	[DiscAvail] [numeric](19, 5) NULL,
	[AmtFreight] [numeric](19, 5) NULL,
	[DateDue] [datetime] NULL,
	[CreateReceiver] [varchar](1) NULL,
	[BuyerRefNbr] [varchar](17) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
