USE [WarehouseManagement]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GeneralLedgerTransactionReasonCodeMap](
	[TransactionReasonCode] [varchar](2) NULL,
	[GeneralLedgerAccount] [varchar](15) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[GeneralLedgerTransactionReasonCodeMap] ([TransactionReasonCode], [GeneralLedgerAccount]) VALUES (N'01', N'60900-01-0100')
INSERT [dbo].[GeneralLedgerTransactionReasonCodeMap] ([TransactionReasonCode], [GeneralLedgerAccount]) VALUES (N'14', N'60900-01-0100')
INSERT [dbo].[GeneralLedgerTransactionReasonCodeMap] ([TransactionReasonCode], [GeneralLedgerAccount]) VALUES (N'90', N'71010-01-1500
')
