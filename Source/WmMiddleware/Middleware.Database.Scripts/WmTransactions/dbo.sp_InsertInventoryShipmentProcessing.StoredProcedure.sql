USE [WMTransactions]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertInventoryShipmentProcessing]    Script Date: 2/25/2016 1:50:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Dominic Viano>
-- Create date: <1/27/2016>
-- Description:	<inventory pix processing>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertInventoryShipmentProcessing]
	@InventoryShipmentProcessingTable InventoryShipmentProcessingTable readonly
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [dbo].[InventoryShipmentProcessing]
	SELECT ManhattanShipmentLineItemId, GetDate()
	FROM @InventoryShipmentProcessingTable

END



GO
