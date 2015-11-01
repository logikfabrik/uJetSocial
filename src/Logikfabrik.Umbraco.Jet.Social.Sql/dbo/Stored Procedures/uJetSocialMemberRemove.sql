CREATE PROCEDURE [dbo].[uJetSocialMemberRemove]
	@id int
AS
BEGIN
	SET NOCOUNT ON
	SET XACT_ABORT ON

    DELETE uJetSocialMember
	WHERE Id = @id

	DELETE uJetSocialEntity
	WHERE Id = @id
END