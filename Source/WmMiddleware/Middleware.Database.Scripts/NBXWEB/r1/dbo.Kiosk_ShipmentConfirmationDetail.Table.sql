USE [NBXWEB]
GO
/****** Object:  Table [dbo].[Kiosk_ShipmentConfirmationDetail]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Kiosk_ShipmentConfirmationDetail](
	[UpdateDate] [datetime] NOT NULL,
	[UpdateUserID] [varchar](20) NOT NULL,
	[UpdatePID] [varchar](20) NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[ShipmentConfirmationHeaderID] [int] NOT NULL,
	[ShipmentConfirmationDetailID] [int] IDENTITY(1,1) NOT NULL,
	[SKU] [varchar](20) NOT NULL,
	[SKUClass] [varchar](10) NOT NULL,
	[SKUdesc] [varchar](50) NOT NULL,
	[UPC] [varchar](20) NOT NULL,
	[UOM] [varchar](20) NOT NULL,
	[UnitsShipped] [int] NOT NULL,
	[UnitsOrdered] [int] NOT NULL,
	[ParentMUID] [varchar](20) NOT NULL,
	[ParentMUType] [varchar](20) NOT NULL,
	[ChildMUID] [varchar](20) NOT NULL,
	[ChildMUType] [varchar](20) NOT NULL,
	[Height] [float] NOT NULL,
	[Width] [float] NOT NULL,
	[Length] [float] NOT NULL,
	[Weight] [decimal](18, 4) NOT NULL,
	[LotID] [varchar](20) NOT NULL,
	[VendorID] [varchar](20) NOT NULL,
	[MfgDate] [datetime] NOT NULL,
	[ExpDate] [datetime] NOT NULL,
	[SerialNbr] [varchar](20) NOT NULL,
	[InterfaceUser1] [varchar](256) NOT NULL,
	[InterfaceUser2] [varchar](256) NOT NULL,
	[InterfaceUser3] [varchar](256) NOT NULL,
	[InterfaceUser4] [varchar](256) NOT NULL,
	[InterfaceUser5] [varchar](256) NOT NULL,
	[InterfaceUser6] [varchar](256) NOT NULL,
	[InterfaceUser7] [varchar](256) NOT NULL,
	[InterfaceUser8] [varchar](256) NOT NULL,
	[InterfaceUser9] [varchar](256) NOT NULL,
	[InterfaceUser10] [varchar](256) NOT NULL,
	[InterfaceStatus] [char](32) NOT NULL,
	[InterfaceErrorText] [varchar](256) NOT NULL,
	[PalletTypeCode] [varchar](3) NOT NULL,
	[PalletTiers] [int] NOT NULL,
	[PalletBlocks] [int] NOT NULL,
	[PalletInnerBlocks] [int] NOT NULL,
	[PalletWeight] [decimal](18, 4) NOT NULL,
	[PalletWeightUOM] [varchar](3) NOT NULL,
	[PalletVolume] [float] NOT NULL,
	[PalletVolumeUOM] [varchar](3) NOT NULL,
	[PalletDimensionUOM] [varchar](3) NOT NULL,
	[ExternalUID] [varchar](50) NOT NULL,
	[ShipmentID] [varchar](30) NOT NULL,
	[EachQty] [int] NOT NULL,
	[ActionCode] [char](1) NOT NULL,
	[DetailSeqNbr] [int] NOT NULL,
	[CartonQTY] [int] NOT NULL,
	[PalletQTY] [int] NOT NULL,
	[TareWeight] [decimal](18, 4) NOT NULL,
	[NetWeight] [decimal](18, 4) NOT NULL,
	[Status] [char](10) NOT NULL,
 CONSTRAINT [PK_KioskSHIPDetailID_NEW] PRIMARY KEY CLUSTERED 
(
	[ShipmentConfirmationDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ('') FOR [SKU]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ('') FOR [SKUClass]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ('') FOR [SKUdesc]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ('') FOR [UPC]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ('') FOR [UOM]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ((0)) FOR [UnitsShipped]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ((0)) FOR [UnitsOrdered]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ('') FOR [ParentMUID]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ('') FOR [ParentMUType]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ('') FOR [ChildMUID]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ('') FOR [ChildMUType]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ((0)) FOR [Height]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ((0)) FOR [Width]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ((0)) FOR [Length]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ((0)) FOR [Weight]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ('') FOR [LotID]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ('') FOR [VendorID]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ('19700101') FOR [MfgDate]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ('19700101') FOR [ExpDate]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ('') FOR [SerialNbr]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ('') FOR [InterfaceUser1]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ('') FOR [InterfaceUser2]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ('') FOR [InterfaceUser3]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ('') FOR [InterfaceUser4]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ('') FOR [InterfaceUser5]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ('') FOR [InterfaceUser6]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ('') FOR [InterfaceUser7]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ('') FOR [InterfaceUser8]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ('') FOR [InterfaceUser9]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ('') FOR [InterfaceUser10]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ('INIT LOAD') FOR [InterfaceStatus]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ('') FOR [InterfaceErrorText]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ('PF') FOR [PalletTypeCode]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ((0)) FOR [PalletTiers]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ((0)) FOR [PalletBlocks]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ((0)) FOR [PalletInnerBlocks]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ((0)) FOR [PalletWeight]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ('LB') FOR [PalletWeightUOM]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ((0)) FOR [PalletVolume]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ('CF') FOR [PalletVolumeUOM]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ('FT') FOR [PalletDimensionUOM]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ('') FOR [ExternalUID]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ('') FOR [ShipmentID]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ((0)) FOR [EachQty]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ('A') FOR [ActionCode]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ((0)) FOR [DetailSeqNbr]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ((0)) FOR [CartonQTY]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ((0)) FOR [PalletQTY]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ((0)) FOR [TareWeight]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ((0)) FOR [NetWeight]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationDetail] ADD  DEFAULT ('NEW') FOR [Status]
GO
