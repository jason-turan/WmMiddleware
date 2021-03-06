USE [WarehouseManagement]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetShipmentCancellationEmailDistribution]
 @Company as nvarchar(20)
AS

SELECT Company, DistributionList, AdministrationSiteLink 
FROM ShipmentCancellationEmailDistribution
WHERE Company = @Company
GO
