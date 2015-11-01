CREATE PROCEDURE [dbo].[uJetCommunityIndividualGuestUpdate]
	@id int,
	@created datetime,
	@updated datetime,
	@status int,
	@firstName nvarchar(MAX),
	@lastName nvarchar(MAX),
	@email nvarchar(MAX)
AS
BEGIN
	SET NOCOUNT ON
	SET XACT_ABORT ON

	UPDATE uJetCommunityIndividualGuest
	SET FirstName = @firstName,
		LastName = @lastName,
		Email = @email
	WHERE Id = @id

	UPDATE uJetCommunityEntity
	SET Created = @created,
		Updated = @updated,
		Status = @status
	WHERE Id = @id
END