USE [NBXWEB]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetNewPurchaseOrders]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Dom Viano
-- Create date: 12/8/2015
-- Description:	Intial proc to bring PO data into manhattan
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetNewPurchaseOrders] 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--Note: This will eventually hook to STLGP1.NBSNB and query existing views POHeader_Interface and PODetail_Interface.
	--      These two views contain logic to determine whether a new PO is available for consumption. 
	--TODO: Determine where to status a PO as processed within STLGP1.NBSNB once we successfully send it to Manhattan. 
	SELECT h.ActionCode, 
		   h.InterfaceStatus,
		   h.InterfaceDate, 
		   h.ExternalUID, 
		   POSTATUS, 
		   POTYPE, 
		   PODate, 
		   h.FacilityNbr,
		   h.VendorAcct, 
		   h.AmtCost, 
		   h.DiscAvail, 
		   h.AmtFreight, 
		   h.DateDue, 
		   h.CreateReceiver, 
		   h.BuyerRefNbr,
		   d.IDPOHeaderInterface, 
		   d.POLineNbr,
		   d.SKU, 
		   d.UPC, 
		   d.Class, 
		   d.QtyOrd, 
		   d.VendorPartNbr, 
		   d.Price, 
		   d.Extension, 
		   d.BuyerRef, 
		   d.UOM,
		   SUBSTRING(inv.[Style],1,2) AS SeasonYear,
		   SUBSTRING(inv.[Style],3,7) AS Style,
		   inv.[Attr] AS Color,
		   inv.[Size] AS Size
	  FROM [NBXWEB].[dbo].[POHeader_Interface] h
	  INNER JOIN [NBXWEB].[dbo].[PODetail_Interface] d ON d.BuyerRef = h.ExternalUID
	  INNER JOIN [NBXWEB].[dbo].NBWE_Inventory_Cache inv ON inv.SKU = d.SKU
	  WHERE d.InterfaceStatus = 'NEW'

END

GO
