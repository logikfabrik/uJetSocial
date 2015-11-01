CREATE PROCEDURE [dbo].[uJetCommunityIndividualMemberRemove]
	@id int
AS
BEGIN
	SET NOCOUNT ON
	SET XACT_ABORT ON

    DELETE uJetCommunityIndividualMember
	WHERE Id = @id

	DELETE uJetCommunityEntity
	WHERE Id = @id
END