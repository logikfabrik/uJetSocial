// <copyright file="CommentQueryBuilder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Comment.Querying
{
    using System.Collections.Generic;
    using Social.Querying;

    /// <summary>
    /// The <see cref="CommentQueryBuilder" /> class.
    /// </summary>
    public class CommentQueryBuilder : EntityQueryBuilder<ICommentCriteria, ICommentSortOrder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentQueryBuilder" /> class.
        /// </summary>
        public CommentQueryBuilder()
            : base(GetColumns(), "uJetCommunityComment")
        {
        }

        private static IEnumerable<string> GetColumns()
        {
            return new[]
            {
                "uJetCommunityComment.EntityId",
                "(SELECT CET.Type FROM uJetCommunityEntityType as CET JOIN uJetCommunityEntity AS CE ON CE.TypeId = CET.Id WHERE CE.Id = uJetCommunityComment.EntityId) AS EntityType",
                "uJetCommunityComment.AuthorId",
                "(SELECT CET.Type FROM uJetCommunityEntityType as CET JOIN uJetCommunityEntity AS CE ON CE.TypeId = CET.Id WHERE CE.Id = uJetCommunityComment.AuthorId) AS AuthorType",
                "uJetCommunityComment.Text"
            };
        }
    }
}
