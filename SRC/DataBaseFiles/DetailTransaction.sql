USE [nibo]
GO

/****** Object:  Table [dbo].[DetailTransaction]    Script Date: 26/03/2020 02:31:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DetailTransaction](
	[IdDetail] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Type] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Value] [numeric](14, 2) NOT NULL,
	[IdHeader] [int] NOT NULL,
	[Detail] [varchar](300) NULL,
	[RegistrationDate] [datetime] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[DetailTransaction]  WITH CHECK ADD  CONSTRAINT [fk_Transaction] FOREIGN KEY([IdHeader])
REFERENCES [dbo].[HeaderTransaction] ([IdHeader])
GO

ALTER TABLE [dbo].[DetailTransaction] CHECK CONSTRAINT [fk_Transaction]
GO

