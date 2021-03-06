USE [WMTransactions]
GO

/****** Object:  StoredProcedure [dbo].[sp_AuditStlInventory_Sync]    Script Date: 3/22/2016 3:12:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_AuditStlInventory_Sync]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--Dviano - Comparison report from latest inventory sync vs the applied PIX/Shipment transactions throughout the prior day. 
	--       - In theory, there should be 0 entries if PIX/Shipments are transmitted and applied properly throughout the day. 

	DECLARE @invOld TABLE 
	(
		UPC VARCHAR(13),
		Quantity INT
	)

	DECLARE @invNew TABLE 
	(
		UPC VARCHAR(13),
		Quantity INT
	)

	INSERT INTO @invOld
	SELECT [UPC]
		  ,[Quantity]
	FROM [WMTransactions].[dbo].[STLInventory]
	WHERE [InventoryDate] = (SELECT TOP 1 InventoryDate
	FROM [WMTransactions].[dbo].[STLInventory] 
	WHERE InventoryDate < (SELECT MAX(InventoryDate) FROM [WMTransactions].dbo.STLInventory) 
	ORDER BY InventoryDate DESC)

	INSERT INTO @invNew
	SELECT [UPC]
		  ,[Quantity]
	FROM [WMTransactions].[dbo].[STLInventory_Latest]

	SELECT 'NEW' [Status], UPC, Quantity 
	FROM @invNew
	WHERE UPC NOT IN (SELECT UPC FROM @invOld)
	UNION ALL
	SELECT 'DELETED' [Status], UPC, Quantity
	FROM @invOld 
	WHERE UPC NOT IN (SELECT UPC FROM @invNew)
	UNION ALL 
	SELECT 'ADJ' [Status], n.UPC, (n.Quantity - o.Quantity) AS Quantity 
	FROM @invNew n
	INNER JOIN @invOld o ON n.UPC = o.UPC
	WHERE n.Quantity <> o.Quantity

END

GO


