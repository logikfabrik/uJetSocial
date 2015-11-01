CREATE PROCEDURE [dbo].[uJetSocialGroupMembershipGet]
	@id int
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT uJetSocialEntity.Id,
		uJetSocialEntity.Created,
		uJetSocialEntity.Updated,
		uJetSocialEntity.Status,
		uJetSocialGroupMembership.GroupId,
		(
			SELECT CET.Type
			FROM uJetSocialEntityType as CET
			JOIN uJetSocialEntity AS CGM ON CGM.TypeId = CET.Id
			WHERE CGM.Id = uJetSocialGroupMembership.GroupId
		) AS GroupType,
		uJetSocialGroupMembership.MemberId,
		(
			SELECT CET.Type
			FROM uJetSocialEntityType as CET
			JOIN uJetSocialEntity AS CGM ON CGM.TypeId = CET.Id
			WHERE CGM.Id = uJetSocialGroupMembership.MemberId
		) AS MemberType
	FROM uJetSocialEntity
	JOIN uJetSocialGroupMembership ON uJetSocialGroupMembership.Id = uJetSocialEntity.Id
	WHERE uJetSocialGroupMembership.Id = @id
END