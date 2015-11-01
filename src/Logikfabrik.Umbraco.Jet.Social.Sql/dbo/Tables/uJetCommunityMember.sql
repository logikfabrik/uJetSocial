CREATE TABLE [dbo].[uJetCommunityMember](
	[Id] [int] NOT NULL,
	[ProviderUserKey] [int] NOT NULL,
 CONSTRAINT [PK_uJetCommunityMember] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[uJetCommunityMember]  ADD  CONSTRAINT [FK_uJetCommunityMember_uJetCommunityEntity] FOREIGN KEY([Id])
REFERENCES [dbo].[uJetCommunityEntity] ([Id])
GO

ALTER TABLE [dbo].[uJetCommunityMember] CHECK CONSTRAINT [FK_uJetCommunityMember_uJetCommunityEntity]