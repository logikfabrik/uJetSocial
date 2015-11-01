CREATE PROCEDURE [dbo].[uJetCommunityEntityTypeAdd]
	@type nvarchar(MAX)
AS
BEGIN
	SET NOCOUNT ON

	IF NOT EXISTS (SELECT * FROM uJetCommunityEntityType WITH (UPDLOCK, ROWLOCK, HOLDLOCK) WHERE Type = @type)
	BEGIN
		INSERT INTO uJetCommunityEntityType(Type) VALUES (@type)    
	END
END