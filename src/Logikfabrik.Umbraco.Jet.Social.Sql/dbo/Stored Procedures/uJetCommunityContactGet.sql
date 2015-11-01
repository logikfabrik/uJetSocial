CREATE PROCEDURE [dbo].[uJetCommunityContactGet]
	@id int
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT uJetCommunityEntity.Id,
		uJetCommunityEntity.Created,
		uJetCommunityEntity.Updated,
		uJetCommunityEntity.Status,
		uJetCommunityContact.FromId,
		(
			SELECT CET.Type
			FROM uJetCommunityEntityType as CET
			JOIN uJetCommunityEntity AS CE ON CE.TypeId = CET.Id
			WHERE CE.Id = uJetCommunityContact.FromId
		) AS FromType,
		uJetCommunityContact.ToId,
		(
			SELECT CET.Type
			FROM uJetCommunityEntityType as CET
			JOIN uJetCommunityEntity AS CE ON CE.TypeId = CET.Id
			WHERE CE.Id = uJetCommunityContact.ToId
		) AS ToType
	FROM uJetCommunityEntity
	JOIN uJetCommunityContact ON uJetCommunityContact.Id = uJetCommunityEntity.Id
	WHERE uJetCommunityContact.Id = @id
END