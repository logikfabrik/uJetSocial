CREATE TABLE [dbo].[uJetSocialGroupMembership](
	[Id] [int] NOT NULL,
	[GroupId] [int] NOT NULL,
	[MemberId] [int] NOT NULL,
 CONSTRAINT [PK_uJetSocialGroupMembership] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[uJetSocialGroupMembership]  ADD  CONSTRAINT [FK_uJetSocialGroupMembership_uJetSocialEntity] FOREIGN KEY([Id])
REFERENCES [dbo].[uJetSocialEntity] ([Id])
GO

ALTER TABLE [dbo].[uJetSocialGroupMembership] CHECK CONSTRAINT [FK_uJetSocialGroupMembership_uJetSocialEntity]
GO
ALTER TABLE [dbo].[uJetSocialGroupMembership]  ADD  CONSTRAINT [FK_uJetSocialGroupMembership_uJetSocialEntity1] FOREIGN KEY([GroupId])
REFERENCES [dbo].[uJetSocialEntity] ([Id])
GO

ALTER TABLE [dbo].[uJetSocialGroupMembership] CHECK CONSTRAINT [FK_uJetSocialGroupMembership_uJetSocialEntity1]
GO
ALTER TABLE [dbo].[uJetSocialGroupMembership]  ADD  CONSTRAINT [FK_uJetSocialGroupMembership_uJetSocialEntity2] FOREIGN KEY([MemberId])
REFERENCES [dbo].[uJetSocialEntity] ([Id])
GO

ALTER TABLE [dbo].[uJetSocialGroupMembership] CHECK CONSTRAINT [FK_uJetSocialGroupMembership_uJetSocialEntity2]
