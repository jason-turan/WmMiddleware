USE [NBXWEB]
GO
/****** Object:  Table [dbo].[GP_line_items]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GP_line_items](
	[auto_id] [int] IDENTITY(1,1) NOT NULL,
	[company] [varchar](10) NOT NULL,
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
	[GP_status] [varchar](10) NOT NULL CONSTRAINT [DF_GP_line_items_GP_statusa]  DEFAULT (''),
	[discount_category] [varchar](20) NULL,
	[discount_id] [varchar](20) NULL,
	[DIS_row_downloaded] [int] NOT NULL CONSTRAINT [DF_GP_line_items_DIS_row_downloadeda]  DEFAULT ((0)),
	[DIS_when_downloaded] [smalldatetime] NOT NULL CONSTRAINT [DF_GP_line_items_DIS_when_downloadeda]  DEFAULT (getdate()),
	[DIS_readyfor_download] [bit] NOT NULL CONSTRAINT [DF_GP_line_items_DIS_readyfor_downloada]  DEFAULT ((0)),
	[CadreStatus] [varchar](10) NOT NULL CONSTRAINT [DF_GP_line_items_CadreStatusa]  DEFAULT ('NEW'),
 CONSTRAINT [PK_GP_line_itemsa] PRIMARY KEY CLUSTERED 
(
	[auto_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
