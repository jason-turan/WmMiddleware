USE [WMTransactions]
GO
/****** Object:  Table [dbo].[ManhattanShipmentBncGlProcessing]    Script Date: 2/25/2016 1:50:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ManhattanShipmentBncGlProcessing](
	[PickticketControlNumber] [varchar](10) NULL,
	[BatchControlNumber] [varchar](10) NULL,
	[ProcessedDate] [datetime] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
