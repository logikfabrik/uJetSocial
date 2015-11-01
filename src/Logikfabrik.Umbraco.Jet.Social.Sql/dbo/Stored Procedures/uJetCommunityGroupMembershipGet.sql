CREATE PROCEDURE [dbo].[uJetCommunityGroupMembershipGet]
	@id int
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT uJetCommunityEntity.Id,
		uJetCommunityEntity.Created,
		uJetCommunityEntity.Updated,
		uJetCommunityEntity.Status,
		uJetCommunityGroupMembership.GroupId,
		(
			SELECT CET.Type
			FROM uJetCommunityEntityType as CET
			JOIN uJetCommunityEntity AS CGM ON CGM.TypeId = CET.Id
			WHERE CGM.Id = uJetCommunityGroupMembership.GroupId
		) AS GroupType,
		uJetCommunityGroupMembership.MemberId,
		(
			SELECT CET.Type
			FROM uJetCommunityEntityType as CET
			JOIN uJetCommunityEntity AS CGM ON CGM.TypeId = CET.Id
			WHERE CGM.Id = uJetCommunityGroupMembership.MemberId
		) AS MemberType
	FROM uJetCommunityEntity
	JOIN uJetCommunityGroupMembership ON uJetCommunityGroupMembership.Id = uJetCommunityEntity.Id
	WHERE uJetCommunityGroupMembership.Id = @id
END