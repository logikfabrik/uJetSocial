CREATE TABLE [dbo].[uJetSocialReport](
	[Id] [int] NOT NULL,
	[EntityId] [int] NOT NULL,
	[AuthorId] [int] NOT NULL,
	[Text] [nvarchar](max) NULL,
 CONSTRAINT [PK_uJetSocialReport] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[uJetSocialReport]  ADD  CONSTRAINT [FK_uJetSocialReport_uJetSocialEntity] FOREIGN KEY([Id])
REFERENCES [dbo].[uJetSocialEntity] ([Id])
GO

ALTER TABLE [dbo].[uJetSocialReport] CHECK CONSTRAINT [FK_uJetSocialReport_uJetSocialEntity]
GO
ALTER TABLE [dbo].[uJetSocialReport]  ADD  CONSTRAINT [FK_uJetSocialReport_uJetSocialEntity1] FOREIGN KEY([EntityId])
REFERENCES [dbo].[uJetSocialEntity] ([Id])
GO

ALTER TABLE [dbo].[uJetSocialReport] CHECK CONSTRAINT [FK_uJetSocialReport_uJetSocialEntity1]
GO
ALTER TABLE [dbo].[uJetSocialReport]  ADD  CONSTRAINT [FK_uJetSocialReport_uJetSocialEntity2] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[uJetSocialEntity] ([Id])
GO

ALTER TABLE [dbo].[uJetSocialReport] CHECK CONSTRAINT [FK_uJetSocialReport_uJetSocialEntity2]
