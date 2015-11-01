CREATE PROCEDURE [dbo].[uJetCommunityIndividualMemberAdd]
	@created datetime,
	@updated datetime,
	@status int,
	@memberId int,
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

	INSERT INTO uJetCommunityIndividualMember(Id, MemberId) 
	VALUES (@id, @memberId)
	
	SELECT @id
END