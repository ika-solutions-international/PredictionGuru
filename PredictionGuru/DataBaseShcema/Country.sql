USE [PredictionGuru]
GO

/****** Object:  Table [dbo].[Country]    Script Date: 4/7/2018 2:56:48 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContinentId] [int] NOT NULL,
	[Name] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Country]  WITH CHECK ADD  CONSTRAINT [FK_Country_Continent] FOREIGN KEY([ContinentId])
REFERENCES [dbo].[Continent] ([Id])
GO

ALTER TABLE [dbo].[Country] CHECK CONSTRAINT [FK_Country_Continent]
GO


