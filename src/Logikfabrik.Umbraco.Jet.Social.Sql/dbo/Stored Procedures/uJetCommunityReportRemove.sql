CREATE PROCEDURE [dbo].[uJetCommunityReportRemove]
	@id int
AS
BEGIN
	SET NOCOUNT ON
	SET XACT_ABORT ON

    DELETE uJetCommunityReport
	WHERE Id = @id

	DELETE uJetCommunityEntity
	WHERE Id = @id
END