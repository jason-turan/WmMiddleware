USE [NBXWEB]
GO
/****** Object:  Table [dbo].[POReceiptDetail_LineItem]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[POReceiptDetail_LineItem](
	[POReceiptDetailID] [int] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[LineNumber] [varchar](22) NULL,
	[UPC] [varchar](22) NULL,
	[UOM] [varchar](22) NULL,
	[VendorStyleNumber] [varchar](22) NULL,
	[QuantityInvoiced] [varchar](22) NULL,
	[UnitPrice] [money] NULL,
	[idprhi] [int] NULL,
	[DateAdded] [datetime] NULL CONSTRAINT [DF_POReceiptDetail_LineItem_DateAdded]  DEFAULT (getdate()),
 CONSTRAINT [PK_POReceiptDetail_LineItem] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
