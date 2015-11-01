CREATE PROCEDURE [dbo].[uJetSocialIndividualMemberAdd]
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
	FROM uJetSocialEntityType
	WHERE Type = @type

	INSERT INTO uJetSocialEntity(TypeId, Created, Updated, Status) 
	VALUES (@typeId, @created, @updated, @status)

	SET @id = SCOPE_IDENTITY()

	INSERT INTO uJetSocialIndividualMember(Id, MemberId) 
	VALUES (@id, @memberId)
	
	SELECT @id
END