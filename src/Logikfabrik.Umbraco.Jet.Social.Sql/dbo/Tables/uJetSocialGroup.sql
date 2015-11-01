CREATE TABLE [dbo].[uJetSocialGroup](
	[Id] [int] NOT NULL,
	[OwnerId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_uJetSocialGroup_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[uJetSocialGroup]  ADD  CONSTRAINT [FK_uJetSocialGroup_uJetSocialEntity] FOREIGN KEY([Id])
REFERENCES [dbo].[uJetSocialEntity] ([Id])
GO

ALTER TABLE [dbo].[uJetSocialGroup] CHECK CONSTRAINT [FK_uJetSocialGroup_uJetSocialEntity]
GO
ALTER TABLE [dbo].[uJetSocialGroup]  ADD  CONSTRAINT [FK_uJetSocialGroup_uJetSocialEntity1] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[uJetSocialEntity] ([Id])
GO

ALTER TABLE [dbo].[uJetSocialGroup] CHECK CONSTRAINT [FK_uJetSocialGroup_uJetSocialEntity1]
