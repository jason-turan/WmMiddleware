USE [WMTransactions]
GO
/****** Object:  Table [dbo].[KioskOrderDetailExport]    Script Date: 2/25/2016 1:50:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KioskOrderDetailExport](
	[KioskOrderDetailExportId] [int] IDENTITY(1,1) NOT NULL,
	[order_number] [varchar](18) NOT NULL,
	[internal_order_number] [int] NULL,
	[item_number] [float] NOT NULL,
	[item_status] [nvarchar](4) NOT NULL,
	[style_number] [nvarchar](16) NOT NULL,
	[prod_size] [nvarchar](4) NOT NULL,
	[attribute] [nvarchar](8) NULL,
	[qty] [int] NOT NULL,
	[is_discountable] [bit] NOT NULL,
	[our_price] [float] NOT NULL,
	[discount_type] [nvarchar](1) NULL,
	[discount_amount] [float] NOT NULL,
	[discount_string] [nvarchar](50) NULL,
	[taxable_amount] [float] NULL,
	[upc_number] [nvarchar](16) NULL,
	[isCloseout] [varchar](1) NOT NULL,
	[legal_entity] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[KioskOrderDetailExportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
