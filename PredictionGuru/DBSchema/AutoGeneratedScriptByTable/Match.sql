USE [PredictionGuru]
GO

/****** Object:  Table [dbo].[Match]    Script Date: 4/7/2018 2:57:27 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Match](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroundId] [int] NOT NULL,
	[HomeTeamId] [int] NOT NULL,
	[AwayTeamId] [int] NOT NULL,
	[StartUtcDate] [datetime] NOT NULL,
	[EndUtcDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Match] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Match]  WITH CHECK ADD  CONSTRAINT [FK_Match_Ground] FOREIGN KEY([GroundId])
REFERENCES [dbo].[Ground] ([Id])
GO

ALTER TABLE [dbo].[Match] CHECK CONSTRAINT [FK_Match_Ground]
GO

ALTER TABLE [dbo].[Match]  WITH CHECK ADD  CONSTRAINT [FK_Match_Team] FOREIGN KEY([HomeTeamId])
REFERENCES [dbo].[Team] ([Id])
GO

ALTER TABLE [dbo].[Match] CHECK CONSTRAINT [FK_Match_Team]
GO

ALTER TABLE [dbo].[Match]  WITH CHECK ADD  CONSTRAINT [FK_Match_Team1] FOREIGN KEY([AwayTeamId])
REFERENCES [dbo].[Team] ([Id])
GO

ALTER TABLE [dbo].[Match] CHECK CONSTRAINT [FK_Match_Team1]
GO


