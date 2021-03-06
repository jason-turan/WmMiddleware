USE [WMTransactions]
GO
/****** Object:  StoredProcedure [dbo].[sp_FindManhattanInventorySync]    Script Date: 2/25/2016 1:50:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_FindManhattanInventorySync]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  	SELECT mis.*
	FROM [WMTransactions].dbo.ManhattanInventorySync mis
	LEFT JOIN WMTransactions.dbo.InventorySyncProcessing P
	ON mis.TransactionNumber = P.TransactionNumber
	WHERE P.ReceivedDate = (SELECT MAX(ReceivedDate) FROM WMTransactions.dbo.InventorySyncProcessing) AND
	mis.HostInventoryBucket = 'ONH' AND P.ProcessedDate IS NULL

END


GO
