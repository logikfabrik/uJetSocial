CREATE PROCEDURE [dbo].[uJetSocialCommentRemove]
	@id int
AS
BEGIN
	SET NOCOUNT ON
	SET XACT_ABORT ON

    DELETE uJetSocialComment
	WHERE Id = @id

	DELETE uJetSocialEntity
	WHERE Id = @id
END