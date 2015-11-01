CREATE TABLE [dbo].[uJetSocialEntity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeId] [int] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_uJetSocialEntity_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[uJetSocialEntity]  ADD  CONSTRAINT [FK_uJetSocialEntity_uJetSocialEntityType] FOREIGN KEY([TypeId])
REFERENCES [dbo].[uJetSocialEntityType] ([Id])
GO

ALTER TABLE [dbo].[uJetSocialEntity] CHECK CONSTRAINT [FK_uJetSocialEntity_uJetSocialEntityType]
