SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Player]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Player](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NickName] [varchar](24) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
 CONSTRAINT [PK_Player] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Game]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Game](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](64) NOT NULL,
	[Title] [varchar](128) NOT NULL CONSTRAINT [DF_Game_Title]  DEFAULT ('Game'),
 CONSTRAINT [PK_Game] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MatchEvent]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MatchEvent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [int] NOT NULL,
	[GameEventID] [int] NOT NULL,
	[MatchID] [int] NOT NULL,
	[PlayerID] [int] NOT NULL,
	[Score] [int] NOT NULL CONSTRAINT [DF_MatchEvent_Score]  DEFAULT ((0)),
 CONSTRAINT [PK_MatchEvent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MatchParticipant]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MatchParticipant](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MatchID] [int] NOT NULL,
	[PlayerID] [int] NOT NULL,
 CONSTRAINT [PK_MatchParticipant] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GameEvent]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[GameEvent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](64) NULL,
	[Score] [int] NOT NULL CONSTRAINT [DF_GameEvent_Score]  DEFAULT ((1)),
	[ScoreInterval] [int] NOT NULL CONSTRAINT [DF_GameEvent_ScoreInterval]  DEFAULT ((1)),
	[ScoreMax] [int] NULL,
	[GameID] [int] NOT NULL,
 CONSTRAINT [PK_GameEvent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Match]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Match](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GameID] [int] NOT NULL,
	[MatchDate] [datetime] NULL,
 CONSTRAINT [PK_Match] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MatchEvent_GameEvent]') AND parent_object_id = OBJECT_ID(N'[dbo].[MatchEvent]'))
ALTER TABLE [dbo].[MatchEvent]  WITH CHECK ADD  CONSTRAINT [FK_MatchEvent_GameEvent] FOREIGN KEY([GameEventID])
REFERENCES [dbo].[GameEvent] ([ID])
GO
ALTER TABLE [dbo].[MatchEvent] CHECK CONSTRAINT [FK_MatchEvent_GameEvent]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MatchEvent_Match]') AND parent_object_id = OBJECT_ID(N'[dbo].[MatchEvent]'))
ALTER TABLE [dbo].[MatchEvent]  WITH CHECK ADD  CONSTRAINT [FK_MatchEvent_Match] FOREIGN KEY([MatchID])
REFERENCES [dbo].[Match] ([ID])
GO
ALTER TABLE [dbo].[MatchEvent] CHECK CONSTRAINT [FK_MatchEvent_Match]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MatchEvent_Player]') AND parent_object_id = OBJECT_ID(N'[dbo].[MatchEvent]'))
ALTER TABLE [dbo].[MatchEvent]  WITH CHECK ADD  CONSTRAINT [FK_MatchEvent_Player] FOREIGN KEY([PlayerID])
REFERENCES [dbo].[Player] ([ID])
GO
ALTER TABLE [dbo].[MatchEvent] CHECK CONSTRAINT [FK_MatchEvent_Player]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MatchParticipant_Match]') AND parent_object_id = OBJECT_ID(N'[dbo].[MatchParticipant]'))
ALTER TABLE [dbo].[MatchParticipant]  WITH CHECK ADD  CONSTRAINT [FK_MatchParticipant_Match] FOREIGN KEY([MatchID])
REFERENCES [dbo].[Match] ([ID])
GO
ALTER TABLE [dbo].[MatchParticipant] CHECK CONSTRAINT [FK_MatchParticipant_Match]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MatchParticipant_Player]') AND parent_object_id = OBJECT_ID(N'[dbo].[MatchParticipant]'))
ALTER TABLE [dbo].[MatchParticipant]  WITH CHECK ADD  CONSTRAINT [FK_MatchParticipant_Player] FOREIGN KEY([PlayerID])
REFERENCES [dbo].[Player] ([ID])
GO
ALTER TABLE [dbo].[MatchParticipant] CHECK CONSTRAINT [FK_MatchParticipant_Player]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_GameEvent_Game]') AND parent_object_id = OBJECT_ID(N'[dbo].[GameEvent]'))
ALTER TABLE [dbo].[GameEvent]  WITH CHECK ADD  CONSTRAINT [FK_GameEvent_Game] FOREIGN KEY([GameID])
REFERENCES [dbo].[Game] ([ID])
GO
ALTER TABLE [dbo].[GameEvent] CHECK CONSTRAINT [FK_GameEvent_Game]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Match_Game]') AND parent_object_id = OBJECT_ID(N'[dbo].[Match]'))
ALTER TABLE [dbo].[Match]  WITH CHECK ADD  CONSTRAINT [FK_Match_Game] FOREIGN KEY([GameID])
REFERENCES [dbo].[Game] ([ID])
GO
ALTER TABLE [dbo].[Match] CHECK CONSTRAINT [FK_Match_Game]
