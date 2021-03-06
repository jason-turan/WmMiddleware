USE [WarehouseManagement]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job](
	[JobId] [int] IDENTITY(1,1) NOT NULL,
	[JobKey] [varchar](100) NOT NULL,
	[Schedule] [varchar](50) NOT NULL,
	[JobExecutable] [varchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastRunExecutionTime] [numeric](15, 5) NULL,
	[LastRunStatus] [varchar](100) NULL,
	[LastRunDateTime] [datetime] NULL,
	[NextRunDateTime] [datetime] NULL,
	[JobType] [nvarchar](50) NULL,
	[IsAlerted] [bit] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[JobId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Job] ON 

INSERT [dbo].[Job] ([JobId], [JobKey], [Schedule], [JobExecutable], [IsActive], [LastRunExecutionTime], [LastRunStatus], [LastRunDateTime], [NextRunDateTime], [JobType], [IsAlerted]) VALUES (13, N'Pick Job', N'10M', N'Middleware.Wm.Picking.Exe', 1, CAST(766.00000 AS Numeric(15, 5)), N'SUCCESS', CAST(N'2016-02-25 13:40:41.370' AS DateTime), CAST(N'2016-02-25 13:50:39.723' AS DateTime), N'ManhattanInbound', 0)
INSERT [dbo].[Job] ([JobId], [JobKey], [Schedule], [JobExecutable], [IsActive], [LastRunExecutionTime], [LastRunStatus], [LastRunDateTime], [NextRunDateTime], [JobType], [IsAlerted]) VALUES (14, N'Product Receiving Job', N'1H', N'Middleware.Wm.ProductReceiving.exe', 1, CAST(798.00000 AS Numeric(15, 5)), N'SUCCESS', CAST(N'2016-02-25 13:30:41.877' AS DateTime), CAST(N'2016-02-25 14:30:39.757' AS DateTime), N'ManhattanInbound', 0)
INSERT [dbo].[Job] ([JobId], [JobKey], [Schedule], [JobExecutable], [IsActive], [LastRunExecutionTime], [LastRunStatus], [LastRunDateTime], [NextRunDateTime], [JobType], [IsAlerted]) VALUES (15, N'Transfer Control Job', N'10M', N'Middleware.Wm.TransferControl.exe', 1, CAST(471.00000 AS Numeric(15, 5)), N'SUCCESS', CAST(N'2016-02-25 13:40:41.040' AS DateTime), CAST(N'2016-02-25 13:50:39.770' AS DateTime), N'TransferControl', 0)
INSERT [dbo].[Job] ([JobId], [JobKey], [Schedule], [JobExecutable], [IsActive], [LastRunExecutionTime], [LastRunStatus], [LastRunDateTime], [NextRunDateTime], [JobType], [IsAlerted]) VALUES (16, N'Shipment Job', N'5M', N'Middleware.Wm.Shipment.exe', 1, CAST(309.00000 AS Numeric(15, 5)), N'SUCCESS', CAST(N'2016-02-25 13:40:40.823' AS DateTime), CAST(N'2016-02-25 13:45:39.770' AS DateTime), N'Outbound', 0)
INSERT [dbo].[Job] ([JobId], [JobKey], [Schedule], [JobExecutable], [IsActive], [LastRunExecutionTime], [LastRunStatus], [LastRunDateTime], [NextRunDateTime], [JobType], [IsAlerted]) VALUES (17, N'Product Updating Job', N'4H', N'Middleware.Wm.ProductUpdating.exe', 1, CAST(19627.00000 AS Numeric(15, 5)), N'SUCCESS', CAST(N'2016-02-25 12:31:01.303' AS DateTime), CAST(N'2016-02-25 16:30:39.770' AS DateTime), N'ManhattanInbound', 0)
INSERT [dbo].[Job] ([JobId], [JobKey], [Schedule], [JobExecutable], [IsActive], [LastRunExecutionTime], [LastRunStatus], [LastRunDateTime], [NextRunDateTime], [JobType], [IsAlerted]) VALUES (18, N'Pix', N'4M', N'Middleware.Wm.Pix.exe', 1, CAST(162.00000 AS Numeric(15, 5)), N'SUCCESS', CAST(N'2016-02-25 13:38:40.417' AS DateTime), CAST(N'2016-02-25 13:42:39.770' AS DateTime), N'Outbound', 0)
INSERT [dbo].[Job] ([JobId], [JobKey], [Schedule], [JobExecutable], [IsActive], [LastRunExecutionTime], [LastRunStatus], [LastRunDateTime], [NextRunDateTime], [JobType], [IsAlerted]) VALUES (19, N'Inventory Sync', N'30M', N'Middleware.Wm.InventorySync.exe', 1, CAST(369.00000 AS Numeric(15, 5)), N'SUCCESS', CAST(N'2016-02-25 13:30:41.363' AS DateTime), CAST(N'2016-02-25 14:00:39.770' AS DateTime), N'Outbound', 0)
INSERT [dbo].[Job] ([JobId], [JobKey], [Schedule], [JobExecutable], [IsActive], [LastRunExecutionTime], [LastRunStatus], [LastRunDateTime], [NextRunDateTime], [JobType], [IsAlerted]) VALUES (20, N'Alerts', N'11M', N'Middleware.Alerts.exe', 1, CAST(217.00000 AS Numeric(15, 5)), N'SUCCESS', CAST(N'2016-02-25 13:36:40.560' AS DateTime), CAST(N'2016-02-25 13:47:39.770' AS DateTime), N'Admin', 0)
INSERT [dbo].[Job] ([JobId], [JobKey], [Schedule], [JobExecutable], [IsActive], [LastRunExecutionTime], [LastRunStatus], [LastRunDateTime], [NextRunDateTime], [JobType], [IsAlerted]) VALUES (24, N'Pix Return Job', N'15M', N'Middleware.Wm.PixReturn.exe', 1, CAST(454.00000 AS Numeric(15, 5)), N'SUCCESS', CAST(N'2016-02-25 13:30:41.877' AS DateTime), CAST(N'2016-02-25 13:45:39.770' AS DateTime), N'Processing', 0)
INSERT [dbo].[Job] ([JobId], [JobKey], [Schedule], [JobExecutable], [IsActive], [LastRunExecutionTime], [LastRunStatus], [LastRunDateTime], [NextRunDateTime], [JobType], [IsAlerted]) VALUES (30, N'Stl Inventory Sync', N'0 0 12 * * ?', N'Middleware.Wm.StlInventorySync.exe', 1, CAST(3161.00000 AS Numeric(15, 5)), N'SUCCESS', CAST(N'2016-02-25 12:00:04.600' AS DateTime), NULL, N'Processing', 0)
INSERT [dbo].[Job] ([JobId], [JobKey], [Schedule], [JobExecutable], [IsActive], [LastRunExecutionTime], [LastRunStatus], [LastRunDateTime], [NextRunDateTime], [JobType], [IsAlerted]) VALUES (31, N'Shipment Cancellation Email Job', N'2H', N'Middleware.Wm.ShipmentCancellationEmail.exe', 1, CAST(3124.00000 AS Numeric(15, 5)), N'SUCCESS', CAST(N'2016-02-25 13:21:56.573' AS DateTime), CAST(N'2016-02-25 14:30:39.850' AS DateTime), N'Processing', 0)
INSERT [dbo].[Job] ([JobId], [JobKey], [Schedule], [JobExecutable], [IsActive], [LastRunExecutionTime], [LastRunStatus], [LastRunDateTime], [NextRunDateTime], [JobType], [IsAlerted]) VALUES (32, N'Stl Inventory Update', N'1H', N'Middleware.Wm.StlInventoryUpdate.exe', 1, CAST(467.00000 AS Numeric(15, 5)), N'SUCCESS', CAST(N'2016-02-25 13:30:44.533' AS DateTime), CAST(N'2016-02-25 14:30:39.850' AS DateTime), N'Processing', 0)
INSERT [dbo].[Job] ([JobId], [JobKey], [Schedule], [JobExecutable], [IsActive], [LastRunExecutionTime], [LastRunStatus], [LastRunDateTime], [NextRunDateTime], [JobType], [IsAlerted]) VALUES (33, N'Aurora Transfer Control Job', N'10M', N'Middleware.WM.Aurora.TransferControl.exe', 1, CAST(429.00000 AS Numeric(15, 5)), N'SUCCESS', CAST(N'2016-02-25 13:40:41.417' AS DateTime), CAST(N'2016-02-25 13:50:39.850' AS DateTime), N'TransferControl', 0)
INSERT [dbo].[Job] ([JobId], [JobKey], [Schedule], [JobExecutable], [IsActive], [LastRunExecutionTime], [LastRunStatus], [LastRunDateTime], [NextRunDateTime], [JobType], [IsAlerted]) VALUES (35, N'Aurora Pick Job', N'10M', N'Middleware.Wm.Aurora.PickTickets.exe', 1, CAST(523.00000 AS Numeric(15, 5)), N'SUCCESS', CAST(N'2016-02-25 13:40:41.587' AS DateTime), CAST(N'2016-02-25 13:50:39.850' AS DateTime), N'Outbound', 0)
INSERT [dbo].[Job] ([JobId], [JobKey], [Schedule], [JobExecutable], [IsActive], [LastRunExecutionTime], [LastRunStatus], [LastRunDateTime], [NextRunDateTime], [JobType], [IsAlerted]) VALUES (36, N'General Ledger Reconcilliation', N'1H', N'Middleware.Wm.GeneralLedgerReconcilliation.exe', 1, CAST(1766.00000 AS Numeric(15, 5)), N'SUCCESS', CAST(N'2016-02-25 13:30:45.830' AS DateTime), CAST(N'2016-02-25 14:30:39.850' AS DateTime), N'Processing', 0)
INSERT [dbo].[Job] ([JobId], [JobKey], [Schedule], [JobExecutable], [IsActive], [LastRunExecutionTime], [LastRunStatus], [LastRunDateTime], [NextRunDateTime], [JobType], [IsAlerted]) VALUES (37, N'Aurora Pick Confirmation Job', N'10M', N'Middleware.Wm.PickTicketConfirmation.exe', 1, CAST(14641.00000 AS Numeric(15, 5)), N'SUCCESS', CAST(N'2016-02-25 13:40:55.593' AS DateTime), CAST(N'2016-02-25 13:50:39.850' AS DateTime), N'ManhattanInbound', 0)
INSERT [dbo].[Job] ([JobId], [JobKey], [Schedule], [JobExecutable], [IsActive], [LastRunExecutionTime], [LastRunStatus], [LastRunDateTime], [NextRunDateTime], [JobType], [IsAlerted]) VALUES (38, N'Aurora Shipment Job', N'15M', N'Middleware.Wm.Aurora.Shipment.exe', 1, CAST(415.00000 AS Numeric(15, 5)), N'SUCCESS', CAST(N'2016-02-25 13:30:42.627' AS DateTime), CAST(N'2016-02-25 13:45:39.850' AS DateTime), N'AuroraInbound', 0)
INSERT [dbo].[Job] ([JobId], [JobKey], [Schedule], [JobExecutable], [IsActive], [LastRunExecutionTime], [LastRunStatus], [LastRunDateTime], [NextRunDateTime], [JobType], [IsAlerted]) VALUES (39, N'Log and File Maintenance Job', N'8H', N'Middleware.Wm.LoggingAndFileMaintenance.exe', 1, CAST(408.00000 AS Numeric(15, 5)), N'SUCCESS', CAST(N'2016-02-25 12:30:44.913' AS DateTime), CAST(N'2016-02-25 20:30:39.850' AS DateTime), N'Admin', 0)
SET IDENTITY_INSERT [dbo].[Job] OFF
SET ANSI_PADDING ON

GO
ALTER TABLE [dbo].[Job] ADD  CONSTRAINT [IX_JobKey] UNIQUE NONCLUSTERED 
(
	[JobKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
