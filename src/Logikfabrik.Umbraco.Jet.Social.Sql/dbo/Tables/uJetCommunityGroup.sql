CREATE TABLE [dbo].[uJetCommunityGroup](
	[Id] [int] NOT NULL,
	[OwnerId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_uJetCommunityGroup_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[uJetCommunityGroup]  ADD  CONSTRAINT [FK_uJetCommunityGroup_uJetCommunityEntity] FOREIGN KEY([Id])
REFERENCES [dbo].[uJetCommunityEntity] ([Id])
GO

ALTER TABLE [dbo].[uJetCommunityGroup] CHECK CONSTRAINT [FK_uJetCommunityGroup_uJetCommunityEntity]
GO
ALTER TABLE [dbo].[uJetCommunityGroup]  ADD  CONSTRAINT [FK_uJetCommunityGroup_uJetCommunityEntity1] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[uJetCommunityEntity] ([Id])
GO

ALTER TABLE [dbo].[uJetCommunityGroup] CHECK CONSTRAINT [FK_uJetCommunityGroup_uJetCommunityEntity1]