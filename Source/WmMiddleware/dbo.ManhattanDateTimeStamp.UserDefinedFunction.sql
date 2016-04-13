USE [WMTransactions]
GO

/****** Object:  UserDefinedFunction [dbo].[ManhattanDateTimeStamp]    Script Date: 3/22/2016 3:15:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







CREATE FUNCTION [dbo].[ManhattanDateTimeStamp] (@DateCreated NVARCHAR(9), @TimeCreated NVARCHAR(7)) RETURNS DATETIME
AS
BEGIN
		
		DECLARE @DateTimeObject DATETIME

		SET @DateTimeObject = (CAST(@DateCreated + ' ' + 
							 STR(FLOOR(@TimeCreated / 10000), 2, 0) + ':' 
							 + RIGHT(STR(FLOOR(@TimeCreated / 100), 6, 0), 2) + ':' 
							 + RIGHT(STR(@TimeCreated), 2) AS datetime))

return @DateTimeObject
END






GO


