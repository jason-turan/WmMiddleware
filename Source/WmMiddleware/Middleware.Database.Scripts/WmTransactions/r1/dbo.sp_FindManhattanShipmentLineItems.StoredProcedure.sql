USE [WMTransactions]
GO
/****** Object:  StoredProcedure [dbo].[sp_FindManhattanShipmentLineItems]    Script Date: 3/22/2016 3:13:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_FindManhattanShipmentLineItems]

AS

SELECT Shipment.*
FROM [WMTransactions].[dbo].[ManhattanShipmentLineItem] Shipment
LEFT JOIN [WMTransactions].[dbo].[InventoryShipmentProcessing] PRC ON
Shipment.ManhattanShipmentLineItemId = PRC.ManhattanShipmentLineItemId
WHERE PRC.ProcessedDate IS NULL
AND dbo.ManhattanDateTimeStamp(DateCreated, TimeCreated) >= (SELECT MAX(ManhattanDateTime) FROM dbo.InventorySyncProcessing)
AND Shipment.ShippedQuantity <> 0

