USE [WMTransactions]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateSTLInventory]    Script Date: 2/25/2016 1:50:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Dominic Viano>
-- Create date: <1/8/2016>
-- Description:	<Apply Pix and Shipment info to inventory quantities>
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateSTLInventory]
	@StlInventoryUpdateTable StlInventoryUpdateTable readonly
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @LATESTDATE DATETIME
	SET @LATESTDATE = (SELECT MAX(InventoryDate) FROM [dbo].[STLInventory])

	DECLARE @LATESTTRANSACTIONNUMBER INT
	SET @LATESTTRANSACTIONNUMBER = (SELECT TOP 1 ManhattanInventorySyncTransactionNumber FROM [dbo].[STLInventory] WHERE InventoryDate = @LATESTDATE)

	--UPDATE THE QTYS FROM THE PIX/SHIPMENT DATA
	UPDATE [dbo].[STLInventory]
		SET Quantity = ([STLInventory].Quantity + newInv.Quantity)
	FROM @StlInventoryUpdateTable as newInv
	WHERE [STLInventory].UPC = newInv.UPC AND [STLInventory].InventoryDate = @LATESTDATE
	
	--INSERT NEW IVENTORY NOT IN LATEST FEED
	INSERT INTO [dbo].[STLInventory]
	SELECT UPC, Style, Size, Attribute, Quantity, @LATESTTRANSACTIONNUMBER, @LATESTDATE
	FROM @StlInventoryUpdateTable newInv
	WHERE NOT EXISTS (SELECT TOP 1 UPC FROM [dbo].[STLInventory] a WHERE a.InventoryDate = @LATESTDATE AND a.UPC = newInv.UPC)

	--UPDATE THE INVENTORY DATE TO MARK COMPLETION
	UPDATE [dbo].[STLInventory]
	SET InventoryDate = GETDATE()
	WHERE [dbo].[STLInventory].InventoryDate = @LATESTDATE

END


GO
