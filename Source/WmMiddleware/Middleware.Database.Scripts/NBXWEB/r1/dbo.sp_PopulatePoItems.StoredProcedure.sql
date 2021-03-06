USE [NBXWEB]
GO
/****** Object:  StoredProcedure [dbo].[sp_PopulatePoItems]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_PopulatePoItems]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @FromDate DATETIME
	SET @FromDate = '2015-12-01'

	----Hold ID Items TO PULL
	DECLARE @POHeaderItems TABLE
	(
		IDPOHeaderInterface INT
	)

	----HOLD THE PO HEADER IDS
	INSERT INTO @POHeaderItems
	SELECT TOP 1000 IDPOHeaderInterface FROM STLCADRESQL.CDINBW.dbo.POHeader_Interface
	WHERE UpdateDate >= @FromDate 

	--INSERT INTO dbo.POHeader_Interface
	SELECT cadh.ActionCode, 
		  cadh.Direction, 
		  cadh.UpdatePID, 
		  'NEW' as InterfaceStatus, 
		  cadh.InterfaceDate, 
		  cadh.CreateDate, 
		  cadh.ExternalUID,
		  --gph.POSTATUS,
		  '2' AS POStatus,
		  --gph.POType,
		  '1' AS POType,
		  --gph.DOCDate,
		  cadh.PODate,
		  cadh.FacilityNbr,	  
		  --gph.VENDORID,
		  cadh.VendorAcct,	  
		  --gph.SUBTOTAL,
		  cadh.AmtCost,	  
		  --gph.TRDISAMT,
		  cadh.DiscAvail,
		  --gph.FRTAMNT,
		  cadh.AmtFreight,	  
		  --gph.PRMDATE,
		  cadh.DateDue,
		  cadh.CreateReceiver,
		  cadh.ExternalUID AS BuyerRefNbr
	FROM [STLCADRESQL].[CDINBW].[dbo].[POHeader_Interface] cadh
	INNER JOIN @POHeaderItems tmp ON cadh.IDPOHeaderInterface = tmp.IDPOHeaderInterface
	ORDER BY tmp.IDPOHeaderInterface ASC
	
	--INSERT INTO dbo.PODetail_Interface
	SELECT cadd.UpdatePID,
		   cadd.ActionCode,
		   cadd.Direction,
		   cadd.InterfaceDate,
		   'NEW' AS InterfaceStatus,
		   cadd.CreateDate,
		   cadd.IDPOHeaderInterface,
		   cadd.FacilityNbr,
		   cadd.POLineNbr,
		   cadd.SKU,
		   cadd.UPC,
		   cadd.Class,
		   cadd.QtyOrd,
		   cadd.VendorPart,
		   cadd.HotFlag,
		   cadd.Price,
		   cadd.Extension,
		   cadd.DateExpect,
		   cadd.BuyerRef,
		   cadd.UOM
		   FROM [STLCADRESQL].[CDINBW].[dbo].[PODetail_Interface] cadd
		   INNER JOIN @POHeaderItems tmp ON cadd.IDPOHeaderInterface = tmp.IDPOHeaderInterface
		   ORDER BY tmp.IDPOHeaderInterface ASC

END

GO
