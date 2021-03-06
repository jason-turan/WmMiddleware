USE [WarehouseManagement]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SpecialInstruction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[SiteLevel] [bit] NOT NULL,
	[Gender] [varchar](11) NULL,
	[StartDate] [smalldatetime] NULL,
	[EndDate] [smalldatetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[SpecialInstruction] ON 

INSERT [dbo].[SpecialInstruction] ([Id], [Description], [SiteLevel], [Gender], [StartDate], [EndDate]) VALUES (1, N'Permanent site-level', 1, NULL, NULL, NULL)
INSERT [dbo].[SpecialInstruction] ([Id], [Description], [SiteLevel], [Gender], [StartDate], [EndDate]) VALUES (2, N'Expired', 1, NULL, NULL, CAST(N'2015-12-01 00:00:00' AS SmallDateTime))
INSERT [dbo].[SpecialInstruction] ([Id], [Description], [SiteLevel], [Gender], [StartDate], [EndDate]) VALUES (3, N'Not started', 1, NULL, CAST(N'2017-01-01 00:00:00' AS SmallDateTime), NULL)
INSERT [dbo].[SpecialInstruction] ([Id], [Description], [SiteLevel], [Gender], [StartDate], [EndDate]) VALUES (4, N'Male insert', 0, N'MEN', NULL, NULL)
INSERT [dbo].[SpecialInstruction] ([Id], [Description], [SiteLevel], [Gender], [StartDate], [EndDate]) VALUES (5, N'Female', 0, N'WOMEN', NULL, NULL)
INSERT [dbo].[SpecialInstruction] ([Id], [Description], [SiteLevel], [Gender], [StartDate], [EndDate]) VALUES (6, N'Product-level', 0, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[SpecialInstruction] OFF
