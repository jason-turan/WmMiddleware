USE [WarehouseManagement]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SpecialInstructionSKU](
	[SpecialInstructionId] [int] NOT NULL,
	[SKU] [varchar](31) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[SpecialInstructionSKU] ([SpecialInstructionId], [SKU]) VALUES (6, N'8')
INSERT [dbo].[SpecialInstructionSKU] ([SpecialInstructionId], [SKU]) VALUES (6, N'13')
INSERT [dbo].[SpecialInstructionSKU] ([SpecialInstructionId], [SKU]) VALUES (6, N'019237781011')
INSERT [dbo].[SpecialInstructionSKU] ([SpecialInstructionId], [SKU]) VALUES (6, N'019327111856')
ALTER TABLE [dbo].[SpecialInstructionSKU]  WITH CHECK ADD FOREIGN KEY([SpecialInstructionId])
REFERENCES [dbo].[SpecialInstruction] ([Id])
GO
