USE [WarehouseManagement]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransferControlFileType](
	[TransferControlFileTypeId] [int] IDENTITY(1,1) NOT NULL,
	[FilePrefix] [nvarchar](10) NOT NULL,
	[FileDescription] [nvarchar](100) NOT NULL,
	[JobId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[TransferControlFileTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[TransferControlFileType] ON 

INSERT [dbo].[TransferControlFileType] ([TransferControlFileTypeId], [FilePrefix], [FileDescription], [JobId]) VALUES (12, N'O1', N'Shipment Header', 16)
INSERT [dbo].[TransferControlFileType] ([TransferControlFileTypeId], [FilePrefix], [FileDescription], [JobId]) VALUES (13, N'O2', N'Shipment Detail', 16)
INSERT [dbo].[TransferControlFileType] ([TransferControlFileTypeId], [FilePrefix], [FileDescription], [JobId]) VALUES (14, N'O3', N'Carton Header', 16)
INSERT [dbo].[TransferControlFileType] ([TransferControlFileTypeId], [FilePrefix], [FileDescription], [JobId]) VALUES (15, N'O4', N'Carton Detail', 16)
INSERT [dbo].[TransferControlFileType] ([TransferControlFileTypeId], [FilePrefix], [FileDescription], [JobId]) VALUES (16, N'I1', N'Pick Header', 13)
INSERT [dbo].[TransferControlFileType] ([TransferControlFileTypeId], [FilePrefix], [FileDescription], [JobId]) VALUES (17, N'I2', N'Pick Detail', 13)
INSERT [dbo].[TransferControlFileType] ([TransferControlFileTypeId], [FilePrefix], [FileDescription], [JobId]) VALUES (18, N'I3', N'Pick Special Instructions', 13)
INSERT [dbo].[TransferControlFileType] ([TransferControlFileTypeId], [FilePrefix], [FileDescription], [JobId]) VALUES (19, N'I8', N'ProductReceivingHeader', 14)
INSERT [dbo].[TransferControlFileType] ([TransferControlFileTypeId], [FilePrefix], [FileDescription], [JobId]) VALUES (20, N'I9', N'ProductReceivingPoDetail', 14)
INSERT [dbo].[TransferControlFileType] ([TransferControlFileTypeId], [FilePrefix], [FileDescription], [JobId]) VALUES (21, N'IB', N'ProductReceivingAsnDetail', 14)
INSERT [dbo].[TransferControlFileType] ([TransferControlFileTypeId], [FilePrefix], [FileDescription], [JobId]) VALUES (22, N'I5', N'Product Updating Product Path', 17)
INSERT [dbo].[TransferControlFileType] ([TransferControlFileTypeId], [FilePrefix], [FileDescription], [JobId]) VALUES (23, N'PX', N'Perpetual Inventory Transfer', 18)
INSERT [dbo].[TransferControlFileType] ([TransferControlFileTypeId], [FilePrefix], [FileDescription], [JobId]) VALUES (25, N'IS', N'Inventory Sync', 19)
INSERT [dbo].[TransferControlFileType] ([TransferControlFileTypeId], [FilePrefix], [FileDescription], [JobId]) VALUES (26, N'I1', N'Pick Header', 35)
INSERT [dbo].[TransferControlFileType] ([TransferControlFileTypeId], [FilePrefix], [FileDescription], [JobId]) VALUES (27, N'I2', N'Pick Detail', 35)
INSERT [dbo].[TransferControlFileType] ([TransferControlFileTypeId], [FilePrefix], [FileDescription], [JobId]) VALUES (28, N'I3', N'Pick Special Instructions', 35)
SET IDENTITY_INSERT [dbo].[TransferControlFileType] OFF
ALTER TABLE [dbo].[TransferControlFileType]  WITH CHECK ADD  CONSTRAINT [FK__TransferC__JobId__662B2B3B] FOREIGN KEY([JobId])
REFERENCES [dbo].[Job] ([JobId])
GO
ALTER TABLE [dbo].[TransferControlFileType] CHECK CONSTRAINT [FK__TransferC__JobId__662B2B3B]
GO
