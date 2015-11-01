CREATE PROCEDURE [dbo].[uJetSocialReportGet]
	@id int
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT uJetSocialEntity.Id,
		uJetSocialEntity.Created,
		uJetSocialEntity.Updated,
		uJetSocialEntity.Status,
		uJetSocialReport.EntityId,
		(
			SELECT CET.Type
			FROM uJetSocialEntityType as CET
			JOIN uJetSocialEntity AS CR ON CR.TypeId = CET.Id
			WHERE CR.Id = uJetSocialReport.EntityId
		) AS EntityType,
		uJetSocialReport.AuthorId,
		(
			SELECT CET.Type
			FROM uJetSocialEntityType as CET
			JOIN uJetSocialEntity AS CR ON CR.TypeId = CET.Id
			WHERE CR.Id = uJetSocialReport.AuthorId
		) AS AuthorType,
		uJetSocialReport.Text
	FROM uJetSocialEntity
	JOIN uJetSocialReport ON uJetSocialReport.Id = uJetSocialEntity.Id
	WHERE uJetSocialReport.Id = @id
END