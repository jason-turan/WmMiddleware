USE [WMTransactions]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertInventorySyncProcessing]    Script Date: 2/25/2016 1:50:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertInventorySyncProcessing]
@TransactionNumber NVARCHAR(9),
@ReceivedDate DATETIME,
@ProcessedDate DATETIME 
AS
INSERT INTO [dbo].[InventorySyncProcessing]
([TransactionNumber]
,[ReceivedDate]
,[ProcessedDate])
VALUES
(@TransactionNumber
,@ReceivedDate
,@ProcessedDate)
GO
