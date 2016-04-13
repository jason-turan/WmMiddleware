USE [NBXWEB]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertReturnReasonFromROWProcessing]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertReturnReasonFromROWProcessing]
(
	@rowId int,
	@ProcessedDate datetime
)
AS
INSERT INTO ReturnReasonFromROWProcessing(rowId, ProcessedDate)
                                       VALUES(@rowId, @ProcessedDate)
GO
