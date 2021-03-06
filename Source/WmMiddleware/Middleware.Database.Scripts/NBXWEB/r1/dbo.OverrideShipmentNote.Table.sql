USE [NBXWEB]
GO
/****** Object:  Table [dbo].[OverrideShipmentNote]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OverrideShipmentNote](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Style] [nvarchar](50) NULL,
	[UPC] [nvarchar](50) NOT NULL,
	[OverrideMessage] [nvarchar](50) NULL,
	[DateAdded] [datetime] NULL CONSTRAINT [DF_OverrideShipmentNote_DateAdded]  DEFAULT (getdate()),
 CONSTRAINT [PK_OverrideShipmentNote] PRIMARY KEY CLUSTERED 
(
	[UPC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
