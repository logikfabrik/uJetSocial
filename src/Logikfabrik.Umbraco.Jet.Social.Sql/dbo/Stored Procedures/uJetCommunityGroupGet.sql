CREATE PROCEDURE [dbo].[uJetCommunityGroupGet]
	@id int
AS
BEGIN
	SET NOCOUNT ON

	SELECT uJetCommunityEntity.Id,
		uJetCommunityEntity.Created,
		uJetCommunityEntity.Updated,
		uJetCommunityEntity.Status,
		uJetCommunityGroup.OwnerId,
		(
			SELECT CET.Type
			FROM uJetCommunityEntityType as CET
			JOIN uJetCommunityEntity AS CG ON CG.TypeId = CET.Id
			WHERE CG.Id = uJetCommunityGroup.OwnerId
		) AS OwnerType,
		uJetCommunityGroup.Name,
		uJetCommunityGroup.Description
	FROM uJetCommunityEntity
	JOIN uJetCommunityGroup ON uJetCommunityGroup.Id = uJetCommunityEntity.Id
	WHERE uJetCommunityGroup.Id = @id
END