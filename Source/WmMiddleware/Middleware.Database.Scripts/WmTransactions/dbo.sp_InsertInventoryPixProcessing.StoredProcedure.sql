USE [WMTransactions]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertInventoryPixProcessing]    Script Date: 2/25/2016 1:50:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Dominic Viano>
-- Create date: <1/27/2016>
-- Description:	<inventory pix processing>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertInventoryPixProcessing]
	@InventoryPixProcessingTable InventoryPixProcessingTable readonly
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [dbo].[InventoryPixProcessing]
	SELECT ManhattanPerpetualInventoryTransferId, GetDate()
	FROM @InventoryPixProcessingTable

END



GO
