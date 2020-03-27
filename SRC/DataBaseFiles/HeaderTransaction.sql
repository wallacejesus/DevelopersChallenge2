USE [nibo]
GO

/****** Object:  Table [dbo].[HeaderTransaction]    Script Date: 26/03/2020 02:31:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[HeaderTransaction](
	[IdHeader] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[DateStart] [datetime] NOT NULL,
	[DateEnd] [datetime] NOT NULL,
	[RegistrationDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdHeader] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [uk_HeaderTransactionFile] UNIQUE NONCLUSTERED 
(
	[DateStart] ASC,
	[DateEnd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
