USE [WMTransactions]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateShipmentEmailStatus]    Script Date: 2/25/2016 1:50:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_UpdateShipmentEmailStatus]
	@OrderNumberTable OrderNumberTable readonly, 
	@Status varchar(15)
AS
BEGIN
	SET NOCOUNT ON;

	
	UPDATE h
	   SET [EmailStatus] = @Status
	FROM 
	   [WMTransactions].[dbo].[ManhattanShipmentHeader] h
	   JOIN @OrderNumberTable t ON h.OrderNumber = t.OrderNumber
END

GO
