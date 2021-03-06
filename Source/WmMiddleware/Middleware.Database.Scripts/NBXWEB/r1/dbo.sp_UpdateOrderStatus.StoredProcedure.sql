USE [NBXWEB]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateOrderStatus]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateOrderStatus] 
	@OrderNumberTable OrderNumberTable readonly, @Status varchar(15) AS

UPDATE h
   SET [CadreStatus] = @Status
FROM 
   [NBXWEB].[dbo].[GP_header] h
   JOIN @OrderNumberTable t ON h.Order_Number = t.OrderNumber
 
UPDATE li
   SET [CadreStatus] = @Status
FROM
   [NBXWEB].[dbo].[GP_line_items] li
   JOIN @OrderNumberTable t ON li.Order_Number = t.OrderNumber



GO
