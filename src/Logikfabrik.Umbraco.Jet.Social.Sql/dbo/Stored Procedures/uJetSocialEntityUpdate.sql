CREATE PROCEDURE [dbo].[uJetSocialEntityUpdate]
	@id int,
	@created datetime,
	@updated datetime,
	@status int
AS
BEGIN
	SET NOCOUNT ON
	SET XACT_ABORT ON

	UPDATE uJetSocialEntity
	SET Created = @created,
		Updated = @updated,
		Status = @status
	WHERE Id = @id
END