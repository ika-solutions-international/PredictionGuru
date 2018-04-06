USE [PredictionGuru]
GO

/****** Object:  Table [dbo].[Team]    Script Date: 4/7/2018 2:59:02 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Team](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NOT NULL,
	[TypeId] [int] NOT NULL,
	[Name] [varchar](max) NOT NULL,
	[Picture] [varchar](max) NULL,
 CONSTRAINT [PK_Team] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Team]  WITH CHECK ADD  CONSTRAINT [FK_Team_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO

ALTER TABLE [dbo].[Team] CHECK CONSTRAINT [FK_Team_Country]
GO

ALTER TABLE [dbo].[Team]  WITH CHECK ADD  CONSTRAINT [FK_Team_TeamType] FOREIGN KEY([TypeId])
REFERENCES [dbo].[TeamType] ([Id])
GO

ALTER TABLE [dbo].[Team] CHECK CONSTRAINT [FK_Team_TeamType]
GO


