USE [NBXWEB]
GO
/****** Object:  Table [dbo].[Kiosk_OrderLineItems]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Kiosk_OrderLineItems](
	[auto_id] [int] IDENTITY(1,1) NOT NULL,
	[company] [varchar](10) NOT NULL,
	[nb_design_id] [varchar](50) NOT NULL,
	[order_number] [varchar](15) NOT NULL,
	[item_number] [float] NOT NULL,
	[item_sku] [varchar](30) NOT NULL,
	[item_descrip] [varchar](100) NOT NULL,
	[qty] [int] NOT NULL,
	[unit_of_measure] [varchar](8) NOT NULL,
	[each_price] [float] NOT NULL,
	[item_discount] [float] NOT NULL,
	[ext_price] [float] NOT NULL,
	[item_comments] [varchar](500) NOT NULL,
	[inventory_type] [varchar](10) NOT NULL,
	[return_to] [varchar](20) NOT NULL,
	[ship_date] [smalldatetime] NOT NULL,
	[Ledger_status] [varchar](10) NOT NULL CONSTRAINT [DF_Kiosk_OrderLineItems_LedgerStatusa]  DEFAULT (''),
	[discount_category] [varchar](20) NULL,
	[discount_id] [varchar](20) NULL,
	[DIS_row_downloaded] [int] NOT NULL CONSTRAINT [DF_Kiosk_OrderLineItems_DIS_row_downloadeda]  DEFAULT ((0)),
	[DIS_when_downloaded] [smalldatetime] NOT NULL CONSTRAINT [DF_Kiosk_OrderLineItems_DIS_when_downloadeda]  DEFAULT (getdate()),
	[DIS_readyfor_download] [bit] NOT NULL CONSTRAINT [DF_Kiosk_OrderLineItems_DIS_readyfor_downloada]  DEFAULT ((0)),
	[WarehouseStatus] [varchar](5) NOT NULL CONSTRAINT [DF_Kiosk_OrderLineItems_WarehouseStatus]  DEFAULT ('NEW'),
	[CZ01] [nvarchar](50) NULL,
	[CZ02] [nvarchar](50) NULL,
	[CZ03] [nvarchar](50) NULL,
	[CZ04] [nvarchar](50) NULL,
	[CZ05] [nvarchar](50) NULL,
	[CZ06] [nvarchar](50) NULL,
	[CZ07] [nvarchar](50) NULL,
	[CZ08] [nvarchar](50) NULL,
	[CZ09] [nvarchar](50) NULL,
	[CZ10] [nvarchar](50) NULL,
	[CZ11] [nvarchar](50) NULL,
	[CZ12] [nvarchar](50) NULL,
	[CZ13] [nvarchar](50) NULL,
	[CZ14] [nvarchar](50) NULL,
	[CZ15] [nvarchar](50) NULL,
	[CZ16] [nvarchar](50) NULL,
	[CZ17] [nvarchar](50) NULL,
	[CZ18] [nvarchar](50) NULL,
	[CZ19] [nvarchar](50) NULL,
	[CZ20] [nvarchar](50) NULL,
	[CZ21] [nvarchar](50) NULL,
	[CZ22] [nvarchar](50) NULL,
	[CZU1] [nvarchar](50) NULL,
 CONSTRAINT [PK_Kiosk_OrderLineItems] PRIMARY KEY CLUSTERED 
(
	[auto_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
