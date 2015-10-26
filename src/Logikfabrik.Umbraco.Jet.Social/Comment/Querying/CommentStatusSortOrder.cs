// <copyright file="CommentStatusSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Comment.Querying
{
    using Social.Querying;

    /// <summary>
    /// Represents a comment status sort order.
    /// </summary>
    public class CommentStatusSortOrder : EntityStatusSortOrder, ICommentSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentStatusSortOrder" /> class.
        /// </summary>
        /// <param name="order">The sort order.</param>
        public CommentStatusSortOrder(Order order)
            : base(order)
        {
        }
    }
}
