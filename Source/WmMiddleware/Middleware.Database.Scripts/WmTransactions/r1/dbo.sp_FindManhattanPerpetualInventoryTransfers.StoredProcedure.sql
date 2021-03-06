USE [WMTransactions]
GO

/****** Object:  StoredProcedure [dbo].[sp_FindManhattanPerpetualInventoryTransfers]    Script Date: 3/22/2016 3:19:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_FindManhattanPerpetualInventoryTransfers]

@TransactionCode NVARCHAR(3) = NULL,
@TransactionType NVARCHAR(3) = NULL,
@UnprocessedOnly bit = 0,
@ProcessType NVARCHAR(50) = NULL

AS

IF (@ProcessType IS NULL)
BEGIN
SELECT mpit.*
FROM ManhattanPerpetualInventoryTransfer mpit
LEFT JOIN ManhattanPerpetualInventoryTransferProcessing mpitp
ON mpit.ManhattanPerpetualInventoryTransferId = mpitp.ManhattanPerpetualInventoryTransferId
WHERE TransactionType = @TransactionType
AND TransactionCode = @TransactionCode
AND (mpitp.ProcessingId IS NULL AND @UnprocessedOnly = 1) OR @UnprocessedOnly = 0
END
ELSE IF (@ProcessType = 'InventoryAdjustment')
BEGIN
SELECT mpit.*
FROM ManhattanPerpetualInventoryTransfer mpit
LEFT JOIN InventoryPixProcessing prc
ON mpit.ManhattanPerpetualInventoryTransferId = prc.ManhattanPerpetualInventoryTransferId
WHERE TransactionType = @TransactionType
AND prc.ProcessedDate IS NULL
AND dbo.ManhattanDateTimeStamp(DateCreated, TimeCreated) >= (SELECT MAX(ManhattanDateTime) FROM dbo.InventorySyncProcessing)
AND mpit.InventoryAdjustmentQuantity <> 0
END
ELSE IF (@ProcessType = 'GeneralLedger_InventoryAdjustment')
BEGIN
SELECT mpit.*, inv.Class as ProductClass
FROM ManhattanPerpetualInventoryTransfer mpit
LEFT JOIN ManhattanPerpetualInventoryTransferGeneralLedgerProcessing prc
ON mpit.ManhattanPerpetualInventoryTransferId = prc.ManhattanPerpetualInventoryTransferId
INNER JOIN NBXWEB.dbo.NBWE_Inventory_Cache inv
ON mpit.PackageBarcode = inv.SKU
WHERE prc.ProcessedDate IS NULL
AND mpit.InventoryAdjustmentQuantity <> 0
AND mpit.TransactionReasonCode IS NOT NULL
END
ELSE IF (@ProcessType = 'GeneralLedger_PurchaseOrder')
BEGIN
SELECT mpit.*, inv.Class as ProductClass
FROM ManhattanPerpetualInventoryTransfer mpit
LEFT JOIN ManhattanPerpetualInventoryTransferGeneralLedgerProcessing prc
ON mpit.ManhattanPerpetualInventoryTransferId = prc.ManhattanPerpetualInventoryTransferId
INNER JOIN NBXWEB.dbo.NBWE_Inventory_Cache inv
ON mpit.PackageBarcode = inv.SKU
WHERE prc.ProcessedDate IS NULL
AND TransactionType = @TransactionType
AND TransactionCode = @TransactionCode
END
ELSE IF (@ProcessType = 'GeneralLedger_PurchaseReturn')
BEGIN
SELECT mpit.*, inv.Class as ProductClass
FROM ManhattanPerpetualInventoryTransfer mpit
LEFT JOIN ManhattanPerpetualInventoryTransferGeneralLedgerProcessing prc
ON mpit.ManhattanPerpetualInventoryTransferId = prc.ManhattanPerpetualInventoryTransferId
INNER JOIN NBXWEB.dbo.NBWE_Inventory_Cache inv
ON mpit.PackageBarcode = inv.SKU
WHERE prc.ProcessedDate IS NULL
AND TransactionType = @TransactionType
AND TransactionCode = @TransactionCode
END
ELSE IF (@ProcessType = 'QuantityAdjust')
BEGIN
SELECT mpit.*, inv.Class as ProductClass
FROM ManhattanPerpetualInventoryTransfer mpit
LEFT JOIN [ManhattanPerpetualInventoryTransferProcessing] prc
ON mpit.ManhattanPerpetualInventoryTransferId = prc.ManhattanPerpetualInventoryTransferId
inner JOIN NBXWEB.dbo.NBWE_Inventory_Cache inv
ON mpit.PackageBarcode = inv.SKU
WHERE prc.ProcessedDate IS NULL
AND TransactionType = @TransactionType
AND TransactionCode = @TransactionCode
END
GO


