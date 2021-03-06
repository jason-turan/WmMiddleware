USE [WarehouseManagement]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetIntegrationTask]
@JobId int
AS
SELECT  it.DestinationTypeId, 
		it.IntegrationTaskId, 
		it.JobId, it.Sequence, 
		it.SourceTypeId, 
		it.XsltTransformName
FROM Job j
INNER JOIN IntegrationTask it
	ON j.JobId = it.JobId 
WHERE j.JobId = @JobId
GO
