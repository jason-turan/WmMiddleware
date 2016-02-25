USE [WMTransactions]
GO
/****** Object:  Table [dbo].[PickTicketConfirmationOrderProcessing]    Script Date: 2/25/2016 1:50:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PickTicketConfirmationOrderProcessing](
	[ControlNumber] [varchar](15) NULL,
	[ProcessedDate] [datetime] NULL,
	[OrderNumber] [varchar](15) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
