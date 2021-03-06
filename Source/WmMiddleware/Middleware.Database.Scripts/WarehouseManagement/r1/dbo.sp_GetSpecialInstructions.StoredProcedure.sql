USE [WarehouseManagement]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetSpecialInstructions]
	@SKUs SKUTableType READONLY
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @CommonGender varchar(11)
	SELECT @CommonGender = CASE 
						WHEN COUNT(*) > 1 
						THEN NULL 
						ELSE ( 
							SELECT TOP 1 [Gender] 
							FROM [NBXWEB].[dbo].[NBWE_Inventory_Cache] i
							JOIN @SKUs tvSku ON i.SKU = tvSku.SKU 
						)
					 END
	FROM (
			SELECT DISTINCT Gender 
			FROM [NBXWEB].[dbo].[NBWE_Inventory_Cache] i
			JOIN @SKUs tvSku ON i.SKU = tvSku.SKU
		 ) g

	SELECT [Description] FROM 
	(
		-- Site-level instructions
			SELECT * FROM [dbo].[SpecialInstruction]
			WHERE [SiteLevel] = 1
		UNION
		-- Instructions for specific SKUs
			SELECT si.* FROM [dbo].[SpecialInstruction] si
			JOIN [dbo].[SpecialInstructionSKU] sisku ON si.[Id] = sisku.[SpecialInstructionId]
			JOIN @SKUs tvSku ON sisku.[SKU] = tvSku.[SKU]
		UNION
		-- Instructions when all included SKUs are for a single 'gender'
			SELECT *
			FROM [dbo].[SpecialInstruction]
			WHERE @CommonGender IS NOT NULL AND [Gender] = @CommonGender
	) result
	WHERE (StartDate IS NULL OR StartDate <= GETDATE())
		AND (EndDate IS NULL OR EndDate >= GETDATE())

END

GO
