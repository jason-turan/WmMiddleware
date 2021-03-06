USE [WMTransactions]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCancellationsForEmailNotification]    Script Date: 2/25/2016 1:50:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetCancellationsForEmailNotification]
AS
SELECT msh.OrderNumber, 
	   msli.PickticketLineNumber as LineNumber, 
	   msli.PackageBarcode as StockKeepingUnit
FROM ManhattanShipmentHeader msh
INNER JOIN ManhattanShipmentLineItem msli
ON msh.PickticketControlNumber = msli.PickticketControlNumber
LEFT JOIN [ManhattanShipmentLineItemCancellationProcessing] mslicp
ON msli.ManhattanShipmentLineItemId = mslicp.ManhattanShipmentLineItemId
WHERE shippedquantity = 0
AND msh.EmailStatus = 'NEW'
GO
