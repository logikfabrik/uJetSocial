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
            : base(GetColumns(), "uJetSocialComment")
        {
        }

        private static IEnumerable<string> GetColumns()
        {
            return new[]
            {
                "uJetSocialComment.EntityId",
                "(SELECT CET.Type FROM uJetSocialEntityType as CET JOIN uJetSocialEntity AS CE ON CE.TypeId = CET.Id WHERE CE.Id = uJetSocialComment.EntityId) AS EntityType",
                "uJetSocialComment.AuthorId",
                "(SELECT CET.Type FROM uJetSocialEntityType as CET JOIN uJetSocialEntity AS CE ON CE.TypeId = CET.Id WHERE CE.Id = uJetSocialComment.AuthorId) AS AuthorType",
                "uJetSocialComment.Text"
            };
        }
    }
}
