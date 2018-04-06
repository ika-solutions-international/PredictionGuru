USE [PredictionGuru]
GO

/****** Object:  Table [dbo].[Ground]    Script Date: 4/7/2018 2:56:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Ground](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NOT NULL,
	[Name] [varchar](max) NOT NULL,
	[Picture] [varchar](max) NULL,
 CONSTRAINT [PK_Ground] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Ground]  WITH CHECK ADD  CONSTRAINT [FK_Ground_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO

ALTER TABLE [dbo].[Ground] CHECK CONSTRAINT [FK_Ground_Country]
GO


