USE [WMTransactions]
GO
/****** Object:  StoredProcedure [dbo].[sp_FindManhattanShipmentLineItems]    Script Date: 2/25/2016 1:50:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_FindManhattanShipmentLineItems]

AS

SELECT Shipment.*
FROM [WMTransactions].[dbo].[ManhattanShipmentLineItem] Shipment
LEFT JOIN [WMTransactions].[dbo].[InventoryShipmentProcessing] PRC ON
Shipment.ManhattanShipmentLineItemId = PRC.ManhattanShipmentLineItemId
WHERE PRC.ProcessedDate IS NULL
AND Shipment.ShippedQuantity <> 0


GO
