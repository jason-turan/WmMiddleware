USE [NBXWEB]
GO
/****** Object:  View [dbo].[v_ReturnReasonsfromROW]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE VIEW [dbo].[v_ReturnReasonsfromROW]

AS

SELECT [rowID]
      ,[order_number]
      ,[style_number]
      ,[prod_size]
      ,[attribute]
      ,[UPC]
      ,[return_reason]
      ,[additional_return_reason]
      ,[to_be_exchange]
      ,[row_submit_date]
      ,[tracking]
      ,[current_item_status]
  FROM [STLSQLPRD02].[DataRevolution].[dbo].[v_ReturnReasonsFromROW]




GO
