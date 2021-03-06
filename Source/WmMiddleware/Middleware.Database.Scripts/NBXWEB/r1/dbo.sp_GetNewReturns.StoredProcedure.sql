USE [NBXWEB]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetNewReturns]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================

-- Author:		<Author,,Name>

-- Create date: <Create Date,,>

-- Description:	<Description,,>

-- =============================================

CREATE PROCEDURE [dbo].[sp_GetNewReturns]

	-- Add the parameters for the stored procedure here

AS

BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from

	-- interfering with SELECT statements.

	SET NOCOUNT ON;
	

	declare @ReturnInformation as table
	(
	 Company nvarchar(128),
	 Order_Number nvarchar(128),
	 SKU varchar(128),
	 Style nvarchar(128),
	 Size nvarchar(128),
	 Width nvarchar(128),
	 Reason nvarchar(128),
	 Note nvarchar(128),
	 TimeStamp datetime
	)

	INSERT INTO @ReturnInformation
	SELECT * FROM OPENQUERY(STLSQLPRD02, 'Integration.dbo.usp_GetWmROWData_TEST')

	select *, 3 as Quantity, 'Test' as Website, 'ABC1' as RaNumber 
	from @ReturnInformation

	--WM31 Specifications:
	--	Website
	--	RA number (if present)
	--	Tracking
	--	Order Number
	--	UPC
	--	Description (if present)
	--	Quantity expected
	--	Date  Issued

END


GO
