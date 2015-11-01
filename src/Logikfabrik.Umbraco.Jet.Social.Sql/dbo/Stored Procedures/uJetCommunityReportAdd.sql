CREATE PROCEDURE [dbo].[uJetCommunityReportAdd]
	@created datetime,
	@updated datetime,
	@status int,
	@entityId int,
	@authorId int,
	@text nvarchar(MAX),
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

	INSERT INTO uJetCommunityReport(Id, EntityId, AuthorId, Text) 
	VALUES (@id, @entityId, @authorId, @text)
	
	SELECT @id
END