USE [WarehouseManagement]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetIntegrationTaskEndpoint]
@IntegrationTaskEndpointid INT
AS

SELECT 
	itec.ConfigurationValue,
	itet.IntegrationTaskEndpointTypeName,
	itect.IntegrationTaskEndpointConfigurationType
FROM IntegrationTaskEndpoint ite
JOIN IntegrationTaskEndpointType itet 
    ON ite.IntegrationTaskEndpointTypeId = itet.IntegrationTaskEndpointTypeId
JOIN IntegrationTaskEndpointConfigurationType itect 
    ON itect.IntegrationTaskEndpointTypeId = itet.IntegrationTaskEndpointTypeId
LEFT JOIN IntegrationTaskEndpointConfiguration itec 
    ON itec.IntegrationTaskEndpointId = ite.IntegrationTaskEndpointId 
    AND itec.IntegrationTaskEndpointConfigurationTypeId = itect.IntegrationTaskEndpointConfigurationTypeId
WHERE ite.IntegrationTaskEndpointId = @IntegrationTaskEndpointId
GO
