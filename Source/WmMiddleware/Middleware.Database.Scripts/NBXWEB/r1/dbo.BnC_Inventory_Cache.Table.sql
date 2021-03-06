USE [NBXWEB]
GO
/****** Object:  Table [dbo].[BnC_Inventory_Cache]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BnC_Inventory_Cache](
	[sku] [varchar](15) NOT NULL,
	[AvailQty] [int] NULL,
	[OWNER] [varchar](10) NULL,
	[NBWE] [numeric](15, 0) NULL,
	[JNBO] [numeric](15, 0) NULL,
 CONSTRAINT [PK_BnC_Inventory_Cache] PRIMARY KEY CLUSTERED 
(
	[sku] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
