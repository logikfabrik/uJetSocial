CREATE PROCEDURE [dbo].[uJetCommunityGroupUpdate]
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

	UPDATE uJetCommunityGroup
	SET OwnerId = @ownerId,
		Name = @name,
		Description = @description
	WHERE Id = @id

	UPDATE uJetCommunityEntity
	SET Created = @created,
		Updated = @updated,
		Status = @status
	WHERE Id = @id
END