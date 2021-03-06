USE [NBXWEB]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetNewShippingNotifications]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetNewShippingNotifications]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	SELECT 
	   h.[UpdateDate]
      ,h.[UpdateUserID]
      ,h.[UpdatePID]
      ,h.[InsertDate]
      ,h.[IDInterfaceShipmentConfirmationHeader]
      ,h.[ExternalUID]
      ,h.[OrderID]
      ,h.[LoadID]
      ,h.[TrackingNumber]
      ,h.[ClientID]
      ,h.[OrderDate]
      ,h.[OrderType]
      ,h.[OrderPriority]
      ,h.[OrderStatus]
      ,h.[ShipDate]
      ,h.[ExpectedDeliveryDate]
      ,h.[CustomerPORef]
      ,h.[CustomerPODate]
      ,h.[RouteID]
      ,h.[StopID]
      ,h.[FacilityNbr]
      ,h.[BillToCustomerID]
      ,h.[SoldToCustomerID]
      ,h.[ShipToCustomerID]
      ,h.[CarrierCode]
      ,h.[SCAC]
      ,h.[ShippingTerms]
      ,h.[BOL]
      ,h.[Seal1]
      ,h.[Seal2]
      ,h.[ContainerSeqNbr]
      ,h.[EquipmentID]
      ,h.[EquipmentType]
      ,h.[WeightUOM]
      ,h.[TotalWeightShipped]
      ,h.[TotalUnitsShipped]
      ,h.[TotalPalletsShipped]
      ,h.[TotalChepPalletsShipped]
      ,h.[InterfaceUser1] AS [HeaderInterfaceUser1]
      ,h.[InterfaceUser2] AS [HeaderInterfaceUser2]
      ,h.[InterfaceUser3] AS [HeaderInterfaceUser3]
      ,h.[InterfaceUser4] AS [HeaderInterfaceUser4]
      ,h.[InterfaceUser5] AS [HeaderInterfaceUser5]
      ,h.[InterfaceUser6] AS [HeaderInterfaceUser6]
      ,h.[InterfaceUser7] AS [HeaderInterfaceUser7]
      ,h.[InterfaceUser8] AS [HeaderInterfaceUser8]
      ,h.[InterfaceUser9] AS [HeaderInterfaceUser9]
      ,h.[InterfaceUser10] AS [HeaderInterfaceUser10]
      ,h.[InterfaceStatus] AS [HeaderInterfaceStatus]
      ,h.[InterfaceErrorText] AS [HeaderInterfaceErrorText]
      ,h.[OriginalMeasType]
      ,h.[ShipPackagingCode]
      ,h.[ShipLadingQty]
      ,h.[ShipWeight]
      ,h.[ShipWeightUOM]
      ,h.[OrderPackagingCode]
      ,h.[OrderLadingQty]
      ,h.[OrderWeight]
      ,h.[OrderWeightUOM]
      ,h.[ShipFromID]
      ,h.[ActualFreightCharge]
      ,h.[DiscountedFreightCharge]
      ,h.[ASNnbr]
      ,h.[ShipmentID]
      ,h.[ActionCode]
      ,h.[VendorID]
      ,h.[ASNdirection]
      ,h.[ASNfacilityNbr]
      ,h.[ProNbr]
      ,h.[BuyerRefNbr]
      ,h.[OutBoundCarrierCode]
      ,h.[Status]
      ,d.[SKU]
      ,d.[SKUClass]
      ,d.[SKUdesc]
      ,d.[UPC]
      ,d.[UOM]
      ,d.[UnitsShipped]
      ,d.[UnitsOrdered]
      ,d.[ParentMUID]
      ,d.[ParentMUType]
      ,d.[ChildMUID]
      ,d.[ChildMUType]
      ,d.[Height]
      ,d.[Width]
      ,d.[Length]
      ,d.[Weight]
      ,d.[LotID]
      ,d.[MfgDate]
      ,d.[ExpDate]
      ,d.[SerialNbr]
      ,d.[InterfaceUser1]
      ,d.[InterfaceUser2]
      ,d.[InterfaceUser3]
      ,d.[InterfaceUser4]
      ,d.[InterfaceUser5]
      ,d.[InterfaceUser6]
      ,d.[InterfaceUser7]
      ,d.[InterfaceUser8]
      ,d.[InterfaceUser9]
      ,d.[InterfaceUser10]
      ,d.[InterfaceStatus]
      ,d.[InterfaceErrorText]
      ,d.[PalletTypeCode]
      ,d.[PalletTiers]
      ,d.[PalletBlocks]
      ,d.[PalletInnerBlocks]
      ,d.[PalletWeight]
      ,d.[PalletWeightUOM]
      ,d.[PalletVolume]
      ,d.[PalletVolumeUOM]
      ,d.[PalletDimensionUOM]
      ,d.[EachQty]
      ,d.[DetailSeqNbr]
      ,d.[CartonQTY]
      ,d.[PalletQTY]
      ,d.[TareWeight]
      ,d.[NetWeight]
	  ,SUBSTRING(inv.[Style],1,2) AS SeasonYear
	  ,SUBSTRING(inv.[Style],3,7) AS Style
      ,inv.[Attr] AS Color
	  ,inv.[Size] AS Size
	FROM dbo.InterfaceShipmentConfirmationHeader h
	INNER JOIN dbo.InterfaceShipmentConfirmationDetail d ON d.[IDInterfaceShipmentConfirmationHeader] = h.[IDInterfaceShipmentConfirmationHeader]
	INNER JOIN [NBXWEB].[dbo].NBWE_Inventory_Cache inv ON inv.SKU = d.SKU
	WHERE D.[Status] = 'NEW'

END

GO
