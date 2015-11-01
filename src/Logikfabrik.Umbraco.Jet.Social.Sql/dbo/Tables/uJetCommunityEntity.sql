CREATE TABLE [dbo].[uJetCommunityEntity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeId] [int] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_uJetCommunityEntity_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[uJetCommunityEntity]  ADD  CONSTRAINT [FK_uJetCommunityEntity_uJetCommunityEntityType] FOREIGN KEY([TypeId])
REFERENCES [dbo].[uJetCommunityEntityType] ([Id])
GO

ALTER TABLE [dbo].[uJetCommunityEntity] CHECK CONSTRAINT [FK_uJetCommunityEntity_uJetCommunityEntityType]