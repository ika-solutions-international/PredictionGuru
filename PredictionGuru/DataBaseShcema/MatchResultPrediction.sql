USE [PredictionGuru]
GO

/****** Object:  Table [dbo].[MatchResultPrediction]    Script Date: 4/7/2018 2:57:57 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MatchResultPrediction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MatchId] [int] NOT NULL,
	[WinningTeamId] [int] NULL,
	[LosingTeamId] [int] NULL,
	[IsDrawn] [bit] NOT NULL,
	[PredictorUserId] [int] NOT NULL,
 CONSTRAINT [PK_MatchResultPrediction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MatchResultPrediction]  WITH CHECK ADD  CONSTRAINT [FK_MatchResultPrediction_Match] FOREIGN KEY([MatchId])
REFERENCES [dbo].[Match] ([Id])
GO

ALTER TABLE [dbo].[MatchResultPrediction] CHECK CONSTRAINT [FK_MatchResultPrediction_Match]
GO

ALTER TABLE [dbo].[MatchResultPrediction]  WITH CHECK ADD  CONSTRAINT [FK_MatchResultPrediction_Team] FOREIGN KEY([WinningTeamId])
REFERENCES [dbo].[Team] ([Id])
GO

ALTER TABLE [dbo].[MatchResultPrediction] CHECK CONSTRAINT [FK_MatchResultPrediction_Team]
GO

ALTER TABLE [dbo].[MatchResultPrediction]  WITH CHECK ADD  CONSTRAINT [FK_MatchResultPrediction_Team1] FOREIGN KEY([LosingTeamId])
REFERENCES [dbo].[Team] ([Id])
GO

ALTER TABLE [dbo].[MatchResultPrediction] CHECK CONSTRAINT [FK_MatchResultPrediction_Team1]
GO

ALTER TABLE [dbo].[MatchResultPrediction]  WITH CHECK ADD  CONSTRAINT [FK_MatchResultPrediction_UserProfile] FOREIGN KEY([PredictorUserId])
REFERENCES [dbo].[UserProfile] ([Id])
GO

ALTER TABLE [dbo].[MatchResultPrediction] CHECK CONSTRAINT [FK_MatchResultPrediction_UserProfile]
GO


