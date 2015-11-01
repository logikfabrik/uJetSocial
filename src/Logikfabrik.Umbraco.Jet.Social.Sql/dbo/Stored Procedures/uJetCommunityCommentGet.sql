CREATE PROCEDURE [dbo].[uJetCommunityCommentGet]
	@id int
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT uJetCommunityEntity.Id,
		uJetCommunityEntity.Created,
		uJetCommunityEntity.Updated,
		uJetCommunityEntity.Status,
		uJetCommunityComment.EntityId,
		(
			SELECT CET.Type
			FROM uJetCommunityEntityType as CET
			JOIN uJetCommunityEntity AS CE ON CE.TypeId = CET.Id
			WHERE CE.Id = uJetCommunityComment.EntityId
		) AS EntityType,
		uJetCommunityComment.AuthorId,
		(
			SELECT CET.Type
			FROM uJetCommunityEntityType as CET
			JOIN uJetCommunityEntity AS CE ON CE.TypeId = CET.Id
			WHERE CE.Id = uJetCommunityComment.AuthorId
		) AS AuthorType,
		uJetCommunityComment.Text
	FROM uJetCommunityEntity
	JOIN uJetCommunityComment ON uJetCommunityComment.Id = uJetCommunityEntity.Id
	WHERE uJetCommunityComment.Id = @id
END