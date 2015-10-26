// <copyright file="CommentTextSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Comment.Querying
{
    using Social.Querying;

    /// <summary>
    /// Represents a comment text sort order.
    /// </summary>
    public class CommentTextSortOrder : SortOrder, ICommentSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentTextSortOrder" /> class.
        /// </summary>
        /// <param name="order">The sort order.</param>
        public CommentTextSortOrder(Order order)
            : base("uJetCommunityComment.Text", order)
        {
        }
    }
}
