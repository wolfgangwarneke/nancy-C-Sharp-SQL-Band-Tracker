USE [band_tracker]
GO
/****** Object:  Table [dbo].[bands]    Script Date: 7/27/2016 8:47:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[bands](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](80) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[bands_venues]    Script Date: 7/27/2016 8:47:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bands_venues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[band_id] [int] NULL,
	[venue_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[venues]    Script Date: 7/27/2016 8:47:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[venues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](80) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[bands] ON 

INSERT [dbo].[bands] ([id], [name]) VALUES (8, N'The Pawlice')
INSERT [dbo].[bands] ([id], [name]) VALUES (9, N'Siamese Dream')
INSERT [dbo].[bands] ([id], [name]) VALUES (10, N'The Bengals')
INSERT [dbo].[bands] ([id], [name]) VALUES (11, N'The Technicolor Dream Cats')
INSERT [dbo].[bands] ([id], [name]) VALUES (12, N'Vet Shop Boys')
INSERT [dbo].[bands] ([id], [name]) VALUES (13, N'Cat Sabbath')
INSERT [dbo].[bands] ([id], [name]) VALUES (14, N'Meow Meow Meows')
INSERT [dbo].[bands] ([id], [name]) VALUES (15, N'DJ Meow Mix')
INSERT [dbo].[bands] ([id], [name]) VALUES (16, N'Catnip Stevens')
INSERT [dbo].[bands] ([id], [name]) VALUES (17, N'Purrs for Furs')
INSERT [dbo].[bands] ([id], [name]) VALUES (18, N'Meowlissa Etheridge')
INSERT [dbo].[bands] ([id], [name]) VALUES (19, N'Marilyn Meownson')
SET IDENTITY_INSERT [dbo].[bands] OFF
SET IDENTITY_INSERT [dbo].[venues] ON 

INSERT [dbo].[venues] ([id], [name]) VALUES (3, N'The Yarn Ballroom')
INSERT [dbo].[venues] ([id], [name]) VALUES (5, N'Meow That''s What I Call Mewsic')
INSERT [dbo].[venues] ([id], [name]) VALUES (6, N'Catty Shack')
INSERT [dbo].[venues] ([id], [name]) VALUES (7, N'The Litter Box')
INSERT [dbo].[venues] ([id], [name]) VALUES (8, N'The Lolcats Lounge')
SET IDENTITY_INSERT [dbo].[venues] OFF
