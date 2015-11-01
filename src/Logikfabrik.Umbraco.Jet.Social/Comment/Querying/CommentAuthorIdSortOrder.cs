// <copyright file="CommentAuthorIdSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Comment.Querying
{
    using Social.Querying;

    /// <summary>
    /// The <see cref="CommentAuthorIdSortOrder" /> class.
    /// </summary>
    public class CommentAuthorIdSortOrder : SortOrder, ICommentSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentAuthorIdSortOrder" /> class.
        /// </summary>
        /// <param name="order">The order.</param>
        public CommentAuthorIdSortOrder(Order order)
            : base("uJetCommunityComment.AuthorId", order)
        {
        }
    }
}
