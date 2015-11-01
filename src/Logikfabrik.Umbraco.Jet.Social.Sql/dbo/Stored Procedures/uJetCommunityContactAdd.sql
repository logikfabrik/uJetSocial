CREATE PROCEDURE [dbo].[uJetCommunityContactAdd]
	@created datetime,
	@updated datetime,
	@status int,
	@fromId int,
	@toId int,
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

	INSERT INTO uJetCommunityContact(Id, FromId, ToId) 
	VALUES (@id, @fromId, @toId)
	
	SELECT @id
END