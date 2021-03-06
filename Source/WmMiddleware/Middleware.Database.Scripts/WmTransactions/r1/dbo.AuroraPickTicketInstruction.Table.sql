USE [WMTransactions]
GO
/****** Object:  Table [dbo].[AuroraPickTicketInstruction]    Script Date: 2/25/2016 1:50:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuroraPickTicketInstruction](
	[AuroraPickTicketInstructionId] [int] IDENTITY(1,1) NOT NULL,
	[ErrorSequence] [nvarchar](9) NULL,
	[BatchControlNumber] [nvarchar](10) NULL,
	[DateCreated] [nvarchar](9) NULL,
	[TimeCreated] [nvarchar](7) NULL,
	[UserId] [nvarchar](10) NULL,
	[PickticketControlNumber] [nvarchar](10) NULL,
	[PickticketLineNumber] [nvarchar](5) NULL,
	[SpecialInstructionNumber] [nvarchar](3) NULL,
	[SpecialInstructionType] [nvarchar](2) NULL,
	[SpecialInstructionCode] [nvarchar](2) NULL,
	[SpecialInstructionDescription] [nvarchar](100) NULL,
	[RecordExpansionField] [nvarchar](30) NULL,
	[CustomRecordExpansionField] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[AuroraPickTicketInstructionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
