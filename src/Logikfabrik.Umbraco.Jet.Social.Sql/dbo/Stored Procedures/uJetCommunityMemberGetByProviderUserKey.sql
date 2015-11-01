CREATE PROCEDURE [dbo].[uJetCommunityMemberGetByProviderUserKey]
	@providerUserKey int
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
	WHERE uJetCommunityMember.ProviderUserKey = @providerUserKey
END