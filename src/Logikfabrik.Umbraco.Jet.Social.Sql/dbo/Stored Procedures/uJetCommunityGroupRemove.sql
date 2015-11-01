CREATE PROCEDURE [dbo].[uJetCommunityGroupRemove]
	@id int
AS
BEGIN
	SET NOCOUNT ON
	SET XACT_ABORT ON

    DELETE uJetCommunityGroup
	WHERE Id = @id

	DELETE uJetCommunityEntity
	WHERE Id = @id
END