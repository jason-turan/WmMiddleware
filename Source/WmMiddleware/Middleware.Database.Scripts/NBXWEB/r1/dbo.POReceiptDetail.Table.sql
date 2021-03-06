USE [NBXWEB]
GO
/****** Object:  Table [dbo].[POReceiptDetail]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[POReceiptDetail](
	[POReceiptHeaderID] [int] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceNumber] [varchar](22) NULL,
	[InoviceIssueDate] [varchar](10) NULL,
	[PurchaserPODate] [varchar](10) NULL,
	[PONumber] [varchar](22) NULL,
	[VendorOrderNumber] [varchar](30) NULL,
	[termsnetdays] [varchar](30) NULL,
	[termsnetdate] [varchar](10) NULL,
	[TermsDiscountDueDate] [varchar](10) NULL,
	[TermsDiscountDaysDue] [varchar](30) NULL,
	[TermsTypeCode] [varchar](2) NULL,
	[shippeddatetimereference] [varchar](10) NULL,
	[TotalMonetaryValue] [money] NULL,
	[CarrierDetailRouting] [varchar](35) NULL,
	[CarrierDetailReferenceID] [varchar](30) NULL,
	[ShipmentWeight] [varchar](10) NULL,
	[NumberUnitsShipped] [varchar](10) NULL,
	[NumberLineItems] [varchar](6) NULL,
	[IntegrationStatus] [nvarchar](10) NULL CONSTRAINT [DF_POReceiptDetail_IntegrationStatus]  DEFAULT ('NEW'),
	[IntegrationMessage] [nvarchar](500) NULL,
	[IntegrationDT] [datetime] NULL,
	[IntegrationBatchID] [nvarchar](50) NULL,
	[sum_po_unitcost] [money] NULL CONSTRAINT [DF_POReceiptDetail_po_sum_unitcost]  DEFAULT ((0)),
	[sum_li_unitcost] [money] NULL,
	[ShipToSuffix] [varchar](50) NULL,
	[WeightUOM] [varchar](50) NULL,
	[ShipmentBox] [varchar](50) NULL,
	[DateAdded] [datetime] NULL CONSTRAINT [DF_POReceiptDetail_DateAdded]  DEFAULT (getdate()),
 CONSTRAINT [PK_POReceiptDetail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
