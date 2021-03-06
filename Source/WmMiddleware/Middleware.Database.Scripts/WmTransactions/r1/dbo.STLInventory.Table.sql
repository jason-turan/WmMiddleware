USE [WMTransactions]
GO

/****** Object:  Table [dbo].[STLInventory]    Script Date: 3/22/2016 3:06:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[STLInventory](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[UPC] [char](13) NULL,
	[Style] [varchar](50) NULL,
	[Size] [varchar](50) NULL,
	[Attribute] [varchar](50) NULL,
	[Quantity] [int] NULL,
	[ManhattanInventorySyncTransactionNumber] [nvarchar](9) NULL,
	[InventoryDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_STL_Inventory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


