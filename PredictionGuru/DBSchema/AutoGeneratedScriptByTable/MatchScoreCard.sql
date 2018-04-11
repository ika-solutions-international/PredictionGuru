USE [PredictionGuru]
GO

/****** Object:  Table [dbo].[MatchScoreCard]    Script Date: 4/7/2018 2:58:11 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MatchScoreCard](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MatchId] [int] NOT NULL,
	[PlayerId] [int] NOT NULL,
	[TeamId] [int] NOT NULL,
	[ScoreUtcTime] [datetime] NOT NULL,
 CONSTRAINT [PK_MatchScoreCard] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MatchScoreCard]  WITH CHECK ADD  CONSTRAINT [FK_MatchScoreCard_Match] FOREIGN KEY([MatchId])
REFERENCES [dbo].[Match] ([Id])
GO

ALTER TABLE [dbo].[MatchScoreCard] CHECK CONSTRAINT [FK_MatchScoreCard_Match]
GO

ALTER TABLE [dbo].[MatchScoreCard]  WITH CHECK ADD  CONSTRAINT [FK_MatchScoreCard_PlayerProfile] FOREIGN KEY([PlayerId])
REFERENCES [dbo].[PlayerProfile] ([Id])
GO

ALTER TABLE [dbo].[MatchScoreCard] CHECK CONSTRAINT [FK_MatchScoreCard_PlayerProfile]
GO

ALTER TABLE [dbo].[MatchScoreCard]  WITH CHECK ADD  CONSTRAINT [FK_MatchScoreCard_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([Id])
GO

ALTER TABLE [dbo].[MatchScoreCard] CHECK CONSTRAINT [FK_MatchScoreCard_Team]
GO


