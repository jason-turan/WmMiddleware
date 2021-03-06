USE [WMTransactions]
GO
/****** Object:  Table [dbo].[KioskOrderExportProcessing]    Script Date: 2/25/2016 1:50:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KioskOrderExportProcessing](
	[ProcessingId] [int] IDENTITY(1,1) NOT NULL,
	[KioskOrderExportId] [int] NULL,
	[ProcessedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProcessingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[KioskOrderExportProcessing]  WITH CHECK ADD FOREIGN KEY([KioskOrderExportId])
REFERENCES [dbo].[KioskOrderExport] ([KioskOrderExportId])
GO
