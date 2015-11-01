CREATE PROCEDURE [dbo].[uJetSocialGroupRemove]
	@id int
AS
BEGIN
	SET NOCOUNT ON
	SET XACT_ABORT ON

    DELETE uJetSocialGroup
	WHERE Id = @id

	DELETE uJetSocialEntity
	WHERE Id = @id
END