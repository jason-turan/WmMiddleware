USE [WarehouseManagement]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetGeneralLedgerTransactionReasonCodeMap]
AS
SELECT * FROM GeneralLedgerTransactionReasonCodeMap 
GO
