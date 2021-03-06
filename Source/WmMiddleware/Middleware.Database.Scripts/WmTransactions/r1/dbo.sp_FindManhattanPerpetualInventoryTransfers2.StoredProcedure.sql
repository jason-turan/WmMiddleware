USE [WMTransactions]
GO
/****** Object:  StoredProcedure [dbo].[sp_FindManhattanPerpetualInventoryTransfers2]    Script Date: 2/25/2016 1:50:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_FindManhattanPerpetualInventoryTransfers2]

@TransactionCode NVARCHAR(3) = NULL,

@TransactionType NVARCHAR(3) = NULL,

@ProcessType NVARCHAR(20) = NULL

AS

	SELECT mpit.* 
	FROM ManhattanPerpetualInventoryTransfer mpit
	LEFT JOIN ManhattanPerpetualInventoryTransferProcessing returnProcessing
		ON mpit.ManhattanPerpetualInventoryTransferId = returnProcessing.ManhattanPerpetualInventoryTransferId
	LEFT JOIN InventoryPixProcessing inventoryProcessing
		ON mpit.ManhattanPerpetualInventoryTransferId = inventoryProcessing.ManhattanPerpetualInventoryTransferId
	LEFT JOIN ManhattanPerpetualInventoryTransferGeneralLedgerProcessing generalLedger
		ON mpit.ManhattanPerpetualInventoryTransferId = generalLedger.ManhattanPerpetualInventoryTransferId
	WHERE (TransactionType = @TransactionType or @TransactionType IS NULL)
	AND (TransactionCode = @TransactionCode or @TransactionCode IS NULL)
	AND( 
		(returnProcessing.ProcessingId IS NULL AND @ProcessType = 'Return') 
		OR (inventoryProcessing.ProcessedDate IS NULL AND @ProcessType = 'InventoryAdjustment')
		OR (generalLedger.ProcessingId IS NULL AND @ProcessType = 'GeneralLedger') 
	   )
GO
