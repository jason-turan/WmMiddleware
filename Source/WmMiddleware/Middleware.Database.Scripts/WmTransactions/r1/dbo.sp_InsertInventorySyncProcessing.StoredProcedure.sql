USE [WMTransactions]
GO

/****** Object:  StoredProcedure [dbo].[sp_InsertInventorySyncProcessing]    Script Date: 3/22/2016 3:11:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_InsertInventorySyncProcessing]
@TransactionNumber NVARCHAR(9),
@ReceivedDate DATETIME,
@ProcessedDate DATETIME = NULL,
@ManhattanDateCreated NVARCHAR(9),
@ManhattanTimeCreated NVARCHAR(7)
AS
INSERT INTO [dbo].[InventorySyncProcessing]
([TransactionNumber]
,[ReceivedDate]
,[ProcessedDate]
,[ManhattanDateTime])
VALUES
(@TransactionNumber
,@ReceivedDate
,@ProcessedDate
,[WmTransactions].dbo.ManhattanDateTimeStamp(@ManhattanDateCreated, @ManhattanTimeCreated))
GO


