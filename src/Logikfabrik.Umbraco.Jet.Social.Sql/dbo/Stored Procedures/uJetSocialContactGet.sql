CREATE PROCEDURE [dbo].[uJetSocialContactGet]
	@id int
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT uJetSocialEntity.Id,
		uJetSocialEntity.Created,
		uJetSocialEntity.Updated,
		uJetSocialEntity.Status,
		uJetSocialContact.FromId,
		(
			SELECT CET.Type
			FROM uJetSocialEntityType as CET
			JOIN uJetSocialEntity AS CE ON CE.TypeId = CET.Id
			WHERE CE.Id = uJetSocialContact.FromId
		) AS FromType,
		uJetSocialContact.ToId,
		(
			SELECT CET.Type
			FROM uJetSocialEntityType as CET
			JOIN uJetSocialEntity AS CE ON CE.TypeId = CET.Id
			WHERE CE.Id = uJetSocialContact.ToId
		) AS ToType
	FROM uJetSocialEntity
	JOIN uJetSocialContact ON uJetSocialContact.Id = uJetSocialEntity.Id
	WHERE uJetSocialContact.Id = @id
END