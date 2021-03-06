USE [NBXWEB]
GO
/****** Object:  Table [dbo].[Kiosk_ShipmentConfirmationHeader]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Kiosk_ShipmentConfirmationHeader](
	[UpdateDate] [datetime] NOT NULL,
	[UpdateUserID] [varchar](20) NOT NULL,
	[UpdatePID] [varchar](20) NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[ShipmentConfirmationHeaderID] [int] IDENTITY(1,1) NOT NULL,
	[ExternalUID] [varchar](50) NOT NULL,
	[OrderID] [varchar](50) NOT NULL,
	[LoadID] [varchar](20) NOT NULL,
	[TrackingNumber] [varchar](30) NOT NULL,
	[ClientID] [varchar](20) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[OrderType] [varchar](10) NOT NULL,
	[OrderPriority] [varchar](10) NOT NULL,
	[OrderStatus] [varchar](10) NOT NULL,
	[ShipDate] [datetime] NOT NULL,
	[ExpectedDeliveryDate] [datetime] NOT NULL,
	[CustomerPORef] [varchar](50) NOT NULL,
	[CustomerPODate] [datetime] NOT NULL,
	[RouteID] [varchar](15) NOT NULL,
	[StopID] [varchar](5) NOT NULL,
	[FacilityNbr] [varchar](2) NOT NULL,
	[ShipFromName] [varchar](50) NOT NULL,
	[ShipFromAddr1] [varchar](50) NOT NULL,
	[ShipFromAddr2] [varchar](50) NOT NULL,
	[ShipFromCity] [varchar](50) NOT NULL,
	[ShipFromState] [varchar](50) NOT NULL,
	[ShipFromPostalCode] [varchar](10) NOT NULL,
	[ShipFromCountryCode] [varchar](20) NOT NULL,
	[BillToCustomerID] [varchar](20) NOT NULL,
	[BillToCustomerName] [varchar](50) NOT NULL,
	[BillToCustomerAddr1] [varchar](50) NOT NULL,
	[BillToCustomerAddr2] [varchar](50) NOT NULL,
	[BillToCustomerAddr3] [varchar](50) NOT NULL,
	[BillToCustomerAddr4] [varchar](50) NOT NULL,
	[BillToCustomerCity] [varchar](50) NOT NULL,
	[BillToCustomerState] [varchar](20) NOT NULL,
	[BillToCustomerPostalCode] [varchar](20) NOT NULL,
	[BillToCustomerCountryCode] [varchar](20) NOT NULL,
	[SoldToCustomerID] [varchar](20) NOT NULL,
	[SoldToCustomerName] [varchar](50) NOT NULL,
	[SoldToCustomerAbbrevName] [varchar](50) NOT NULL,
	[SoldToCustomerAddr1] [varchar](50) NOT NULL,
	[SoldToCustomerAddr2] [varchar](50) NOT NULL,
	[SoldToCustomerAddr3] [varchar](50) NOT NULL,
	[SoldToCustomerAddr4] [varchar](50) NOT NULL,
	[SoldToCustomerCity] [varchar](50) NOT NULL,
	[SoldToCustomerState] [varchar](50) NOT NULL,
	[SoldToCustomerPostalCode] [varchar](10) NOT NULL,
	[SoldToCustomerCountryCode] [varchar](20) NOT NULL,
	[ShipToCustomerID] [varchar](50) NOT NULL,
	[ShipToCustomerName] [varchar](50) NOT NULL,
	[ShipToCustomerAbbrevName] [varchar](50) NOT NULL,
	[ShipToCustomerAddr1] [varchar](50) NOT NULL,
	[ShipToCustomerAddr2] [varchar](50) NOT NULL,
	[ShipToCustomerAddr3] [varchar](50) NOT NULL,
	[ShipToCustomerAddr4] [varchar](50) NOT NULL,
	[ShipToCustomerCity] [varchar](50) NOT NULL,
	[ShipToCustomerState] [varchar](20) NOT NULL,
	[ShipToCustomerPostalCode] [varchar](10) NOT NULL,
	[ShipToCustomerCountryCode] [varchar](20) NOT NULL,
	[CarrierCode] [varchar](20) NOT NULL,
	[SCAC] [varchar](20) NOT NULL,
	[ShippingTerms] [varchar](10) NOT NULL,
	[BOL] [varchar](30) NOT NULL,
	[Seal1] [varchar](15) NOT NULL,
	[Seal2] [varchar](15) NOT NULL,
	[ContainerSeqNbr] [int] NOT NULL,
	[EquipmentID] [varchar](15) NOT NULL,
	[EquipmentType] [varchar](15) NOT NULL,
	[WeightUOM] [char](4) NOT NULL,
	[TotalWeightShipped] [float] NOT NULL,
	[TotalUnitsShipped] [int] NOT NULL,
	[TotalPalletsShipped] [int] NOT NULL,
	[TotalChepPalletsShipped] [int] NOT NULL,
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
	[OriginalMeasType] [varchar](10) NOT NULL,
	[ShipPackagingCode] [varchar](5) NOT NULL,
	[ShipLadingQty] [int] NOT NULL,
	[ShipWeight] [float] NOT NULL,
	[ShipWeightUOM] [varchar](3) NOT NULL,
	[OrderPackagingCode] [varchar](3) NOT NULL,
	[OrderLadingQty] [int] NOT NULL,
	[OrderWeight] [float] NOT NULL,
	[OrderWeightUOM] [varchar](3) NOT NULL,
	[ShipFromID] [varchar](15) NOT NULL,
	[ActualFreightCharge] [float] NOT NULL,
	[DiscountedFreightCharge] [float] NOT NULL,
	[ASNnbr] [varchar](15) NOT NULL,
	[ShipmentID] [varchar](30) NOT NULL,
	[ActionCode] [char](1) NOT NULL,
	[VendorID] [varchar](15) NOT NULL,
	[ASNdirection] [varchar](3) NOT NULL,
	[ASNfacilityNbr] [varchar](20) NOT NULL,
	[ProNbr] [varchar](30) NOT NULL,
	[BuyerRefNbr] [varchar](50) NOT NULL,
	[OutBoundCarrierCode] [varchar](20) NOT NULL,
	[Status] [varchar](10) NOT NULL,
 CONSTRAINT [PK_IDKioskSHIPHEADER_NEW] PRIMARY KEY CLUSTERED 
(
	[ShipmentConfirmationHeaderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT (getdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT (user_name()) FOR [UpdateUserID]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [UpdatePID]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT (getdate()) FOR [InsertDate]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [ExternalUID]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [OrderID]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [LoadID]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [TrackingNumber]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [ClientID]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('01-01-1970') FOR [OrderDate]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [OrderType]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [OrderPriority]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [OrderStatus]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('01-01-1970') FOR [ShipDate]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('01-01-1970') FOR [ExpectedDeliveryDate]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [CustomerPORef]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('01-01-1970') FOR [CustomerPODate]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [RouteID]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [StopID]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [FacilityNbr]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [ShipFromName]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [ShipFromAddr1]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [ShipFromAddr2]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [ShipFromCity]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [ShipFromState]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [ShipFromPostalCode]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [ShipFromCountryCode]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [BillToCustomerID]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [BillToCustomerName]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [BillToCustomerAddr1]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [BillToCustomerAddr2]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [BillToCustomerAddr3]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [BillToCustomerAddr4]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [BillToCustomerCity]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [BillToCustomerState]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [BillToCustomerPostalCode]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [BillToCustomerCountryCode]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [SoldToCustomerID]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [SoldToCustomerName]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [SoldToCustomerAbbrevName]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [SoldToCustomerAddr1]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [SoldToCustomerAddr2]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [SoldToCustomerAddr3]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [SoldToCustomerAddr4]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [SoldToCustomerCity]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [SoldToCustomerState]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [SoldToCustomerPostalCode]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [SoldToCustomerCountryCode]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [ShipToCustomerID]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [ShipToCustomerName]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [ShipToCustomerAbbrevName]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [ShipToCustomerAddr1]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [ShipToCustomerAddr2]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [ShipToCustomerAddr3]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [ShipToCustomerAddr4]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [ShipToCustomerCity]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [ShipToCustomerState]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [ShipToCustomerPostalCode]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [ShipToCustomerCountryCode]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [CarrierCode]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [SCAC]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [ShippingTerms]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [BOL]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [Seal1]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [Seal2]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ((0)) FOR [ContainerSeqNbr]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [EquipmentID]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [EquipmentType]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('LBS') FOR [WeightUOM]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ((0)) FOR [TotalWeightShipped]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ((0)) FOR [TotalUnitsShipped]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ((0)) FOR [TotalPalletsShipped]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ((0)) FOR [TotalChepPalletsShipped]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [InterfaceUser1]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [InterfaceUser2]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [InterfaceUser3]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [InterfaceUser4]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [InterfaceUser5]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [InterfaceUser6]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [InterfaceUser7]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [InterfaceUser8]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [InterfaceUser9]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [InterfaceUser10]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('INIT LOAD') FOR [InterfaceStatus]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [InterfaceErrorText]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('STANDARD') FOR [OriginalMeasType]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [ShipPackagingCode]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ((0)) FOR [ShipLadingQty]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ((0)) FOR [ShipWeight]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('LB') FOR [ShipWeightUOM]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('PL') FOR [OrderPackagingCode]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ((0)) FOR [OrderLadingQty]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ((0)) FOR [OrderWeight]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('LB') FOR [OrderWeightUOM]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [ShipFromID]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ((0)) FOR [ActualFreightCharge]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ((0)) FOR [DiscountedFreightCharge]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [ASNnbr]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [ShipmentID]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('A') FOR [ActionCode]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [VendorID]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('IN') FOR [ASNdirection]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [ASNfacilityNbr]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [ProNbr]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [BuyerRefNbr]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('') FOR [OutBoundCarrierCode]
GO
ALTER TABLE [dbo].[Kiosk_ShipmentConfirmationHeader] ADD  DEFAULT ('NEW') FOR [Status]
GO
