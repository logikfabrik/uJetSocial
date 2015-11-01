CREATE TABLE [dbo].[uJetSocialContact](
	[Id] [int] NOT NULL,
	[FromId] [int] NOT NULL,
	[ToId] [int] NOT NULL,
 CONSTRAINT [PK_uJetSocialContact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[uJetSocialContact]  ADD  CONSTRAINT [FK_uJetSocialContact_uJetSocialEntity] FOREIGN KEY([Id])
REFERENCES [dbo].[uJetSocialEntity] ([Id])
GO

ALTER TABLE [dbo].[uJetSocialContact] CHECK CONSTRAINT [FK_uJetSocialContact_uJetSocialEntity]
GO
ALTER TABLE [dbo].[uJetSocialContact]  ADD  CONSTRAINT [FK_uJetSocialContact_uJetSocialEntity1] FOREIGN KEY([FromId])
REFERENCES [dbo].[uJetSocialEntity] ([Id])
GO

ALTER TABLE [dbo].[uJetSocialContact] CHECK CONSTRAINT [FK_uJetSocialContact_uJetSocialEntity1]
GO
ALTER TABLE [dbo].[uJetSocialContact]  ADD  CONSTRAINT [FK_uJetSocialContact_uJetSocialEntity2] FOREIGN KEY([ToId])
REFERENCES [dbo].[uJetSocialEntity] ([Id])
GO

ALTER TABLE [dbo].[uJetSocialContact] CHECK CONSTRAINT [FK_uJetSocialContact_uJetSocialEntity2]
