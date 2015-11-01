CREATE PROCEDURE [dbo].[uJetSocialReportAdd]
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
	FROM uJetSocialEntityType
	WHERE Type = @type

	INSERT INTO uJetSocialEntity(TypeId, Created, Updated, Status) 
	VALUES (@typeId, @created, @updated, @status)

	SET @id = SCOPE_IDENTITY()

	INSERT INTO uJetSocialReport(Id, EntityId, AuthorId, Text) 
	VALUES (@id, @entityId, @authorId, @text)
	
	SELECT @id
END