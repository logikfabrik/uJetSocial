CREATE PROCEDURE [dbo].[uJetSocialGroupMembershipRemove]
	@id int
AS
BEGIN
	SET NOCOUNT ON
	SET XACT_ABORT ON

    DELETE uJetSocialGroupMembership
	WHERE Id = @id

	DELETE uJetSocialEntity
	WHERE Id = @id
END