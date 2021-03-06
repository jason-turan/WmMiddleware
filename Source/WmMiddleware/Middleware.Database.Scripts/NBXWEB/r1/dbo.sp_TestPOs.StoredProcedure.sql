USE [NBXWEB]
GO
/****** Object:  StoredProcedure [dbo].[sp_TestPOs]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		dom viano
-- Create date: 12/15/2015
-- Description:	generate new orders for testing. 
-- =============================================
CREATE PROCEDURE [dbo].[sp_TestPOs]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE [NBXWEB].[dbo].[PODetail_Interface]
	   SET [InterfaceStatus]= 'NEW'
 
	UPDATE [NBXWEB].[dbo].[POHeader_Interface]
	   SET [InterfaceStatus]= 'NEW'

END


GO
