CREATE PROCEDURE [dbo].[uJetCommunityMemberGet]
	@id int
AS
BEGIN
	SET NOCOUNT ON

	SELECT uJetCommunityEntity.Id,
		uJetCommunityEntity.Created,
		uJetCommunityEntity.Updated,
		uJetCommunityEntity.Status,
		uJetCommunityMember.ProviderUserKey
	FROM uJetCommunityEntity
	JOIN uJetCommunityMember ON uJetCommunityMember.Id = uJetCommunityEntity.Id
	WHERE uJetCommunityMember.Id = @id
END