USE [WMTransactions]
GO
/****** Object:  Table [dbo].[ManhattanShipmentLineItemCancellationProcessing]    Script Date: 2/25/2016 1:50:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManhattanShipmentLineItemCancellationProcessing](
	[ProcessingId] [int] IDENTITY(1,1) NOT NULL,
	[ManhattanShipmentLineItemId] [int] NULL,
	[ProcessedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProcessingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ManhattanShipmentLineItemCancellationProcessing]  WITH CHECK ADD FOREIGN KEY([ManhattanShipmentLineItemId])
REFERENCES [dbo].[ManhattanShipmentLineItem] ([ManhattanShipmentLineItemId])
GO
