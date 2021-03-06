USE [NBXWEB]
GO
/****** Object:  Table [dbo].[InterfaceShipmentConfirmationDetail]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InterfaceShipmentConfirmationDetail](
	[UpdateDate] [datetime] NOT NULL,
	[UpdateUserID] [varchar](20) NOT NULL,
	[UpdatePID] [varchar](20) NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[IDInterfaceShipmentConfirmationHeader] [int] NOT NULL,
	[IDInterfaceShipmentConfirmationDetail] [int] IDENTITY(1,1) NOT NULL,
	[SKU] [varchar](20) NOT NULL DEFAULT (''),
	[SKUClass] [varchar](10) NOT NULL DEFAULT (''),
	[SKUdesc] [varchar](50) NOT NULL DEFAULT (''),
	[UPC] [varchar](20) NOT NULL DEFAULT (''),
	[UOM] [varchar](20) NOT NULL DEFAULT (''),
	[UnitsShipped] [int] NOT NULL DEFAULT ((0)),
	[UnitsOrdered] [int] NOT NULL DEFAULT ((0)),
	[ParentMUID] [varchar](20) NOT NULL DEFAULT (''),
	[ParentMUType] [varchar](20) NOT NULL DEFAULT (''),
	[ChildMUID] [varchar](20) NOT NULL DEFAULT (''),
	[ChildMUType] [varchar](20) NOT NULL DEFAULT (''),
	[Height] [float] NOT NULL DEFAULT ((0)),
	[Width] [float] NOT NULL DEFAULT ((0)),
	[Length] [float] NOT NULL DEFAULT ((0)),
	[Weight] [decimal](18, 4) NOT NULL DEFAULT ((0)),
	[LotID] [varchar](20) NOT NULL DEFAULT (''),
	[VendorID] [varchar](20) NOT NULL DEFAULT (''),
	[MfgDate] [datetime] NOT NULL DEFAULT ('19700101'),
	[ExpDate] [datetime] NOT NULL DEFAULT ('19700101'),
	[SerialNbr] [varchar](20) NOT NULL DEFAULT (''),
	[InterfaceUser1] [varchar](256) NOT NULL DEFAULT (''),
	[InterfaceUser2] [varchar](256) NOT NULL DEFAULT (''),
	[InterfaceUser3] [varchar](256) NOT NULL DEFAULT (''),
	[InterfaceUser4] [varchar](256) NOT NULL DEFAULT (''),
	[InterfaceUser5] [varchar](256) NOT NULL DEFAULT (''),
	[InterfaceUser6] [varchar](256) NOT NULL DEFAULT (''),
	[InterfaceUser7] [varchar](256) NOT NULL DEFAULT (''),
	[InterfaceUser8] [varchar](256) NOT NULL DEFAULT (''),
	[InterfaceUser9] [varchar](256) NOT NULL DEFAULT (''),
	[InterfaceUser10] [varchar](256) NOT NULL DEFAULT (''),
	[InterfaceStatus] [char](32) NOT NULL DEFAULT ('INIT LOAD'),
	[InterfaceErrorText] [varchar](256) NOT NULL DEFAULT (''),
	[PalletTypeCode] [varchar](3) NOT NULL DEFAULT ('PF'),
	[PalletTiers] [int] NOT NULL DEFAULT ((0)),
	[PalletBlocks] [int] NOT NULL DEFAULT ((0)),
	[PalletInnerBlocks] [int] NOT NULL DEFAULT ((0)),
	[PalletWeight] [decimal](18, 4) NOT NULL DEFAULT ((0)),
	[PalletWeightUOM] [varchar](3) NOT NULL DEFAULT ('LB'),
	[PalletVolume] [float] NOT NULL DEFAULT ((0)),
	[PalletVolumeUOM] [varchar](3) NOT NULL DEFAULT ('CF'),
	[PalletDimensionUOM] [varchar](3) NOT NULL DEFAULT ('FT'),
	[ExternalUID] [varchar](50) NOT NULL DEFAULT (''),
	[ShipmentID] [varchar](30) NOT NULL DEFAULT (''),
	[EachQty] [int] NOT NULL DEFAULT ((0)),
	[ActionCode] [char](1) NOT NULL DEFAULT ('A'),
	[DetailSeqNbr] [int] NOT NULL DEFAULT ((0)),
	[CartonQTY] [int] NOT NULL DEFAULT ((0)),
	[PalletQTY] [int] NOT NULL DEFAULT ((0)),
	[TareWeight] [decimal](18, 4) NOT NULL DEFAULT ((0)),
	[NetWeight] [decimal](18, 4) NOT NULL DEFAULT ((0)),
	[Status] [char](10) NOT NULL DEFAULT ('NEW'),
 CONSTRAINT [PK_SHIPDetailID_NEW] PRIMARY KEY CLUSTERED 
(
	[IDInterfaceShipmentConfirmationDetail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
