USE [NBXWEB]
GO
/****** Object:  Table [dbo].[NBWE_Inventory_Cache]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NBWE_Inventory_Cache](
	[Description] [varchar](101) NULL,
	[Store_Status] [varchar](11) NULL,
	[Vendor] [varchar](15) NULL,
	[Class] [varchar](11) NULL,
	[Gender] [varchar](11) NULL,
	[SKU] [varchar](31) NOT NULL,
	[Style] [varchar](15) NULL,
	[Size] [varchar](11) NULL,
	[Attr] [varchar](11) NULL,
	[Standard_Cost] [numeric](19, 5) NULL,
	[Current_Cost] [numeric](19, 5) NULL,
	[GP_Avg_On_Hand_Cost] [numeric](38, 6) NOT NULL,
	[Retail_Price] [numeric](19, 5) NULL,
	[Category] [varchar](11) NULL,
	[Subcategory] [varchar](11) NULL,
	[GP_On_Hand_Qty] [int] NULL,
	[GP_Available_Qty] [int] NULL,
	[JNBO_GP_Available_Qty] [int] NULL,
	[On_Dock] [int] NOT NULL,
	[Cadre_Qty] [int] NOT NULL,
	[GP_Received_Qty] [int] NULL,
	[Quantity] [int] NULL,
	[Min_Qty] [int] NULL,
	[Max_Qty] [int] NULL,
	[Brand] [varchar](65) NULL,
	[Intro_Date] [datetime] NULL,
	[Phase_out_Date] [datetime] NULL,
	[On_Site_Date] [datetime] NULL,
	[Web_Closeout] [varchar](65) NULL,
	[Pink_Ribbon] [varchar](65) NULL,
	[Made_in_USA] [varchar](65) NULL,
	[Girls_on_the_Run] [varchar](65) NULL,
	[Promo] [varchar](65) NULL,
	[Corp_Closeout] [varchar](65) NULL,
	[NBEE] [varchar](65) NULL,
	[Short_sleeve] [varchar](65) NULL,
	[Long_sleeve] [varchar](65) NULL,
	[Sleeveless] [varchar](65) NULL,
	[Pants] [varchar](65) NULL,
	[Tights] [varchar](65) NULL,
	[Capri] [varchar](65) NULL,
	[Brief] [varchar](65) NULL,
	[Bra_Crop] [varchar](65) NULL,
	[Bra_Top] [varchar](65) NULL,
	[Hooded] [varchar](65) NULL,
	[Shoe_Last] [varchar](65) NULL,
	[Shoe_Color] [varchar](65) NULL,
	[Velcro] [varchar](65) NULL,
	[Futures_Only] [varchar](65) NULL,
	[InTransit] [int] NULL,
	[CacheDate] [datetime] NULL,
 CONSTRAINT [PK_NBWE_Inventory_Cache2] PRIMARY KEY CLUSTERED 
(
	[SKU] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
