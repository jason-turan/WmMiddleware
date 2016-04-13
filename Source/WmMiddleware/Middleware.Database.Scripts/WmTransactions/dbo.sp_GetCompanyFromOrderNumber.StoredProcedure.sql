USE [WMTransactions]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCompanyFromOrderNumber]    Script Date: 2/25/2016 1:50:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetCompanyFromOrderNumber]
@OrderNumber VARCHAR(15)
AS
SELECT company 
FROM nbxweb.dbo.gp_header (nolock) 
WHERE order_number = @OrderNumber
GO
