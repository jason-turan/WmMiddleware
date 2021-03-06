USE [WarehouseManagement]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Environment](
	[EnvironmentId] [int] NULL,
	[EnvironmentDescription] [varchar](5) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Environment] ([EnvironmentId], [EnvironmentDescription]) VALUES (1, N'DEV')
INSERT [dbo].[Environment] ([EnvironmentId], [EnvironmentDescription]) VALUES (2, N'QA')
INSERT [dbo].[Environment] ([EnvironmentId], [EnvironmentDescription]) VALUES (0, N'PROD')
ALTER TABLE [dbo].[Environment] ADD UNIQUE NONCLUSTERED 
(
	[EnvironmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
