CREATE PROCEDURE [dbo].[uJetSocialIndividualGuestUpdate]
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

	UPDATE uJetSocialIndividualGuest
	SET FirstName = @firstName,
		LastName = @lastName,
		Email = @email
	WHERE Id = @id

	UPDATE uJetSocialEntity
	SET Created = @created,
		Updated = @updated,
		Status = @status
	WHERE Id = @id
END