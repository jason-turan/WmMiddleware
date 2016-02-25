USE [WMTransactions]
GO
/****** Object:  View [dbo].[STLInventory_Latest]    Script Date: 2/25/2016 1:50:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE VIEW [dbo].[STLInventory_Latest]
AS
	
SELECT
	[UPC],
	[Style],
	[Size],
	[Attribute],
	[Quantity],
	[InventoryDate]
	FROM WMTransactions.dbo.STLInventory 
	WHERE InventoryDate = (SELECT MAX(InventoryDate) FROM WMTransactions.dbo.STLInventory)




GO
