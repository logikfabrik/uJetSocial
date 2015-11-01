CREATE TABLE [dbo].[uJetCommunityGroupMembership](
	[Id] [int] NOT NULL,
	[GroupId] [int] NOT NULL,
	[MemberId] [int] NOT NULL,
 CONSTRAINT [PK_uJetCommunityGroupMembership] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[uJetCommunityGroupMembership]  ADD  CONSTRAINT [FK_uJetCommunityGroupMembership_uJetCommunityEntity] FOREIGN KEY([Id])
REFERENCES [dbo].[uJetCommunityEntity] ([Id])
GO

ALTER TABLE [dbo].[uJetCommunityGroupMembership] CHECK CONSTRAINT [FK_uJetCommunityGroupMembership_uJetCommunityEntity]
GO
ALTER TABLE [dbo].[uJetCommunityGroupMembership]  ADD  CONSTRAINT [FK_uJetCommunityGroupMembership_uJetCommunityEntity1] FOREIGN KEY([GroupId])
REFERENCES [dbo].[uJetCommunityEntity] ([Id])
GO

ALTER TABLE [dbo].[uJetCommunityGroupMembership] CHECK CONSTRAINT [FK_uJetCommunityGroupMembership_uJetCommunityEntity1]
GO
ALTER TABLE [dbo].[uJetCommunityGroupMembership]  ADD  CONSTRAINT [FK_uJetCommunityGroupMembership_uJetCommunityEntity2] FOREIGN KEY([MemberId])
REFERENCES [dbo].[uJetCommunityEntity] ([Id])
GO

ALTER TABLE [dbo].[uJetCommunityGroupMembership] CHECK CONSTRAINT [FK_uJetCommunityGroupMembership_uJetCommunityEntity2]