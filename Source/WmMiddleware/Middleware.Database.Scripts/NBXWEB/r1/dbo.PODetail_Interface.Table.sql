USE [NBXWEB]
GO
/****** Object:  Table [dbo].[PODetail_Interface]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PODetail_Interface](
	[UpdatePID] [varchar](10) NULL,
	[ActionCode] [varchar](1) NULL,
	[Direction] [varchar](3) NULL,
	[InterfaceDate] [datetime] NULL,
	[InterfaceStatus] [varchar](32) NULL,
	[CreateDate] [datetime] NULL,
	[IDPOHeaderInterface] [int] NULL,
	[FacilityNbr] [varchar](2) NULL,
	[POLineNbr] [int] NULL,
	[SKU] [varchar](31) NULL,
	[UPC] [varchar](31) NULL,
	[Class] [varchar](10) NULL,
	[QtyOrd] [numeric](19, 0) NULL,
	[VendorPartNbr] [varchar](31) NULL,
	[HotFlag] [varchar](1) NULL,
	[Price] [numeric](19, 5) NULL,
	[Extension] [numeric](19, 5) NULL,
	[DateExpect] [datetime] NULL,
	[BuyerRef] [varchar](17) NULL,
	[UOM] [varchar](10) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
