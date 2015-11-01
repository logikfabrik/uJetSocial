CREATE PROCEDURE [dbo].[uJetCommunityIndividualGuestRemove]
	@id int
AS
BEGIN
	SET NOCOUNT ON
	SET XACT_ABORT ON

    DELETE uJetCommunityIndividualGuest
	WHERE Id = @id

	DELETE uJetCommunityEntity
	WHERE Id = @id
END