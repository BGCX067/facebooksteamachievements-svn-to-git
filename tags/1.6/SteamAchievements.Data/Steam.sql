USE [Steam]
GO
/****** Object:  ForeignKey [FK_steam_Achievement_steam_Game]    Script Date: 06/02/2010 21:34:15 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_steam_Achievement_steam_Game]') AND parent_object_id = OBJECT_ID(N'[dbo].[steam_Achievement]'))
ALTER TABLE [dbo].[steam_Achievement] DROP CONSTRAINT [FK_steam_Achievement_steam_Game]
GO
/****** Object:  ForeignKey [FK_steam_UserAchievement_steam_Achievement1]    Script Date: 06/02/2010 21:34:15 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_steam_UserAchievement_steam_Achievement1]') AND parent_object_id = OBJECT_ID(N'[dbo].[steam_UserAchievement]'))
ALTER TABLE [dbo].[steam_UserAchievement] DROP CONSTRAINT [FK_steam_UserAchievement_steam_Achievement1]
GO
/****** Object:  ForeignKey [FK_steam_UserAchievement_steam_User]    Script Date: 06/02/2010 21:34:15 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_steam_UserAchievement_steam_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[steam_UserAchievement]'))
ALTER TABLE [dbo].[steam_UserAchievement] DROP CONSTRAINT [FK_steam_UserAchievement_steam_User]
GO
/****** Object:  Table [dbo].[steam_UserAchievement]    Script Date: 06/02/2010 21:34:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[steam_UserAchievement]') AND type in (N'U'))
DROP TABLE [dbo].[steam_UserAchievement]
GO
/****** Object:  Table [dbo].[steam_Achievement]    Script Date: 06/02/2010 21:34:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[steam_Achievement]') AND type in (N'U'))
DROP TABLE [dbo].[steam_Achievement]
GO
/****** Object:  Table [dbo].[steam_Game]    Script Date: 06/02/2010 21:34:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[steam_Game]') AND type in (N'U'))
DROP TABLE [dbo].[steam_Game]
GO
/****** Object:  Table [dbo].[steam_User]    Script Date: 06/02/2010 21:34:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[steam_User]') AND type in (N'U'))
DROP TABLE [dbo].[steam_User]
GO
/****** Object:  Table [dbo].[steam_User]    Script Date: 06/02/2010 21:34:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[steam_User]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[steam_User](
	[FacebookUserId] [bigint] NOT NULL,
	[SteamUserId] [varchar](50) NOT NULL,
 CONSTRAINT [PK_steam_User] PRIMARY KEY CLUSTERED 
(
	[FacebookUserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[steam_Game]    Script Date: 06/02/2010 21:34:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[steam_Game]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[steam_Game](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Abbreviation] [varchar](30) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[ImageUrl] [varchar](250) NOT NULL,
 CONSTRAINT [PK_steam_Game] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[steam_Achievement]    Script Date: 06/02/2010 21:34:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[steam_Achievement]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[steam_Achievement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[GameId] [int] NOT NULL,
	[Description] [varchar](500) NOT NULL,
	[ImageUrl] [varchar](250) NOT NULL,
 CONSTRAINT [PK_steam_Achievement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[steam_UserAchievement]    Script Date: 06/02/2010 21:34:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[steam_UserAchievement]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[steam_UserAchievement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SteamUserId] [varchar](50) NOT NULL,
	[AchievementId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_steam_UserAchievement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_steam_Achievement_steam_Game]    Script Date: 06/02/2010 21:34:15 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_steam_Achievement_steam_Game]') AND parent_object_id = OBJECT_ID(N'[dbo].[steam_Achievement]'))
ALTER TABLE [dbo].[steam_Achievement]  WITH CHECK ADD  CONSTRAINT [FK_steam_Achievement_steam_Game] FOREIGN KEY([GameId])
REFERENCES [dbo].[steam_Game] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_steam_Achievement_steam_Game]') AND parent_object_id = OBJECT_ID(N'[dbo].[steam_Achievement]'))
ALTER TABLE [dbo].[steam_Achievement] CHECK CONSTRAINT [FK_steam_Achievement_steam_Game]
GO
/****** Object:  ForeignKey [FK_steam_UserAchievement_steam_Achievement1]    Script Date: 06/02/2010 21:34:15 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_steam_UserAchievement_steam_Achievement1]') AND parent_object_id = OBJECT_ID(N'[dbo].[steam_UserAchievement]'))
ALTER TABLE [dbo].[steam_UserAchievement]  WITH CHECK ADD  CONSTRAINT [FK_steam_UserAchievement_steam_Achievement1] FOREIGN KEY([AchievementId])
REFERENCES [dbo].[steam_Achievement] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_steam_UserAchievement_steam_Achievement1]') AND parent_object_id = OBJECT_ID(N'[dbo].[steam_UserAchievement]'))
ALTER TABLE [dbo].[steam_UserAchievement] CHECK CONSTRAINT [FK_steam_UserAchievement_steam_Achievement1]
GO
/****** Object:  ForeignKey [FK_steam_UserAchievement_steam_User]    Script Date: 06/02/2010 21:34:15 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_steam_UserAchievement_steam_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[steam_UserAchievement]'))
ALTER TABLE [dbo].[steam_UserAchievement]  WITH CHECK ADD  CONSTRAINT [FK_steam_UserAchievement_steam_User] FOREIGN KEY([SteamUserId])
REFERENCES [dbo].[steam_User] ([SteamUserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_steam_UserAchievement_steam_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[steam_UserAchievement]'))
ALTER TABLE [dbo].[steam_UserAchievement] CHECK CONSTRAINT [FK_steam_UserAchievement_steam_User]
GO
