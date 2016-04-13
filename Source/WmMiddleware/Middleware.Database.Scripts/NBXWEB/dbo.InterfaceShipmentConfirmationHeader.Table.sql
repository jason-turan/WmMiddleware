USE [NBXWEB]
GO
/****** Object:  Table [dbo].[InterfaceShipmentConfirmationHeader]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InterfaceShipmentConfirmationHeader](
	[UpdateDate] [datetime] NOT NULL DEFAULT (getdate()),
	[UpdateUserID] [varchar](20) NOT NULL DEFAULT (user_name()),
	[UpdatePID] [varchar](20) NOT NULL DEFAULT (''),
	[InsertDate] [datetime] NOT NULL DEFAULT (getdate()),
	[IDInterfaceShipmentConfirmationHeader] [int] IDENTITY(1,1) NOT NULL,
	[ExternalUID] [varchar](50) NOT NULL DEFAULT (''),
	[OrderID] [varchar](50) NOT NULL DEFAULT (''),
	[LoadID] [varchar](20) NOT NULL DEFAULT (''),
	[TrackingNumber] [varchar](30) NOT NULL DEFAULT (''),
	[ClientID] [varchar](20) NOT NULL DEFAULT (''),
	[OrderDate] [datetime] NOT NULL DEFAULT ('01-01-1970'),
	[OrderType] [varchar](10) NOT NULL DEFAULT (''),
	[OrderPriority] [varchar](10) NOT NULL DEFAULT (''),
	[OrderStatus] [varchar](10) NOT NULL DEFAULT (''),
	[ShipDate] [datetime] NOT NULL DEFAULT ('01-01-1970'),
	[ExpectedDeliveryDate] [datetime] NOT NULL DEFAULT ('01-01-1970'),
	[CustomerPORef] [varchar](20) NOT NULL DEFAULT (''),
	[CustomerPODate] [datetime] NOT NULL DEFAULT ('01-01-1970'),
	[RouteID] [varchar](15) NOT NULL DEFAULT (''),
	[StopID] [varchar](5) NOT NULL DEFAULT (''),
	[FacilityNbr] [varchar](2) NOT NULL DEFAULT (''),
	[ShipFromName] [varchar](50) NOT NULL DEFAULT (''),
	[ShipFromAddr1] [varchar](50) NOT NULL DEFAULT (''),
	[ShipFromAddr2] [varchar](50) NOT NULL DEFAULT (''),
	[ShipFromCity] [varchar](50) NOT NULL DEFAULT (''),
	[ShipFromState] [varchar](50) NOT NULL DEFAULT (''),
	[ShipFromPostalCode] [varchar](10) NOT NULL DEFAULT (''),
	[ShipFromCountryCode] [varchar](20) NOT NULL DEFAULT (''),
	[BillToCustomerID] [varchar](20) NOT NULL DEFAULT (''),
	[BillToCustomerName] [varchar](50) NOT NULL DEFAULT (''),
	[BillToCustomerAddr1] [varchar](50) NOT NULL DEFAULT (''),
	[BillToCustomerAddr2] [varchar](50) NOT NULL DEFAULT (''),
	[BillToCustomerAddr3] [varchar](50) NOT NULL DEFAULT (''),
	[BillToCustomerAddr4] [varchar](50) NOT NULL DEFAULT (''),
	[BillToCustomerCity] [varchar](50) NOT NULL DEFAULT (''),
	[BillToCustomerState] [varchar](20) NOT NULL DEFAULT (''),
	[BillToCustomerPostalCode] [varchar](20) NOT NULL DEFAULT (''),
	[BillToCustomerCountryCode] [varchar](20) NOT NULL DEFAULT (''),
	[SoldToCustomerID] [varchar](20) NOT NULL DEFAULT (''),
	[SoldToCustomerName] [varchar](50) NOT NULL DEFAULT (''),
	[SoldToCustomerAbbrevName] [varchar](50) NOT NULL DEFAULT (''),
	[SoldToCustomerAddr1] [varchar](50) NOT NULL DEFAULT (''),
	[SoldToCustomerAddr2] [varchar](50) NOT NULL DEFAULT (''),
	[SoldToCustomerAddr3] [varchar](50) NOT NULL DEFAULT (''),
	[SoldToCustomerAddr4] [varchar](50) NOT NULL DEFAULT (''),
	[SoldToCustomerCity] [varchar](50) NOT NULL DEFAULT (''),
	[SoldToCustomerState] [varchar](50) NOT NULL DEFAULT (''),
	[SoldToCustomerPostalCode] [varchar](10) NOT NULL DEFAULT (''),
	[SoldToCustomerCountryCode] [varchar](20) NOT NULL DEFAULT (''),
	[ShipToCustomerID] [varchar](50) NOT NULL DEFAULT (''),
	[ShipToCustomerName] [varchar](50) NOT NULL DEFAULT (''),
	[ShipToCustomerAbbrevName] [varchar](50) NOT NULL DEFAULT (''),
	[ShipToCustomerAddr1] [varchar](50) NOT NULL DEFAULT (''),
	[ShipToCustomerAddr2] [varchar](50) NOT NULL DEFAULT (''),
	[ShipToCustomerAddr3] [varchar](50) NOT NULL DEFAULT (''),
	[ShipToCustomerAddr4] [varchar](50) NOT NULL DEFAULT (''),
	[ShipToCustomerCity] [varchar](50) NOT NULL DEFAULT (''),
	[ShipToCustomerState] [varchar](20) NOT NULL DEFAULT (''),
	[ShipToCustomerPostalCode] [varchar](10) NOT NULL DEFAULT (''),
	[ShipToCustomerCountryCode] [varchar](20) NOT NULL DEFAULT (''),
	[CarrierCode] [varchar](20) NOT NULL DEFAULT (''),
	[SCAC] [varchar](20) NOT NULL DEFAULT (''),
	[ShippingTerms] [varchar](10) NOT NULL DEFAULT (''),
	[BOL] [varchar](30) NOT NULL DEFAULT (''),
	[Seal1] [varchar](15) NOT NULL DEFAULT (''),
	[Seal2] [varchar](15) NOT NULL DEFAULT (''),
	[ContainerSeqNbr] [int] NOT NULL DEFAULT ((0)),
	[EquipmentID] [varchar](15) NOT NULL DEFAULT (''),
	[EquipmentType] [varchar](15) NOT NULL DEFAULT (''),
	[WeightUOM] [char](4) NOT NULL DEFAULT ('LBS'),
	[TotalWeightShipped] [float] NOT NULL DEFAULT ((0)),
	[TotalUnitsShipped] [int] NOT NULL DEFAULT ((0)),
	[TotalPalletsShipped] [int] NOT NULL DEFAULT ((0)),
	[TotalChepPalletsShipped] [int] NOT NULL DEFAULT ((0)),
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
	[OriginalMeasType] [varchar](10) NOT NULL DEFAULT ('STANDARD'),
	[ShipPackagingCode] [varchar](5) NOT NULL DEFAULT (''),
	[ShipLadingQty] [int] NOT NULL DEFAULT ((0)),
	[ShipWeight] [float] NOT NULL DEFAULT ((0)),
	[ShipWeightUOM] [varchar](3) NOT NULL DEFAULT ('LB'),
	[OrderPackagingCode] [varchar](3) NOT NULL DEFAULT ('PL'),
	[OrderLadingQty] [int] NOT NULL DEFAULT ((0)),
	[OrderWeight] [float] NOT NULL DEFAULT ((0)),
	[OrderWeightUOM] [varchar](3) NOT NULL DEFAULT ('LB'),
	[ShipFromID] [varchar](15) NOT NULL DEFAULT (''),
	[ActualFreightCharge] [float] NOT NULL DEFAULT ((0)),
	[DiscountedFreightCharge] [float] NOT NULL DEFAULT ((0)),
	[ASNnbr] [varchar](15) NOT NULL DEFAULT (''),
	[ShipmentID] [varchar](30) NOT NULL DEFAULT (''),
	[ActionCode] [char](1) NOT NULL DEFAULT ('A'),
	[VendorID] [varchar](15) NOT NULL DEFAULT (''),
	[ASNdirection] [varchar](3) NOT NULL DEFAULT ('OUT'),
	[ASNfacilityNbr] [varchar](2) NOT NULL DEFAULT (''),
	[ProNbr] [varchar](30) NOT NULL DEFAULT (''),
	[BuyerRefNbr] [varchar](20) NOT NULL DEFAULT (''),
	[OutBoundCarrierCode] [varchar](20) NOT NULL DEFAULT (''),
	[Status] [varchar](10) NOT NULL DEFAULT ('NEW'),
 CONSTRAINT [PK_IDASNSHIPHEADER_NEW] PRIMARY KEY CLUSTERED 
(
	[IDInterfaceShipmentConfirmationHeader] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
