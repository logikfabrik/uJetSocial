CREATE TABLE [dbo].[uJetSocialMember](
	[Id] [int] NOT NULL,
	[ProviderUserKey] [int] NOT NULL,
 CONSTRAINT [PK_uJetSocialMember] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[uJetSocialMember]  ADD  CONSTRAINT [FK_uJetSocialMember_uJetSocialEntity] FOREIGN KEY([Id])
REFERENCES [dbo].[uJetSocialEntity] ([Id])
GO

ALTER TABLE [dbo].[uJetSocialMember] CHECK CONSTRAINT [FK_uJetSocialMember_uJetSocialEntity]
