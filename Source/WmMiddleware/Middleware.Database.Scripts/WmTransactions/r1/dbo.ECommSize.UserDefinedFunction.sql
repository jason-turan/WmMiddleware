USE [WMTransactions]
GO
/****** Object:  UserDefinedFunction [dbo].[ECommSize]    Script Date: 2/25/2016 1:50:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE FUNCTION [dbo].[ECommSize] (@Size VARCHAR(50)) RETURNS VARCHAR(50)
AS
BEGIN
	
		DECLARE @ECommSize VARCHAR(13)

		SET @ECommSize = CASE @Size

			--FOOTWEAR
			WHEN '05'  THEN  '5'
			WHEN '055' THEN  '5.5'
			WHEN '06'  THEN  '6'
			WHEN '065' THEN  '6.5'
			WHEN '07'  THEN  '7'
			WHEN '075' THEN  '7.5'
			WHEN '08'  THEN  '8'
			WHEN '085' THEN  '8.5'
			WHEN '09'  THEN  '9'
			WHEN '095' THEN  '9.5'
			WHEN '105' THEN '10.5'
			WHEN '115' THEN '11.5'
			WHEN '125' THEN '12.5'
			
			--APPAREL
            WHEN 'LXL' THEN 'L/XL'
	        WHEN '1SZ' THEN 'OSFA'
	        WHEN 'OSZ' THEN 'OSFA'
	        WHEN 'XXS' THEN '2XS'
	        WHEN 'XXL' THEN '2XL'
	        WHEN '32E' THEN '32DD'
	        WHEN '34E' THEN '34DD'
	        WHEN '36E' THEN '36DD'
	        WHEN '38E' THEN '38DD'
	        WHEN '40E' THEN '40DD'
	        WHEN '42E' THEN '42DD'
	        WHEN '44E' THEN '44DD'

			ELSE @Size
	END;

return @ECommSize
END





GO
