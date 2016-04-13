USE [WarehouseManagement]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_GetBatchControlNumber]
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[Identity]
	SET [BatchControlNumber] = [BatchControlNumber] + 1

	SELECT [BatchControlNumber] 
	FROM [dbo].[Identity]
END



GO
