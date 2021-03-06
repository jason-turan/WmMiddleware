USE [NBXWEB]
GO
/****** Object:  StoredProcedure [dbo].[sp_RefreshCache]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[sp_RefreshCache]
WITH 
EXECUTE AS CALLER
AS
BEGIN
		

TRUNCATE TABLE NBWE_Inventory_Cache
INSERT INTO NBWE_Inventory_Cache
(
	Description,
	Store_Status,
	Vendor,
	Class,
	Gender,
	SKU,
	Style,
	Size,
	Attr,
	Standard_Cost,
	Current_Cost,
	GP_Avg_On_Hand_Cost,
	Retail_Price,
	Category,
	Subcategory,
	GP_On_Hand_Qty,
	GP_Available_Qty,
	JNBO_GP_Available_Qty,
	On_Dock,
	Cadre_Qty,
	GP_Received_Qty,
	Quantity,
	Min_Qty,
	Max_Qty,
	Brand,
	Intro_Date,
	Phase_out_Date,
	On_Site_Date,
	Web_Closeout,
	Pink_Ribbon,
	Made_in_USA,
	Girls_on_the_Run,
	Promo,
	Corp_Closeout,
	NBEE,
	Short_sleeve,
	Long_sleeve,
	Sleeveless,
	Pants,
	Tights,
	Capri,
	Brief,
	Bra_Crop,
	Bra_Top,
	Hooded,
	Shoe_Last,
	Shoe_Color,
	Velcro,
	Futures_Only,
	InTransit,
	CacheDate
)
SELECT Description,
	Store_Status,
	Vendor,
	Class,
	Gender,
	SKU,
	Style,
	Size,
	Attr,
	Standard_Cost,
	Current_Cost,
	GP_Avg_On_Hand_Cost,
	Retail_Price,
	Category,
	Subcategory,
	GP_On_Hand_Qty,
	GP_Available_Qty,
	JNBO_GP_Available_Qty,
	On_Dock,
	Cadre_Qty,
	GP_Received_Qty,
	Quantity,
	Min_Qty,
	Max_Qty,
	Brand,
	Intro_Date,
	Phase_out_Date,
	On_Site_Date,
	Web_Closeout,
	Pink_Ribbon,
	Made_in_USA,
	Girls_on_the_Run,
	Promo,
	Corp_Closeout,
	NBEE,
	Short_sleeve,
	Long_sleeve,
	Sleeveless,
	Pants,
	Tights,
	Capri,
	Brief,
	Bra_Crop,
	Bra_Top,
	Hooded,
	Shoe_Last,
	Shoe_Color,
	Velcro,
	Futures_Only,
	InTransit,
	GETDATE() AS CacheDate
FROM STLGP1.NBSNB.dbo.NBWE_Inventory ni 

END





GO
