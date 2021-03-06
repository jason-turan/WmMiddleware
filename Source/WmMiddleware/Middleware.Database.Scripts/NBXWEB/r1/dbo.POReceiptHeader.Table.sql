USE [NBXWEB]
GO
/****** Object:  Table [dbo].[POReceiptHeader]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[POReceiptHeader](
	[SenderID] [varchar](25) NULL,
	[RecipientID] [varchar](25) NULL,
	[TransactionType] [varchar](25) NULL,
	[TransactionDate] [varchar](10) NULL,
	[TransactionTime] [varchar](10) NULL,
	[ControlNumber] [nvarchar](10) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UsageIndicator] [varchar](50) NULL,
	[ISAControlNumber] [varchar](50) NULL,
	[DateAdded] [datetime] NULL CONSTRAINT [DF_POReceiptHeader_DateAdded]  DEFAULT (getdate()),
 CONSTRAINT [PK_POReceiptHeader] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
