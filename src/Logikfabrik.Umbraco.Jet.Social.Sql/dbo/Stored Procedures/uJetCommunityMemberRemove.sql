CREATE PROCEDURE [dbo].[uJetCommunityMemberRemove]
	@id int
AS
BEGIN
	SET NOCOUNT ON
	SET XACT_ABORT ON

    DELETE uJetCommunityMember
	WHERE Id = @id

	DELETE uJetCommunityEntity
	WHERE Id = @id
END