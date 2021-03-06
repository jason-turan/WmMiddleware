USE [WarehouseManagement]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CarrierServiceCodes](
	[Code] [varchar](10) NOT NULL,
	[Description] [varchar](100) NULL,
	[OmsShipMethod] [varchar](50) NOT NULL,
	[IsThirdPartyBilling] [bit] NULL,
 CONSTRAINT [PK_CarrierServiceCodes] PRIMARY KEY CLUSTERED 
(
	[Code] ASC,
	[OmsShipMethod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[CarrierServiceCodes] ([Code], [Description], [OmsShipMethod], [IsThirdPartyBilling]) VALUES (N'1', N'UPS Ground', N'Ground', 0)
INSERT [dbo].[CarrierServiceCodes] ([Code], [Description], [OmsShipMethod], [IsThirdPartyBilling]) VALUES (N'1  R', N'UPS Ground (residential)', N'NA', 0)
INSERT [dbo].[CarrierServiceCodes] ([Code], [Description], [OmsShipMethod], [IsThirdPartyBilling]) VALUES (N'1M', N'UPS 2nd Day Air 3P', N'2nd Day Air', 1)
INSERT [dbo].[CarrierServiceCodes] ([Code], [Description], [OmsShipMethod], [IsThirdPartyBilling]) VALUES (N'1P', N'UPS Collect 3rd Party', N'NA', 1)
INSERT [dbo].[CarrierServiceCodes] ([Code], [Description], [OmsShipMethod], [IsThirdPartyBilling]) VALUES (N'1T', N'UPS Next Day Air Saver PP&A', N'Next Day Air Saver', 0)
INSERT [dbo].[CarrierServiceCodes] ([Code], [Description], [OmsShipMethod], [IsThirdPartyBilling]) VALUES (N'1V', N'UPS Next Day Air Saver 3P', N'Next Day Air Saver', 1)
INSERT [dbo].[CarrierServiceCodes] ([Code], [Description], [OmsShipMethod], [IsThirdPartyBilling]) VALUES (N'24', N'UPS Red Label', N'Next Day Air', 0)
INSERT [dbo].[CarrierServiceCodes] ([Code], [Description], [OmsShipMethod], [IsThirdPartyBilling]) VALUES (N'24 R', N'UPS Next Day Air Residential', N'NA', 0)
INSERT [dbo].[CarrierServiceCodes] ([Code], [Description], [OmsShipMethod], [IsThirdPartyBilling]) VALUES (N'2P', N'UPS Next Day Air 3P', N'UPSNDA', 1)
INSERT [dbo].[CarrierServiceCodes] ([Code], [Description], [OmsShipMethod], [IsThirdPartyBilling]) VALUES (N'2Z', N'UPS SurePost 1 lb or Greater', N'UPSSPPS', 0)
INSERT [dbo].[CarrierServiceCodes] ([Code], [Description], [OmsShipMethod], [IsThirdPartyBilling]) VALUES (N'41', N'UPS Blue Label', N'2nd Day Air', 0)
INSERT [dbo].[CarrierServiceCodes] ([Code], [Description], [OmsShipMethod], [IsThirdPartyBilling]) VALUES (N'41 R', N'UPS Second Day Air Residential', N'NA', 0)
INSERT [dbo].[CarrierServiceCodes] ([Code], [Description], [OmsShipMethod], [IsThirdPartyBilling]) VALUES (N'49', N'USPS', N'USPS', 0)
INSERT [dbo].[CarrierServiceCodes] ([Code], [Description], [OmsShipMethod], [IsThirdPartyBilling]) VALUES (N'49', N'Priority Mail', N'USPSPRI', 0)
INSERT [dbo].[CarrierServiceCodes] ([Code], [Description], [OmsShipMethod], [IsThirdPartyBilling]) VALUES (N'72', N'Red Label/Saturday Delivery', N'UPSNDA', 0)
INSERT [dbo].[CarrierServiceCodes] ([Code], [Description], [OmsShipMethod], [IsThirdPartyBilling]) VALUES (N'90', N'International (Ocean  )', N'INTL', 0)
INSERT [dbo].[CarrierServiceCodes] ([Code], [Description], [OmsShipMethod], [IsThirdPartyBilling]) VALUES (N'CR', N'Call for Routing', N'NA', 0)
INSERT [dbo].[CarrierServiceCodes] ([Code], [Description], [OmsShipMethod], [IsThirdPartyBilling]) VALUES (N'PU', N'Manual Pick UP', N'manual', 0)
