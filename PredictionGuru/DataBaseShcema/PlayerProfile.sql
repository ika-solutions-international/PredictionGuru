USE [PredictionGuru]
GO

/****** Object:  Table [dbo].[PlayerProfile]    Script Date: 4/7/2018 2:58:43 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PlayerProfile](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NOT NULL,
	[Name] [varchar](max) NOT NULL,
 CONSTRAINT [PK_PlayerProfile] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[PlayerProfile]  WITH CHECK ADD  CONSTRAINT [FK_PlayerProfile_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO

ALTER TABLE [dbo].[PlayerProfile] CHECK CONSTRAINT [FK_PlayerProfile_Country]
GO


