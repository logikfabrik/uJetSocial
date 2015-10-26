// <copyright file="CommentEntityIdCriteria.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Comment.Querying
{
    using Social.Querying;

    /// <summary>
    /// Represents a comment entity ID criteria.
    /// </summary>
    public class CommentEntityIdCriteria : Criteria, ICommentCriteria
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentEntityIdCriteria" /> class.
        /// </summary>
        public CommentEntityIdCriteria()
            : base("uJetCommunityComment.EntityId")
        {
        }
    }
}
