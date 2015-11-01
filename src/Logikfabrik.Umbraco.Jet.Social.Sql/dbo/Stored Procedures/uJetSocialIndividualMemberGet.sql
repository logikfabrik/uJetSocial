CREATE PROCEDURE [dbo].[uJetSocialIndividualMemberGet]
	@id int
AS
BEGIN
	SET NOCOUNT ON

	SELECT uJetSocialEntity.Id,
		uJetSocialEntity.Created,
		uJetSocialEntity.Updated,
		uJetSocialEntity.Status,
		uJetSocialIndividualMember.MemberId
	FROM uJetSocialEntity
	JOIN uJetSocialIndividualMember ON uJetSocialIndividualMember.Id = uJetSocialEntity.Id
	WHERE uJetSocialIndividualMember.Id = @id
END