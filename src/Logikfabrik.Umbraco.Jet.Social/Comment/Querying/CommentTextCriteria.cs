// <copyright file="CommentTextCriteria.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Comment.Querying
{
    using Social.Querying;

    /// <summary>
    /// The <see cref="CommentTextCriteria" /> class.
    /// </summary>
    public class CommentTextCriteria : Criteria, ICommentCriteria
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentTextCriteria" /> class.
        /// </summary>
        public CommentTextCriteria()
            : base("uJetSocialComment.Text")
        {
        }
    }
}
