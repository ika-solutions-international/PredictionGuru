USE [PredictionGuru]
GO

/****** Object:  Table [dbo].[PlayerForTeam]    Script Date: 4/7/2018 2:58:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PlayerForTeam](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PlayerId] [int] NOT NULL,
	[TeamId] [int] NOT NULL,
	[PositionId] [int] NOT NULL,
	[JerseyNumber] [varchar](max) NULL,
	[Picture] [varchar](max) NULL,
 CONSTRAINT [PK_PlayerForTeam] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[PlayerForTeam]  WITH CHECK ADD  CONSTRAINT [FK_PlayerForTeam_PlayerProfile] FOREIGN KEY([PlayerId])
REFERENCES [dbo].[PlayerProfile] ([Id])
GO

ALTER TABLE [dbo].[PlayerForTeam] CHECK CONSTRAINT [FK_PlayerForTeam_PlayerProfile]
GO

ALTER TABLE [dbo].[PlayerForTeam]  WITH CHECK ADD  CONSTRAINT [FK_PlayerForTeam_PlayingPosition] FOREIGN KEY([PositionId])
REFERENCES [dbo].[PlayingPosition] ([Id])
GO

ALTER TABLE [dbo].[PlayerForTeam] CHECK CONSTRAINT [FK_PlayerForTeam_PlayingPosition]
GO

ALTER TABLE [dbo].[PlayerForTeam]  WITH CHECK ADD  CONSTRAINT [FK_PlayerForTeam_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([Id])
GO

ALTER TABLE [dbo].[PlayerForTeam] CHECK CONSTRAINT [FK_PlayerForTeam_Team]
GO


