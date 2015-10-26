// <copyright file="CommentAuthorIdCriteria.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Comment.Querying
{
    using Social.Querying;

    /// <summary>
    /// Represents a comment author ID criteria.
    /// </summary>
    public class CommentAuthorIdCriteria : Criteria, ICommentCriteria
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentAuthorIdCriteria" /> class.
        /// </summary>
        public CommentAuthorIdCriteria()
            : base("uJetCommunityComment.AuthorId")
        {
        }
    }
}
