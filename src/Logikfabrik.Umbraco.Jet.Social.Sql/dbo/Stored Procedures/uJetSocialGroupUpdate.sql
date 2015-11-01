CREATE PROCEDURE [dbo].[uJetSocialGroupUpdate]
	@id int,
	@created datetime,
	@updated datetime,
	@status int,
	@ownerId int,
	@name nvarchar(MAX),
	@description nvarchar(MAX)
AS
BEGIN
	SET NOCOUNT ON
	SET XACT_ABORT ON

	UPDATE uJetSocialGroup
	SET OwnerId = @ownerId,
		Name = @name,
		Description = @description
	WHERE Id = @id

	UPDATE uJetSocialEntity
	SET Created = @created,
		Updated = @updated,
		Status = @status
	WHERE Id = @id
END