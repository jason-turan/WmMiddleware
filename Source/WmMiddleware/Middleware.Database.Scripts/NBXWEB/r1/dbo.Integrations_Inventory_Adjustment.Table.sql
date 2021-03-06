USE [NBXWEB]
GO
/****** Object:  Table [dbo].[Integrations_Inventory_Adjustment]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Integrations_Inventory_Adjustment](
	[record_id] [bigint] IDENTITY(1,1) NOT NULL,
	[batch_id] [nvarchar](15) NOT NULL,
	[batch_source] [nvarchar](50) NULL,
	[batch_create_dt] [datetime] NOT NULL,
	[created_date] [datetime] NOT NULL,
	[item_key_id] [nvarchar](50) NOT NULL,
	[UOM] [nvarchar](50) NOT NULL,
	[qty] [int] NOT NULL,
	[inventory_variance_date] [datetime] NOT NULL,
	[gl_account] [varchar](13) NULL,
	[variance_account] [varchar](13) NULL,
	[reason_code] [nvarchar](50) NULL,
	[IntegrationStatus] [nvarchar](30) NOT NULL CONSTRAINT [DF_Integrations_Inventory_Adjustment_IntegrationStatus]  DEFAULT (N'NEW'),
	[IntegrationMessage] [nvarchar](500) NULL,
	[IntegrationDT] [datetime] NULL,
	[IntegrationBatchID] [nvarchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
