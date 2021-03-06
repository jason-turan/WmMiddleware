USE [NBXWEB]
GO
/****** Object:  Table [dbo].[ROW_Return]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ROW_Return](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[Company] [varchar](10) NULL,
	[Order_Number] [varchar](15) NOT NULL,
	[SKU] [varchar](15) NULL,
	[Style] [varchar](25) NULL,
	[Size] [varchar](10) NULL,
	[Width] [varchar](10) NULL,
	[Condition] [varchar](15) NULL,
	[Reason] [varchar](50) NULL,
	[Exchange] [bit] NULL,
	[Note] [text] NULL,
	[Timestamp] [datetime] NULL CONSTRAINT [DF__ROW_Retur__Times__5CF6C6BC]  DEFAULT (getdate()),
	[Status] [varchar](10) NULL CONSTRAINT [DF__ROW_Retur__Statu__5DEAEAF5]  DEFAULT ('NEW'),
	[UserId] [varchar](15) NULL,
	[UserName] [varchar](50) NULL,
	[ReturnLocation] [varchar](50) NULL,
 CONSTRAINT [PK_ROW_Return] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
