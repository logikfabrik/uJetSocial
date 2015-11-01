CREATE PROCEDURE [dbo].[uJetSocialContactRemove]
	@id int
AS
BEGIN
	SET NOCOUNT ON
	SET XACT_ABORT ON

    DELETE uJetSocialContact
	WHERE Id = @id

	DELETE uJetSocialEntity
	WHERE Id = @id
END