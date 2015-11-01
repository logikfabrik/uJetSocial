CREATE PROCEDURE [dbo].[uJetSocialMemberAdd]
	@created datetime,
	@updated datetime,
	@status int,
	@providerUserKey int,
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

	INSERT INTO uJetSocialMember(Id, ProviderUserKey) 
	VALUES (@id, @providerUserKey)
	
	SELECT @id
END