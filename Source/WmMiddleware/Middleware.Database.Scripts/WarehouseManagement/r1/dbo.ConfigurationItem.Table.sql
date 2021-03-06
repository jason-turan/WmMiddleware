USE [WarehouseManagement]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConfigurationItem](
	[ConfigurationItemId] [int] IDENTITY(1,1) NOT NULL,
	[Key] [nvarchar](max) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
	[EnvironmentId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ConfigurationItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[ConfigurationItem] ON 

INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (103, N'CompanyNumber', N'25', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (104, N'WarehouseNumber', N'45', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (105, N'TransferControl_InboundFtpLocation', N'CAABATE', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (106, N'TransferControl_InboundMasterFileFtpLocation', N'CAABATE', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (107, N'TransferControl_InboundMasterControlFileName', N'XBCTRL00', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (108, N'TransferControl_Ftp_Enable', N'false', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (109, N'TransferControl_Ftp_Server', N'LDCDVW1', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (110, N'TransferControl_Ftp_UserName', N'JBAFTP', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (111, N'TransferControl_Ftp_Password', N'cosmo', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (112, N'TransferControl_InboundFileDirectory', N'C:\InboundFiles\', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (113, N'TransferControl_InboundFileProcessedDirectory', N'C:\InboundFiles\Processed\', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (114, N'TransferControl_OutboundFileDirectory', N'C:\OutboundFiles\', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (115, N'TransferControl_OutboundFileProcessedDirectory', N'C:\OutboundFiles\Processed\', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (116, N'TransferControl_OutboundMasterControlFileName', N'XBCTRL00', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (117, N'WarehouseAddress_Line1', N'1537 Fencorp Dr', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (118, N'WarehouseAddress_City', N'Fenton', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (119, N'WarehouseAddress_State', N'MO', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (120, N'WarehouseAddress_ZipCode', N'63026', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (121, N'WarehouseAddress_Country', N'US', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (122, N'CompanyNumber', N'25', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (123, N'WarehouseNumber', N'45', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (124, N'TransferControl_InboundFtpLocation', N'NBB45FTPD', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (125, N'TransferControl_InboundMasterFileFtpLocation', N'WMB45BASD', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (126, N'TransferControl_InboundMasterControlFileName', N'XBCTRL00', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (127, N'TransferControl_Ftp_Enable', N'true', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (128, N'TransferControl_Ftp_Server', N'LDCDVW1', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (129, N'TransferControl_Ftp_UserName', N'JBAFTP', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (130, N'TransferControl_Ftp_Password', N'cosmo', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (131, N'TransferControl_InboundFileDirectory', N'D:\FTP_Manhattan\to_manhattan\', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (132, N'TransferControl_InboundFileProcessedDirectory', N'D:\FTP_Manhattan\to_manhattan\Processed\', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (133, N'TransferControl_OutboundFileDirectory', N'D:\FTP_Manhattan\from_manhattan\', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (134, N'TransferControl_OutboundFileProcessedDirectory', N'D:\FTP_Manhattan\from_manhattan\Processed\', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (135, N'TransferControl_OutboundMasterControlFileName', N'XBCTRL00', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (136, N'WarehouseAddress_Line1', N'1537 Fencorp Dr', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (137, N'WarehouseAddress_City', N'Fenton', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (138, N'WarehouseAddress_State', N'MO', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (139, N'WarehouseAddress_ZipCode', N'63026', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (140, N'WarehouseAddress_Country', N'US', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (141, N'Alert_SMPTServer', N'relay.newbalance.com', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (142, N'Alert_SMPTServer', N'relay.newbalance.com', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (143, N'Alert_DistributionList', N'brad.schoen@newbalance.com,kyle.williams@newbalance.com', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (144, N'Alert_DistributionList', N'brad.schoen@newbalance.com,kyle.williams@newbalance.com', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (145, N'PhoneNumber', N'800-595-9138', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (147, N'PhoneNumber', N'800-595-9138', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (148, N'UpsAccountNumber', N'AX1842', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (149, N'UpsAccountNumber', N'AX1842', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (150, N'SMPTServer', N'relay.newbalance.com', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (151, N'SMPTServer', N'relay.newbalance.com', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (152, N'Aurora_TransferControl_InboundFtpLocation', N'CAABATE', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (153, N'Aurora_TransferControl_InboundMasterControlFileName', N'XBCTRL00', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (154, N'Aurora_TransferControl_Ftp_Enable', N'false', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (155, N'Aurora_TransferControl_Ftp_UserName', N'WMSFTP ', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (156, N'Aurora_TransferControl_InboundFileDirectory', N'C:\InboundFiles\Aurora\', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (157, N'Aurora_TransferControl_InboundFileProcessedDirectory', N'C:\InboundFiles\Aurora\Processed\', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (158, N'Aurora_TransferControl_OutboundFileDirectory', N'C:\OutboundFiles\Aurora\', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (159, N'Aurora_TransferControl_OutboundFileProcessedDirectory', N'C:\OutboundFiles\Aurora\Processed\', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (160, N'Aurora_TransferControl_OutboundMasterControlFileName', N'XBCTRL00', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (161, N'Aurora_TransferControl_InboundFtpLocation', N'FTPPRODNA', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (162, N'Aurora_TransferControl_InboundMasterControlFileName', N'XBCTRL00', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (163, N'Aurora_TransferControl_Ftp_Enable', N'true', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (164, N'Aurora_TransferControl_Ftp_UserName', N'WMSFTP', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (165, N'Aurora_TransferControl_InboundFileDirectory', N'D:\FTP_Aurora\to_aurora\', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (166, N'Aurora_TransferControl_InboundFileProcessedDirectory', N'D:\FTP_Aurora\to_aurora\Processed\', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (167, N'Aurora_TransferControl_OutboundFileDirectory', N'D:\FTP_Aurora\from_aurora\', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (168, N'Aurora_TransferControl_OutboundFileProcessedDirectory', N'D:\FTP_Aurora\from_aurora\Processed\', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (169, N'Aurora_TransferControl_OutboundMasterControlFileName', N'XBCTRL00', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (175, N'Oms_LocalDirectory', N'C:\Aurora\Outbound', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (176, N'Oms_Sftp_Username', N'STLftpBNC', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (177, N'Oms_Sftp_Password', N'nEqTHA3!HArD', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (178, N'Oms_Sftp_Directory', N'Test', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (179, N'Oms_Sftp_Host', N'50.56.54.8', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (182, N'Aurora_TransferControl_InboundMasterFileFtpLocation', N'CAABATE', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (188, N'Aurora_TransferControl_InboundMasterFileFtpLocation', N'NBPRODNA', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (189, N'Aurora_TransferControl_Ftp_Server', N'BOSQAA1', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (191, N'Aurora_TransferControl_Ftp_Server', N'BOSQAA1', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (193, N'Aurora_TransferControl_Ftp_Password', N'cosmo', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (194, N'Aurora_TransferControl_Ftp_Password', N'cosmo', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (195, N'Oms_LocalDirectory', N'D:\FTP_Oms\to_oms\', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (198, N'Oms_Sftp_Username', N'STLftpBNC', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (199, N'Oms_Sftp_Password', N'nEqTHA3!HArD', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (200, N'Oms_Sftp_Directory', N'Test', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (201, N'Oms_Sftp_Host', N'50.56.54.8', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (204, N'GeneralLedger_BncAccount', N'37850-01-0000', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (205, N'GeneralLedger_VarianceAccount_Default', N'17200-01-0000', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (206, N'GeneralLedger_VarianceAccount_Footwear', N'17100-01-0000', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (207, N'GeneralLedger_VarianceAccount_Accessory', N'17000-01-0000', 2)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (208, N'GeneralLedger_BncAccount', N'37850-01-0000', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (209, N'GeneralLedger_VarianceAccount_Default', N'17200-01-0000', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (210, N'GeneralLedger_VarianceAccount_Footwear', N'17100-01-0000', 1)
INSERT [dbo].[ConfigurationItem] ([ConfigurationItemId], [Key], [Value], [EnvironmentId]) VALUES (211, N'GeneralLedger_VarianceAccount_Accessory', N'17000-01-0000', 1)
SET IDENTITY_INSERT [dbo].[ConfigurationItem] OFF
ALTER TABLE [dbo].[ConfigurationItem]  WITH CHECK ADD FOREIGN KEY([EnvironmentId])
REFERENCES [dbo].[Environment] ([EnvironmentId])
GO
