USE [PredictionGuru]
GO

/****** Object:  Table [dbo].[MatchResult]    Script Date: 4/7/2018 2:57:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MatchResult](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MatchId] [int] NOT NULL,
	[WinningTeamId] [int] NULL,
	[LosingTeamId] [int] NULL,
	[IsDrawn] [bit] NOT NULL,
	[MOMPlayerId] [int] NOT NULL,
 CONSTRAINT [PK_MatchResult] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MatchResult]  WITH CHECK ADD  CONSTRAINT [FK_MatchResult_Match] FOREIGN KEY([MatchId])
REFERENCES [dbo].[Match] ([Id])
GO

ALTER TABLE [dbo].[MatchResult] CHECK CONSTRAINT [FK_MatchResult_Match]
GO

ALTER TABLE [dbo].[MatchResult]  WITH CHECK ADD  CONSTRAINT [FK_MatchResult_PlayerProfile] FOREIGN KEY([MOMPlayerId])
REFERENCES [dbo].[PlayerProfile] ([Id])
GO

ALTER TABLE [dbo].[MatchResult] CHECK CONSTRAINT [FK_MatchResult_PlayerProfile]
GO

ALTER TABLE [dbo].[MatchResult]  WITH CHECK ADD  CONSTRAINT [FK_MatchResult_Team] FOREIGN KEY([WinningTeamId])
REFERENCES [dbo].[Team] ([Id])
GO

ALTER TABLE [dbo].[MatchResult] CHECK CONSTRAINT [FK_MatchResult_Team]
GO

ALTER TABLE [dbo].[MatchResult]  WITH CHECK ADD  CONSTRAINT [FK_MatchResult_Team1] FOREIGN KEY([LosingTeamId])
REFERENCES [dbo].[Team] ([Id])
GO

ALTER TABLE [dbo].[MatchResult] CHECK CONSTRAINT [FK_MatchResult_Team1]
GO


