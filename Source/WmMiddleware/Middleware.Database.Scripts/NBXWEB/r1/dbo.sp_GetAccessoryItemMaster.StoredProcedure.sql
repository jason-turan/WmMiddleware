USE [NBXWEB]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAccessoryItemMaster]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================

-- Author:		Dom Viano

-- Create date: 12-08-2015

-- Description:	Intial proc to bring down accessory details to manhattan

-- =============================================

CREATE PROCEDURE [dbo].[sp_GetAccessoryItemMaster]

	@LastSuccess DATETIME = NULL

AS

BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from

	-- interfering with SELECT statements.

	SET NOCOUNT ON;



	--dviano: 12/21/2015 - Filter out bad upc containing "TEST" within the SKU field. 



	IF (@LastSuccess IS NULL)

		BEGIN



			--FULL PULL--------------

			SELECT SUBSTRING([Style],1,2) AS MasterStyleSeason, 

        		--SUBSTRING([Style],3,LEN([Style])) AS Style,

        		SUBSTRING([Style],3,7) AS Style,

        		Attr,

        		[Size],

        		[Class],

        		[Description],

        		[SKU],

        		[Standard_Cost],

        		Category,

        		SubCategory,

        		Vendor, 

        		Gender,

        		b.Abbr AS BrandCode,

        		NULL AS LastModified --Not needed for full pull, but keeps the result sets consistent if needed. 

      	  FROM [NBXWEB].[dbo].[NBWE_Inventory_Cache] inv WITH(NOLOCK)

      	  LEFT JOIN [STLSQLPRD02].DataRevolution.dbo.Brands b WITH(NOLOCK) ON b.Name = inv.Brand

      	  WHERE inv.Vendor NOT IN (SELECT DISTINCT(VendorId)

                    FROM [STLSQLPRD02].[Integration].[dbo].[VendorSettings] WITH(NOLOCK)

                    WHERE vendorid NOT LIKE 'NB%' AND vendorid NOT IN ('hicbr', 'impfo', 'klola', 'renco','golmo'))  

      			--AND SKU not in (SELECT Upc FROM stlsqlprd02.inventory.dbo.upc WITH(NOLOCK))

      			AND class <>'misc'

      			AND SKU NOT LIKE '%TEST%'

				AND STYLE not like 'zzz%'



		END

	ELSE

		BEGIN



			--DELTA PULL------------ (Requires a hook into GP table for the last modified date)

			EXEC [STLSQLPRD02].[Inventory].dbo.usp_GetAccessoryItemMaster @LastSuccess



		END





END





GO
