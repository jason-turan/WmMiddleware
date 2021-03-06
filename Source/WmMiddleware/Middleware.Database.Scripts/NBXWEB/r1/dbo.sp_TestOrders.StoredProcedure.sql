USE [NBXWEB]
GO
/****** Object:  StoredProcedure [dbo].[sp_TestOrders]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		dom viano
-- Create date: 12/15/2015
-- Description:	generate new orders for testing. 
-- =============================================
CREATE PROCEDURE [dbo].[sp_TestOrders]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @BatchCount INT
	SET @BatchCount = 20

	----1) SET A BATCH OF ORDERS TO 'NEW'
	UPDATE [NBXWEB].[dbo].[GP_header] SET [CadreStatus] = 'NEW' 
	WHERE auto_id IN (SELECT TOP (@BatchCount) h.auto_id 
					FROM [NBXWEB].[dbo].[GP_header] h
					INNER JOIN NBXWEB.dbo.GP_line_items l ON l.order_number = h.order_number
					WHERE h.[DIS_when_downloaded] BETWEEN (CAST(GETDATE() - 2 AS DATE)) AND (CAST(GETDATE() - 1 AS DATE)) 
					AND l.Inventory_Type = 'STL'AND h.CadreStatus = 'TEST')

	----2) SET THE ASSOCIATED LINE ITEMS TO 'NEW'
	UPDATE[NBXWEB].[dbo].[GP_line_items] SET [CadreStatus] = 'NEW'
	WHERE order_number IN (SELECT order_number FROM GP_header WHERE CadreStatus = 'NEW')

END

GO
