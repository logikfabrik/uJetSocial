CREATE PROCEDURE [dbo].[uJetCommunityContactRemove]
	@id int
AS
BEGIN
	SET NOCOUNT ON
	SET XACT_ABORT ON

    DELETE uJetCommunityContact
	WHERE Id = @id

	DELETE uJetCommunityEntity
	WHERE Id = @id
END