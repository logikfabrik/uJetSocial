CREATE PROCEDURE [dbo].[uJetCommunityIndividualGuestAdd]
	@created datetime,
	@updated datetime,
	@status int,
	@firstName nvarchar(MAX),
	@lastName nvarchar(MAX),
	@email nvarchar(MAX),
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

	INSERT INTO uJetCommunityIndividualGuest(Id, FirstName, LastName, Email) 
	VALUES (@id, @firstName, @lastName, @email)
	
	SELECT @id
END