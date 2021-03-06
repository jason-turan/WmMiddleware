USE [WMTransactions]
GO
/****** Object:  Table [dbo].[ManhattanInventorySync]    Script Date: 2/25/2016 1:50:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManhattanInventorySync](
	[ManhattanInventorySyncId] [int] IDENTITY(1,1) NOT NULL,
	[ProcessedDate] [nvarchar](9) NULL,
	[ProcessedTime] [nvarchar](7) NULL,
	[DateCreated] [nvarchar](9) NULL,
	[TimeCreated] [nvarchar](7) NULL,
	[TransactionNumber] [nvarchar](9) NULL,
	[SequenceNumber] [nvarchar](5) NULL,
	[Warehouse] [nvarchar](3) NULL,
	[Company] [nvarchar](10) NULL,
	[Division] [nvarchar](10) NULL,
	[SeasonYear] [nvarchar](2) NULL,
	[Style] [nvarchar](8) NULL,
	[Color] [nvarchar](4) NULL,
	[SecDimension] [nvarchar](3) NULL,
	[SkuAttribute1] [nvarchar](1) NULL,
	[SkuAttribute2] [nvarchar](1) NULL,
	[SkuAttribute3] [nvarchar](1) NULL,
	[SkuAttribute4] [nvarchar](1) NULL,
	[SkuAttribute5] [nvarchar](1) NULL,
	[HostInventoryBucket] [nvarchar](25) NULL,
	[WarehouseQuantity] [decimal](15, 4) NULL,
	[InventoryAdjustmntType] [nvarchar](1) NULL,
	[MiscellaneousChar1] [nvarchar](20) NULL,
	[MiscellaneousChar2] [nvarchar](20) NULL,
	[MiscellaneousChar3] [nvarchar](20) NULL,
	[MiscellaneousNumber1] [decimal](13, 5) NULL,
	[MiscellaneousNumber2] [decimal](13, 5) NULL,
	[MiscellaneousNumber3] [decimal](13, 5) NULL,
	[RecordExpansionField] [nvarchar](20) NULL,
	[CustomRecordExpansionField] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ManhattanInventorySyncId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
