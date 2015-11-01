CREATE PROCEDURE uJetCommunityEntityCountByCreated
	@type nvarchar(MAX)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @typeId AS int

	SELECT @typeId = Id
	FROM uJetCommunityEntityType
	WHERE Type = @type

    SELECT DATEPART(YEAR, Created) AS [Year], DATEPART(Month, Created) AS [Month], Count(*)
	FROM uJetCommunityEntity
	WHERE TypeId = @typeId
	GROUP BY DATEPART(YEAR, Created), DATEPART(Month, Created)
	ORDER BY [Year], [Month]
END
