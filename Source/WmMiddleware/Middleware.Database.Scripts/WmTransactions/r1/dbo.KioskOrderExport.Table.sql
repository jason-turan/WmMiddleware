USE [WMTransactions]
GO
/****** Object:  Table [dbo].[KioskOrderExport]    Script Date: 2/25/2016 1:50:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[KioskOrderExport](
	[KioskOrderExportId] [int] IDENTITY(1,1) NOT NULL,
	[order_number] [varchar](18) NOT NULL,
	[internal_order_number] [int] NULL,
	[customerid] [varchar](50) NOT NULL,
	[date_ordered] [smalldatetime] NOT NULL,
	[order_status] [nvarchar](4) NOT NULL,
	[coupon_type] [nvarchar](1) NULL,
	[coupon_amount] [float] NOT NULL,
	[coupon_code] [nvarchar](32) NULL,
	[gift_amount] [float] NOT NULL,
	[gift_code] [nvarchar](32) NULL,
	[shipping_method] [nvarchar](16) NULL,
	[shipping_cost] [float] NOT NULL,
	[original_shipping_cost] [float] NULL,
	[sales_tax] [float] NOT NULL,
	[sales_tax_rate] [float] NOT NULL,
	[sub_total] [float] NOT NULL,
	[order_total] [float] NOT NULL,
	[bill_first_name] [varchar](100) NULL,
	[bill_last_name] [varchar](100) NULL,
	[bill_email] [varchar](50) NULL,
	[bill_telephone] [varchar](15) NULL,
	[bill_address] [varchar](100) NULL,
	[bill_address2] [varchar](100) NULL,
	[bill_city] [varchar](100) NULL,
	[bill_state] [varchar](2) NULL,
	[bill_zip] [varchar](10) NULL,
	[bill_country] [varchar](30) NOT NULL,
	[ship_first_name] [varchar](100) NULL,
	[ship_last_name] [varchar](100) NULL,
	[ship_telephone] [varchar](15) NULL,
	[ship_address] [varchar](100) NULL,
	[ship_address2] [varchar](100) NULL,
	[ship_city] [varchar](100) NULL,
	[ship_state] [varchar](2) NULL,
	[ship_zip] [varchar](10) NULL,
	[ship_country] [varchar](30) NOT NULL,
	[payment_type] [nvarchar](16) NULL,
	[order_source] [nvarchar](50) NOT NULL,
	[is_row_exchange] [bit] NULL,
	[auth_number] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[KioskOrderExportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
