USE [NBXWEB]
GO
/****** Object:  Table [dbo].[TempMock_v_ReturnReasonsfromROW]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TempMock_v_ReturnReasonsfromROW](
	[rowID] [int] NOT NULL,
	[order_number] [varchar](12) NULL,
	[style_number] [nvarchar](16) NOT NULL,
	[prod_size] [nvarchar](4) NOT NULL,
	[attribute] [nvarchar](8) NULL,
	[UPC] [nvarchar](16) NULL,
	[return_reason] [nvarchar](20) NULL,
	[additional_return_reason] [nvarchar](100) NULL,
	[to_be_exchange] [varchar](14) NOT NULL,
	[row_submit_date] [datetime] NOT NULL,
	[tracking] [nvarchar](50) NULL,
	[current_item_status] [varchar](9) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
