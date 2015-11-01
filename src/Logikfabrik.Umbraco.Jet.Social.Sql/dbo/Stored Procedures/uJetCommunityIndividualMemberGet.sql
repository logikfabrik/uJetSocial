CREATE PROCEDURE [dbo].[uJetCommunityIndividualMemberGet]
	@id int
AS
BEGIN
	SET NOCOUNT ON

	SELECT uJetCommunityEntity.Id,
		uJetCommunityEntity.Created,
		uJetCommunityEntity.Updated,
		uJetCommunityEntity.Status,
		uJetCommunityIndividualMember.MemberId
	FROM uJetCommunityEntity
	JOIN uJetCommunityIndividualMember ON uJetCommunityIndividualMember.Id = uJetCommunityEntity.Id
	WHERE uJetCommunityIndividualMember.Id = @id
END