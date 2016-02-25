USE [WMTransactions]
GO
/****** Object:  Table [dbo].[InventorySyncProcessing]    Script Date: 2/25/2016 1:50:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventorySyncProcessing](
	[InventorySyncProcessingId] [int] IDENTITY(1,1) NOT NULL,
	[TransactionNumber] [nvarchar](9) NOT NULL,
	[ReceivedDate] [datetime] NULL,
	[ProcessedDate] [datetime] NULL,
 CONSTRAINT [PK_InventorySyncProcessing] PRIMARY KEY CLUSTERED 
(
	[InventorySyncProcessingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
