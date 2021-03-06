USE [NBXWEB]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateShippingNotificationStatus]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateShippingNotificationStatus] 
	-- Add the parameters for the stored procedure here
	@ShippingNotificationTable ShippingNotificationTable readonly, 
	@Status varchar(15)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--PUT SOME STUFF HERE----------------
	UPDATE d
	   SET [Status]= @Status
	FROM 
	   [NBXWEB].[dbo].[InterfaceShipmentConfirmationDetail] d
	   JOIN @ShippingNotificationTable s ON d.IDInterfaceShipmentConfirmationHeader = s.IDInterfaceShipmentConfirmationHeader
 
 	UPDATE h
	   SET [Status]= @Status
	FROM 
	   [NBXWEB].[dbo].[InterfaceShipmentConfirmationHeader] h
	   JOIN @ShippingNotificationTable s ON h.IDInterfaceShipmentConfirmationHeader = s.IDInterfaceShipmentConfirmationHeader

END


GO
