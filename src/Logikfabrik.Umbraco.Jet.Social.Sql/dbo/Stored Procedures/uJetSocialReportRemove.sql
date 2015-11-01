CREATE PROCEDURE [dbo].[uJetSocialReportRemove]
	@id int
AS
BEGIN
	SET NOCOUNT ON
	SET XACT_ABORT ON

    DELETE uJetSocialReport
	WHERE Id = @id

	DELETE uJetSocialEntity
	WHERE Id = @id
END