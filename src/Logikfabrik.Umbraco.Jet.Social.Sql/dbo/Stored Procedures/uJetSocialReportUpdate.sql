CREATE PROCEDURE [dbo].[uJetSocialReportUpdate]
	@id int,
	@created datetime,
	@updated datetime,
	@status int,
	@text nvarchar(MAX)
AS
BEGIN
	SET NOCOUNT ON
	SET XACT_ABORT ON

	UPDATE uJetSocialReport
	SET Text = @text
	WHERE Id = @id

	UPDATE uJetSocialEntity
	SET Created = @created,
		Updated = @updated,
		Status = @status
	WHERE Id = @id
END