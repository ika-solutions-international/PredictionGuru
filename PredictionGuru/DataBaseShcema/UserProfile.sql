USE [PredictionGuru]
GO

/****** Object:  Table [dbo].[UserProfile]    Script Date: 4/7/2018 2:59:24 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserProfile](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](max) NOT NULL,
	[Password] [varchar](max) NOT NULL,
	[PasswordSalt] [varchar](max) NOT NULL,
	[FirstName] [varchar](max) NULL,
	[LastName] [varchar](max) NULL,
	[JoinUtcDate] [datetime] NOT NULL,
	[Gender] [varchar](max) NULL,
 CONSTRAINT [PK_UserProfile] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


