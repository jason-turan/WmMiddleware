USE [NBXWEB]
GO
/****** Object:  Table [dbo].[ROW_Notes]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ROW_Notes](
	[id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Company] [varchar](10) NOT NULL,
	[Order_Number] [varchar](15) NOT NULL,
	[Note] [text] NULL,
	[Timestamp] [datetime] NULL,
	[SKU] [varchar](15) NULL,
	[Style] [varchar](25) NULL,
	[Size] [varchar](10) NULL,
	[Width] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ROW_Notes] ADD  DEFAULT (newid()) FOR [id]
GO
ALTER TABLE [dbo].[ROW_Notes] ADD  DEFAULT (getdate()) FOR [Timestamp]
GO
