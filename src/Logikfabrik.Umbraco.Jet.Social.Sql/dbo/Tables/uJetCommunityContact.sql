CREATE TABLE [dbo].[uJetCommunityContact](
	[Id] [int] NOT NULL,
	[FromId] [int] NOT NULL,
	[ToId] [int] NOT NULL,
 CONSTRAINT [PK_uJetCommunityContact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[uJetCommunityContact]  ADD  CONSTRAINT [FK_uJetCommunityContact_uJetCommunityEntity] FOREIGN KEY([Id])
REFERENCES [dbo].[uJetCommunityEntity] ([Id])
GO

ALTER TABLE [dbo].[uJetCommunityContact] CHECK CONSTRAINT [FK_uJetCommunityContact_uJetCommunityEntity]
GO
ALTER TABLE [dbo].[uJetCommunityContact]  ADD  CONSTRAINT [FK_uJetCommunityContact_uJetCommunityEntity1] FOREIGN KEY([FromId])
REFERENCES [dbo].[uJetCommunityEntity] ([Id])
GO

ALTER TABLE [dbo].[uJetCommunityContact] CHECK CONSTRAINT [FK_uJetCommunityContact_uJetCommunityEntity1]
GO
ALTER TABLE [dbo].[uJetCommunityContact]  ADD  CONSTRAINT [FK_uJetCommunityContact_uJetCommunityEntity2] FOREIGN KEY([ToId])
REFERENCES [dbo].[uJetCommunityEntity] ([Id])
GO

ALTER TABLE [dbo].[uJetCommunityContact] CHECK CONSTRAINT [FK_uJetCommunityContact_uJetCommunityEntity2]