CREATE PROCEDURE [dbo].[uJetCommunityGroupMembershipAdd]
	@created datetime,
	@updated datetime,
	@status int,
	@groupId int,
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

	INSERT INTO uJetCommunityGroupMembership(Id, GroupId, MemberId) 
	VALUES (@id, @groupId, @memberId)
	
	SELECT @id
END