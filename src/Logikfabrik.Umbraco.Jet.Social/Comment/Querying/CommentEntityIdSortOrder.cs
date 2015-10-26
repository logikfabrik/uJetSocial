// <copyright file="CommentEntityIdSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Comment.Querying
{
    using Social.Querying;

    /// <summary>
    /// Represents a comment entity ID sort order.
    /// </summary>
    public class CommentEntityIdSortOrder : SortOrder, ICommentSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentEntityIdSortOrder" /> class.
        /// </summary>
        /// <param name="order">The sort order.</param>
        public CommentEntityIdSortOrder(Order order)
            : base("uJetCommunityComment.EntityId", order)
        {
        }
    }
}
