USE [NBXWEB]
GO
/****** Object:  Table [dbo].[Kiosk_Orderheader]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Kiosk_Orderheader](
	[auto_id] [int] IDENTITY(1,1) NOT NULL,
	[company] [varchar](10) NOT NULL,
	[nb_design_id] [varchar](50) NOT NULL,
	[order_number] [varchar](15) NOT NULL,
	[order_date] [smalldatetime] NOT NULL,
	[date_downloaded] [smalldatetime] NOT NULL CONSTRAINT [DF_Kiosk_header_date_downloadeda]  DEFAULT (getdate()),
	[customer_number] [varchar](10) NOT NULL,
	[order_priority] [varchar](4) NOT NULL CONSTRAINT [DF_Kiosk_header_order_prioritya]  DEFAULT ('ME'),
	[bill_name] [varchar](64) NOT NULL,
	[bill_address] [varchar](60) NOT NULL,
	[bill_address2] [varchar](60) NOT NULL,
	[bill_address3] [varchar](60) NOT NULL,
	[bill_city] [varchar](35) NOT NULL,
	[bill_state] [varchar](29) NOT NULL,
	[bill_zip] [varchar](10) NOT NULL,
	[bill_country] [varchar](60) NOT NULL,
	[bill_phone] [varchar](14) NOT NULL,
	[ship_name] [varchar](64) NOT NULL,
	[ship_address] [varchar](60) NOT NULL,
	[ship_address2] [varchar](60) NOT NULL,
	[ship_address3] [varchar](60) NOT NULL,
	[ship_city] [varchar](35) NOT NULL,
	[ship_state] [varchar](29) NOT NULL,
	[ship_zip] [varchar](10) NOT NULL,
	[ship_country] [varchar](60) NOT NULL,
	[ship_phone] [varchar](14) NOT NULL,
	[email_address] [varchar](60) NOT NULL,
	[trans_type] [varchar](6) NOT NULL,
	[shipping_method] [varchar](20) NOT NULL,
	[sub_total] [float] NOT NULL,
	[discount] [float] NOT NULL,
	[freight] [float] NOT NULL,
	[misc_handling] [float] NOT NULL,
	[tax_amount] [float] NOT NULL,
	[total] [float] NOT NULL,
	[original_order] [int] NOT NULL CONSTRAINT [DF_Kiosk_header_original_ordera]  DEFAULT ((0)),
	[payment_only] [varchar](3) NOT NULL CONSTRAINT [DF_Kiosk_header_payment_onlya]  DEFAULT ('no'),
	[Ledger_status] [varchar](10) NOT NULL CONSTRAINT [DF_Kiosk_header_GP_statusa]  DEFAULT (''),
	[shipping_note] [varchar](90) NULL,
	[gift_message_1] [varchar](100) NULL,
	[gift_message_2] [varchar](100) NULL,
	[order_source] [varchar](50) NULL,
	[payment_applied] [varchar](50) NOT NULL CONSTRAINT [DF_Kiosk_header_payment_applieda]  DEFAULT ('no'),
	[discount_category] [varchar](20) NULL,
	[discount_id] [varchar](20) NULL,
	[DIS_when_downloaded] [smalldatetime] NOT NULL CONSTRAINT [DF_Kiosk_header_DIS_when_downloadeda]  DEFAULT (getdate()),
	[DIS_readyfor_download] [bit] NOT NULL CONSTRAINT [DF_Kiosk_header_DIS_readyfor_downloada]  DEFAULT ((0)),
	[DIS_row_downloaded] [int] NOT NULL CONSTRAINT [DF_Kiosk_header_DIS_row_downloadeda]  DEFAULT ((0)),
	[WarehouseStatus] [varchar](5) NOT NULL CONSTRAINT [DF_Kiosk_header_WarehouseStatus]  DEFAULT ('NEW'),
 CONSTRAINT [PK_Kiosk_Orderheader] PRIMARY KEY CLUSTERED 
(
	[auto_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
