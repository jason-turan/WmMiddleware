USE [WMTransactions]
GO

/****** Object:  Table [dbo].[InventoryPixProcessing]    Script Date: 3/22/2016 3:06:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[InventoryPixProcessing](
	[ProcessingId] [int] IDENTITY(1,1) NOT NULL,
	[ManhattanPerpetualInventoryTransferId] [int] NOT NULL,
	[ProcessedDate] [datetime] NOT NULL,
	[ManhattanDateTime] [datetime] NULL,
 CONSTRAINT [PK_InventoryPixProcessing] PRIMARY KEY CLUSTERED 
(
	[ProcessingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


