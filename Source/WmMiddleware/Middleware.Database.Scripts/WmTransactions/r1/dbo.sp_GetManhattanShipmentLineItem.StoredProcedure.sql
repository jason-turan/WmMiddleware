USE [WMTransactions]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetManhattanShipmentLineItem]    Script Date: 2/25/2016 1:50:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetManhattanShipmentLineItem]

@PickTicketControlNumber VARCHAR(10),

@BatchControlNumber VARCHAR(10)

AS

SELECT [ManhattanShipmentLineItemId]

      ,[ProcessedFlag]

      ,[ProcessedDate]

      ,[ProcessedTime]

      ,[DateCreated]

      ,[TimeCreated]

      ,[ShippedCompany]

      ,[ShippedDivision]

      ,[PickticketControlNumber]

      ,[PickticketLineNumber]

      ,[ShippedSizePosn]

      ,[ShippedSeason]

      ,[ShippedSeasonYear]

      ,[ShippedStyle]

      ,[ShippedStyleSuffix]

      ,[ShippedColor]

      ,[ShippedColorSuffix]

      ,[ShippedSecDimn]

      ,[ShippedQuality]

      ,[LotNumber]

      ,[PickticketQuantity]

      ,[ShippedQuantity]

      ,[DeliveredUnits]

      ,[ReasonCode1]

      ,[ReasonCode2]

      ,[ReasonCode3]

      ,[ReasonCode4]

      ,[ReasonCode5]

      ,[ShippedSizeCode]

      ,[ShippedSizeDescription]

      ,[PackageBarcode]

      ,[CustomerSku]

      ,[PrePackGroupCode]

      ,[AssortmentNumber]

      ,[NumberUnitsInPrepack]

      ,[PriceTicketType]

      ,[AreaOutboundOnly]

      ,[ZoneOutboundOnly]

      ,[AisleOutboundOnly]

      ,[BayOutboundOnly]

      ,[LevelOutboundOnly]

      ,[PositionOutboundOnly]

      ,[DistroType]

      ,[Distronumber]

      ,[StoreNumber]

      ,[Taxable]

      ,[TaxPercentage]

      ,[SupprprtAmounts]

      ,[SpecialInstructionCode1]

      ,[SpecialInstructionCode2]

      ,[SpecialInstructionCode3]

      ,[SpecialInstructionCode4]

      ,[SpecialInstructionCode5]

      ,[MiscellaneousIns20Byte1]

      ,[MiscellaneousIns20Byte2]

      ,[MiscellaneousIns20Byte4]

      ,[MiscellaneousIns20Byte5]

      ,[MiscellaneousIns20Byte6]

      ,[MiscellaneousIns20Byte7]

      ,[MiscellaneousIns20Byte8]

      ,[MiscellaneousIns20Byte9]

      ,[MiscellaneousIns20Byte10]

      ,[MiscellaneousIns5Byte1]

      ,[MiscellaneousIns5Byte2]

      ,[MiscellaneousIns5Byte3]

      ,[MiscellaneousIns5Byte4]

      ,[MiscellaneousIns10Byte1]

      ,[MiscellaneousIns10Byte2]

      ,[MiscellaneousIns10Byte3]

      ,[MiscellaneousIns10Byte4]

      ,[MiscellaneousIns20Byte11]

      ,[MiscellaneousIns20Byte12]

      ,[MiscellaneousIns20Byte13]

      ,[MiscellaneousIns20Byte14]

      ,[BatchControlNumber]

      ,[MiscellaneousNum1]

      ,[MiscellaneousNum2]

      ,[MiscellaneousNum3]

      ,[MiscellaneousNum4]

      ,[MiscellaneousNum5]

      ,[MiscellaneousNum6]

      ,[MiscellaneousNum7]

      ,[MiscellaneousNum8]

      ,[MiscellaneousNum9]

      ,[MiscellaneousNum10]

      ,[MiscellaneousNum11]

      ,[MiscellaneousNum12]

      ,[PathNumber]

      ,[RecordExpansionField]

      ,[CustomRecordExpansionField]

      ,[LineItemStatus]

      ,[ScheduleDeliveryDate]

      ,[MiscellaneousIns20Byte3]

      ,[OrderedCompany]

      ,[OrderedDivision]

      ,[OrderedSeason]

      ,[OrderedSeasonYear]

      ,[OrderedStyle]

      ,[OrderedStyleSuffix]

      ,[OrderedColor]

      ,[OrderedColorSuffix]

      ,[OrderedSecDimn]

      ,[OrderedQuality]

      ,[OrderedSizeCode]

      ,[OrderedSizePosn]

      ,[OrderedSizeDescription]

      ,[InvoicingStatus]

      ,[DemandId]

      ,[Ponumber]

      ,[ExportIdentificationCode]

      ,[MarksAndNumbers]

      ,[TpePurchaseOrder]

      ,[ShortDescription1]

      ,[ShortDescription2]

      ,[ShortDescription3]

      ,[ShortDescription4]

      ,[ShortDescription5]

	  , inv.Class as ProductClass
  FROM [dbo].[ManhattanShipmentLineItem] msli
  LEFT JOIN NBXWEB.dbo.NBWE_Inventory_Cache inv 
			ON msli.PackageBarcode = inv.SKU
WHERE PickTicketControlNumber = @PickTicketControlNumber

and BatchControlNumber = @BatchControlNumber;





GO
