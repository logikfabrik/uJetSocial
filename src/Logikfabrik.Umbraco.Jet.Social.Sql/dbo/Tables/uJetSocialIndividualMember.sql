CREATE TABLE [dbo].[uJetSocialIndividualMember](
	[Id] [int] NOT NULL,
	[MemberId] [int] NOT NULL,
 CONSTRAINT [PK_uJetSocialIndividualMember] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[uJetSocialIndividualMember]  ADD  CONSTRAINT [FK_uJetSocialIndividualMember_uJetSocialEntity] FOREIGN KEY([Id])
REFERENCES [dbo].[uJetSocialEntity] ([Id])
GO

ALTER TABLE [dbo].[uJetSocialIndividualMember] CHECK CONSTRAINT [FK_uJetSocialIndividualMember_uJetSocialEntity]
GO
ALTER TABLE [dbo].[uJetSocialIndividualMember]  ADD  CONSTRAINT [FK_uJetSocialIndividualMember_uJetSocialEntity1] FOREIGN KEY([MemberId])
REFERENCES [dbo].[uJetSocialEntity] ([Id])
GO

ALTER TABLE [dbo].[uJetSocialIndividualMember] CHECK CONSTRAINT [FK_uJetSocialIndividualMember_uJetSocialEntity1]
