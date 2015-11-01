CREATE PROCEDURE [dbo].[uJetSocialGroupGet]
	@id int
AS
BEGIN
	SET NOCOUNT ON

	SELECT uJetSocialEntity.Id,
		uJetSocialEntity.Created,
		uJetSocialEntity.Updated,
		uJetSocialEntity.Status,
		uJetSocialGroup.OwnerId,
		(
			SELECT CET.Type
			FROM uJetSocialEntityType as CET
			JOIN uJetSocialEntity AS CG ON CG.TypeId = CET.Id
			WHERE CG.Id = uJetSocialGroup.OwnerId
		) AS OwnerType,
		uJetSocialGroup.Name,
		uJetSocialGroup.Description
	FROM uJetSocialEntity
	JOIN uJetSocialGroup ON uJetSocialGroup.Id = uJetSocialEntity.Id
	WHERE uJetSocialGroup.Id = @id
END