USE [NBXWEB]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetReturnReasonsFromROW]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetReturnReasonsFromROW]
AS

	--SELECT  r.[rowID]
	--		,[order_number]
	--		,[style_number]
	--		,[prod_size]
	--		,[attribute]
	--		,[UPC]
	--		,[return_reason]
	--		,[additional_return_reason]
	--		,[to_be_exchange]
	--		,[row_submit_date]
	--		,[tracking]
	--		,[current_item_status] 
	--FROM [v_ReturnReasonsfromROW] r
	--LEFT JOIN ReturnReasonFromROWProcessing rp 
	--	ON r.rowId = rp.rowId
	--WHERE current_item_status = 'shipped'
	--AND rp.rowId IS NULL --unprocessed only

		SELECT  r.[rowID]
			,[order_number]
			,[style_number]
			,[prod_size]
			,[attribute]
			,[UPC]
			,[return_reason]
			,[additional_return_reason]
			,[to_be_exchange]
			,[row_submit_date]
			,[tracking]
			,[current_item_status] 
	FROM TempMock_v_ReturnReasonsfromROW r
	LEFT JOIN ReturnReasonFromROWProcessing rp 
		ON r.rowId = rp.rowId
	WHERE current_item_status = 'shipped'
	AND rp.rowId IS NULL --unprocessed only

	

	
GO
