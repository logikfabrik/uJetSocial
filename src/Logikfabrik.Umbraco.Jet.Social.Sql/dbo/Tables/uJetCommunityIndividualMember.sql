CREATE TABLE [dbo].[uJetCommunityIndividualMember](
	[Id] [int] NOT NULL,
	[MemberId] [int] NOT NULL,
 CONSTRAINT [PK_uJetCommunityIndividualMember] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[uJetCommunityIndividualMember]  ADD  CONSTRAINT [FK_uJetCommunityIndividualMember_uJetCommunityEntity] FOREIGN KEY([Id])
REFERENCES [dbo].[uJetCommunityEntity] ([Id])
GO

ALTER TABLE [dbo].[uJetCommunityIndividualMember] CHECK CONSTRAINT [FK_uJetCommunityIndividualMember_uJetCommunityEntity]
GO
ALTER TABLE [dbo].[uJetCommunityIndividualMember]  ADD  CONSTRAINT [FK_uJetCommunityIndividualMember_uJetCommunityEntity1] FOREIGN KEY([MemberId])
REFERENCES [dbo].[uJetCommunityEntity] ([Id])
GO

ALTER TABLE [dbo].[uJetCommunityIndividualMember] CHECK CONSTRAINT [FK_uJetCommunityIndividualMember_uJetCommunityEntity1]