﻿CREATE PROCEDURE [dbo].[uJetCommunityCommentRemove]
	@id int
AS
BEGIN
	SET NOCOUNT ON
	SET XACT_ABORT ON

    DELETE uJetCommunityComment
	WHERE Id = @id

	DELETE uJetCommunityEntity
	WHERE Id = @id
END