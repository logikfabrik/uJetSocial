CREATE TABLE [dbo].[uJetCommunityComment](
	[Id] [int] NOT NULL,
	[EntityId] [int] NOT NULL,
	[AuthorId] [int] NOT NULL,
	[Text] [nvarchar](max) NULL,
 CONSTRAINT [PK_uJetCommunityComment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[uJetCommunityComment]  ADD  CONSTRAINT [FK_uJetCommunityComment_uJetCommunityEntity] FOREIGN KEY([Id])
REFERENCES [dbo].[uJetCommunityEntity] ([Id])
GO

ALTER TABLE [dbo].[uJetCommunityComment] CHECK CONSTRAINT [FK_uJetCommunityComment_uJetCommunityEntity]
GO
ALTER TABLE [dbo].[uJetCommunityComment]  ADD  CONSTRAINT [FK_uJetCommunityComment_uJetCommunityEntity1] FOREIGN KEY([EntityId])
REFERENCES [dbo].[uJetCommunityEntity] ([Id])
GO

ALTER TABLE [dbo].[uJetCommunityComment] CHECK CONSTRAINT [FK_uJetCommunityComment_uJetCommunityEntity1]
GO
ALTER TABLE [dbo].[uJetCommunityComment]  ADD  CONSTRAINT [FK_uJetCommunityComment_uJetCommunityEntity2] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[uJetCommunityEntity] ([Id])
GO

ALTER TABLE [dbo].[uJetCommunityComment] CHECK CONSTRAINT [FK_uJetCommunityComment_uJetCommunityEntity2]