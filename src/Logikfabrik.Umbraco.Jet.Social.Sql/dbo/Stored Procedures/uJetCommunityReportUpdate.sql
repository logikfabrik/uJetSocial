CREATE PROCEDURE [dbo].[uJetCommunityReportUpdate]
	@id int,
	@created datetime,
	@updated datetime,
	@status int,
	@text nvarchar(MAX)
AS
BEGIN
	SET NOCOUNT ON
	SET XACT_ABORT ON

	UPDATE uJetCommunityReport
	SET Text = @text
	WHERE Id = @id

	UPDATE uJetCommunityEntity
	SET Created = @created,
		Updated = @updated,
		Status = @status
	WHERE Id = @id
END