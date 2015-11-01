CREATE PROCEDURE [dbo].[uJetSocialMemberGet]
	@id int
AS
BEGIN
	SET NOCOUNT ON

	SELECT uJetSocialEntity.Id,
		uJetSocialEntity.Created,
		uJetSocialEntity.Updated,
		uJetSocialEntity.Status,
		uJetSocialMember.ProviderUserKey
	FROM uJetSocialEntity
	JOIN uJetSocialMember ON uJetSocialMember.Id = uJetSocialEntity.Id
	WHERE uJetSocialMember.Id = @id
END