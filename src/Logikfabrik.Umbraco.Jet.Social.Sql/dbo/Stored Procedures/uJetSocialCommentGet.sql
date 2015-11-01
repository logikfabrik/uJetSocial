CREATE PROCEDURE [dbo].[uJetSocialCommentGet]
	@id int
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT uJetSocialEntity.Id,
		uJetSocialEntity.Created,
		uJetSocialEntity.Updated,
		uJetSocialEntity.Status,
		uJetSocialComment.EntityId,
		(
			SELECT CET.Type
			FROM uJetSocialEntityType as CET
			JOIN uJetSocialEntity AS CE ON CE.TypeId = CET.Id
			WHERE CE.Id = uJetSocialComment.EntityId
		) AS EntityType,
		uJetSocialComment.AuthorId,
		(
			SELECT CET.Type
			FROM uJetSocialEntityType as CET
			JOIN uJetSocialEntity AS CE ON CE.TypeId = CET.Id
			WHERE CE.Id = uJetSocialComment.AuthorId
		) AS AuthorType,
		uJetSocialComment.Text
	FROM uJetSocialEntity
	JOIN uJetSocialComment ON uJetSocialComment.Id = uJetSocialEntity.Id
	WHERE uJetSocialComment.Id = @id
END