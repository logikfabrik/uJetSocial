CREATE PROCEDURE [dbo].[uJetCommunityGroupMembershipRemove]
	@id int
AS
BEGIN
	SET NOCOUNT ON
	SET XACT_ABORT ON

    DELETE uJetCommunityGroupMembership
	WHERE Id = @id

	DELETE uJetCommunityEntity
	WHERE Id = @id
END