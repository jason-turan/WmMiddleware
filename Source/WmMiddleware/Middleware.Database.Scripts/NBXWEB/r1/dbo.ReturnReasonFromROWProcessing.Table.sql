USE [NBXWEB]
GO
/****** Object:  Table [dbo].[ReturnReasonFromROWProcessing]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReturnReasonFromROWProcessing](
	[ProcessingId] [int] IDENTITY(1,1) NOT NULL,
	[rowId] [int] NULL,
	[ProcessedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProcessingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
