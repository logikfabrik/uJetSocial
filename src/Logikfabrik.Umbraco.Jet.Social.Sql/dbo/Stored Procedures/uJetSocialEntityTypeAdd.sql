CREATE PROCEDURE [dbo].[uJetSocialEntityTypeAdd]
	@type nvarchar(MAX)
AS
BEGIN
	SET NOCOUNT ON

	IF NOT EXISTS (SELECT * FROM uJetSocialEntityType WITH (UPDLOCK, ROWLOCK, HOLDLOCK) WHERE Type = @type)
	BEGIN
		INSERT INTO uJetSocialEntityType(Type) VALUES (@type)    
	END
END