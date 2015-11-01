CREATE PROCEDURE [dbo].[uJetSocialIndividualMemberRemove]
	@id int
AS
BEGIN
	SET NOCOUNT ON
	SET XACT_ABORT ON

    DELETE uJetSocialIndividualMember
	WHERE Id = @id

	DELETE uJetSocialEntity
	WHERE Id = @id
END