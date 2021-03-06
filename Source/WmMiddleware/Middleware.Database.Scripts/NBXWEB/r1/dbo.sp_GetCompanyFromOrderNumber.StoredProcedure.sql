USE [NBXWEB]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCompanyFromOrderNumber]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetCompanyFromOrderNumber]



@OrderNumber VARCHAR(15)
AS

SELECT TOP 1 company , order_number
FROM nbxweb.dbo.gp_header (nolock) 
WHERE REPLACE(LEFT(order_number, CHARINDEX('-',order_number)-1),'_',' ') = @OrderNumber
OR order_number = @OrderNumber
GO
