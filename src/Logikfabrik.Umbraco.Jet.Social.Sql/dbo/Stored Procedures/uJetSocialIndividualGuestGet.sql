CREATE PROCEDURE [dbo].[uJetSocialIndividualGuestGet]
	@id int
AS
BEGIN
	SET NOCOUNT ON

	SELECT uJetSocialEntity.Id,
		uJetSocialEntity.Created,
		uJetSocialEntity.Updated,
		uJetSocialEntity.Status,
		uJetSocialIndividualGuest.FirstName,
		uJetSocialIndividualGuest.LastName,
		uJetSocialIndividualGuest.Email
	FROM uJetSocialEntity
	JOIN uJetSocialIndividualGuest ON uJetSocialIndividualGuest.Id = uJetSocialEntity.Id
	WHERE uJetSocialIndividualGuest.Id = @id
END