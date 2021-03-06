USE [NBXWEB]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdatePurchaseOrderStatus]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdatePurchaseOrderStatus] 
	-- Add the parameters for the stored procedure here
	@PurchaseOrderTable PurchaseOrderTable readonly, 
	@Status varchar(15)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--TEST DATA--------------------------
	UPDATE d
	   SET [InterfaceStatus]= @Status
	FROM 
	   [NBXWEB].[dbo].[PODetail_Interface] d
	   JOIN @PurchaseOrderTable p ON d.BuyerRef = p.PONumber
 
 	UPDATE h
	   SET [InterfaceStatus]= @Status
	FROM 
	   [NBXWEB].[dbo].[POHeader_Interface] h
	   JOIN @PurchaseOrderTable p ON h.ExternalUID = p.PONumber
	--------------------------------------

	
	--*****PRODUCTION WILL FLAG THE PO AS 'CADRE' TO MARK IT PROCESSED BY Wm*********
	--UPDATE gp
	--   SET [TXRGNNUM] = @Status
	--FROM 
	--   [STLGP1].[NBXWEB].[dbo].[tstPOP10100] gp
	--   JOIN @PurchaseOrderTable p ON gp.PONUMBER = p.PONumber

END

GO
