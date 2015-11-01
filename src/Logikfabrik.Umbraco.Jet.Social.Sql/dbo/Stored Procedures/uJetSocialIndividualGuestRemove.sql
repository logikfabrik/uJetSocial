CREATE PROCEDURE [dbo].[uJetSocialIndividualGuestRemove]
	@id int
AS
BEGIN
	SET NOCOUNT ON
	SET XACT_ABORT ON

    DELETE uJetSocialIndividualGuest
	WHERE Id = @id

	DELETE uJetSocialEntity
	WHERE Id = @id
END