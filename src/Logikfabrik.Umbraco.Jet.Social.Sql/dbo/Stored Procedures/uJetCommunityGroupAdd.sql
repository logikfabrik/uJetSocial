CREATE PROCEDURE [dbo].[uJetCommunityGroupAdd]
	@created datetime,
	@updated datetime,
	@status int,
	@ownerId int,
	@name nvarchar(MAX),
	@description nvarchar(MAX),
	@type nvarchar(MAX)
AS
BEGIN
	SET NOCOUNT ON
	SET XACT_ABORT ON

	DECLARE @typeId AS int
	DECLARE @id AS int

	SELECT @typeId = Id
	FROM uJetCommunityEntityType
	WHERE Type = @type

	INSERT INTO uJetCommunityEntity(TypeId, Created, Updated, Status) 
	VALUES (@typeId, @created, @updated, @status)

	SET @id = SCOPE_IDENTITY()

	INSERT INTO uJetCommunityGroup(Id, OwnerId, Name, Description) 
	VALUES (@id, @ownerId, @name, @description)
	
	SELECT @id
END