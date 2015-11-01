CREATE PROCEDURE [dbo].[uJetCommunityIndividualGuestGet]
	@id int
AS
BEGIN
	SET NOCOUNT ON

	SELECT uJetCommunityEntity.Id,
		uJetCommunityEntity.Created,
		uJetCommunityEntity.Updated,
		uJetCommunityEntity.Status,
		uJetCommunityIndividualGuest.FirstName,
		uJetCommunityIndividualGuest.LastName,
		uJetCommunityIndividualGuest.Email
	FROM uJetCommunityEntity
	JOIN uJetCommunityIndividualGuest ON uJetCommunityIndividualGuest.Id = uJetCommunityEntity.Id
	WHERE uJetCommunityIndividualGuest.Id = @id
END