CREATE PROCEDURE [dbo].[uJetCommunityReportGet]
	@id int
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT uJetCommunityEntity.Id,
		uJetCommunityEntity.Created,
		uJetCommunityEntity.Updated,
		uJetCommunityEntity.Status,
		uJetCommunityReport.EntityId,
		(
			SELECT CET.Type
			FROM uJetCommunityEntityType as CET
			JOIN uJetCommunityEntity AS CR ON CR.TypeId = CET.Id
			WHERE CR.Id = uJetCommunityReport.EntityId
		) AS EntityType,
		uJetCommunityReport.AuthorId,
		(
			SELECT CET.Type
			FROM uJetCommunityEntityType as CET
			JOIN uJetCommunityEntity AS CR ON CR.TypeId = CET.Id
			WHERE CR.Id = uJetCommunityReport.AuthorId
		) AS AuthorType,
		uJetCommunityReport.Text
	FROM uJetCommunityEntity
	JOIN uJetCommunityReport ON uJetCommunityReport.Id = uJetCommunityEntity.Id
	WHERE uJetCommunityReport.Id = @id
END