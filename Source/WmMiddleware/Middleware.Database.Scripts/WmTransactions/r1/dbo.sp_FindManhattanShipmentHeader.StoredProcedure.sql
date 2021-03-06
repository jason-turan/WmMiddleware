USE [WMTransactions]
GO
/****** Object:  StoredProcedure [dbo].[sp_FindManhattanShipmentHeader]    Script Date: 2/25/2016 1:50:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_FindManhattanShipmentHeader] --'CDX'



@ShipTo VARCHAR(10),
@BncAuroraProcessing BIT = 0,  -- only return records not procesed for aurora shipments
@BncGeneralLedgerProcessing BIT = 0-- only return records not processed for general ledger



AS



SELECT [ManhattanShipmentHeaderId]



      ,[ProcessedFlag]



      ,msh.[ProcessedDate]



      ,[ProcessedTime]



      ,[DateCreated]



      ,[TimeCreated]



      ,[Company]



      ,[Division]



      ,msh.[PickticketControlNumber]



      ,[Warehouse]



      ,[Pickticketnumber]



      ,[PickticketSuffix]



      ,[OrderNumber]



      ,[OrderSuffix]



      ,[OrderType]



      ,[Shipto]



      ,[Soldto]



      ,[StoreNumber]



      ,[DcCenterNumber]



      ,[MerchandiseClass]



      ,[MerchandiseCompany]



      ,[MerchandiseDivision]



      ,[ReferencePickticketControlNumberType]



      ,[ReferencePickticketControlNumber]



      ,[CartonLabelType]



      ,[LogicalWarehouse]



      ,[TransferWarehouse]



      ,[WarehouseTransferType]



      ,[Currency]



      ,[PlannedShipVia]



      ,[PlannedLoadNumber]



      ,[PlannedShipmentNumber]



      ,[PickticketGenerationDate]



      ,[PickticketPrintDate]



      ,[ReasonCode]



      ,[ScheduleDeliveryDate]



      ,[ShipDate]



      ,[ShipmentTypeDi]



      ,[CustomerPonumber]



      ,[ArAccountNumber]



      ,[TotalWeight]



      ,[TotalShippedQuantity]



      ,[TotNumberOfCartons]



      ,[TotalNumberOfLines]



      ,[ShipWithControlNumber]



      ,[ProductValue]



      ,[RecalculateOrderChg]



      ,[CreditAmount]



      ,[OrderCharge]



      ,[HandlingCharges]



      ,[TaxCharges]



      ,[MiscellaneousCharges]



      ,[BaseCharge]



      ,[CarrierCharge]



      ,[CustomerCharge]



      ,[InsuranceCharge]



      ,[AccessorialCharge]



      ,[LineHaulCharge]



      ,[DistributingCharge]



      ,[GlobalLocationNumber]



      ,[MiscellaneousIns5Byte1]



      ,[MiscellaneousIns5Byte2]



      ,[MiscellaneousIns5Byte3]



      ,[MiscellaneousIns5Byte4]



      ,[MiscellaneousIns10Byte1]



      ,[MiscellaneousIns10Byte2]



      ,[MiscellaneousIns20Byte1]



      ,[MiscellaneousIns20Byte2]



      ,[MiscellaneousIns20Byte3]



      ,[MiscellaneousIns20Byte4]



      ,[MiscellaneousIns20Byte5]



      ,[MiscellaneousIns20Byte6]



      ,[MiscellaneousIns20Byte7]



      ,[MiscellaneousIns20Byte8]



      ,[MiscellaneousIns20Byte9]



      ,[MiscellaneousIns20Byte10]



      ,[MiscellaneousIns5Byte5]



      ,[MiscellaneousIns5Byte6]



      ,[MiscellaneousIns5Byte7]



      ,[MiscellaneousIns5Byte8]



      ,[MiscellaneousIns10Byte3]



      ,[MiscellaneousIns10Byte4]



      ,[MiscellaneousIns10Byte5]



      ,[MiscellaneousIns10Byte6]



      ,[MiscellaneousIns20Byte11]



      ,[MiscellaneousIns20Byte12]



      ,[MiscellaneousIns20Byte13]



      ,[MiscellaneousIns20Byte14]



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



      ,[SpecialInstructionCode1]



      ,[SpecialInstructionCode2]



      ,[SpecialInstructionCode3]



      ,[SpecialInstructionCode4]



      ,[SpecialInstructionCode5]



      ,[SpecialInstructionCode6]



      ,[SpecialInstructionCode7]



      ,[SpecialInstructionCode8]



      ,[SpecialInstructionCode9]



      ,[SpecialInstructionCode10]



      ,[FreightTerms]



      ,[BatchInvoiceForOrd]



      ,[PrebillingStatus]



      ,[InvoicingStatus]



      ,[DeliveryStatus]



      ,[InvoicedByPickticketFlag]



      ,msh.[BatchControlNumber]



      ,[RecordExpansionField]



      ,[CustomRecordExpansionField]



      ,[BulkInvoice]



      ,[InvoiceEditFlag]



      ,[CodFlag]



      ,[ShipfromName]



      ,[ShipfromAddr1]



      ,[ShipfromAddr2]



      ,[ShipfromAddr3]



      ,[ShipfromCity]



      ,[ShipfromState]



      ,[ShipfromZip]



,[ShipfromCountry]



      ,[ShiptoName]



      ,[ShipToName2]



      ,[ShiptoAddr1]



      ,[ShiptoAddr2]



      ,[ShiptoAddr3]



      ,[ShiptoCity]



      ,[ShiptoState]



      ,[ShiptoZip]



      ,[ShiptoCountry]



      ,[ShipforName]



      ,[ShipForName2]



,[ShipforAddr1]



      ,[ShipforAddr2]



      ,[ShipforAddr3]



      ,[ShipforCity]



      ,[ShipforState]



      ,[ShipforZip]



      ,[ShipforCountry]



      ,[RetailPickticket]



      ,[ConsolidatorAddressCode]



      ,[TmsOrderType]



      ,[HostApointmentNumber]



      ,[NumberOfDetailLines]



      ,[WarehouseXferAsnCreate]



      ,[BackordrPickticketExists]



      ,[BackordrPickticket]



      ,[ReasonCodeShortDescription]



      ,[ShippedShipVia]



      ,[GenerateInvoiceData]



  FROM [dbo].[ManhattanShipmentHeader] msh



  LEFT JOIN ManhattanShipmentBncProcessing msbp



	ON msh.PickticketControlNumber = msbp.PickticketControlNumber
	AND msh.BatchControlNumber = msbp.batchcontrolnumber
  LEFT JOIN ManhattanShipmentBncGlProcessing msbpgl



	ON msh.PickticketControlNumber = msbpgl.PickticketControlNumber

	AND msh.BatchControlNumber = msbpgl.batchcontrolnumber



WHERE ShipTo = @ShipTo



AND (@BncAuroraProcessing = 1 AND @BncGeneralLedgerProcessing = 0 AND msbp.batchcontrolnumber IS NULL)
OR (@BncAuroraProcessing = 0 AND @BncGeneralLedgerProcessing = 1 AND msbpgl.batchcontrolnumber IS NULL)



--select * from ManhattanShipmentBncProcessing
GO
