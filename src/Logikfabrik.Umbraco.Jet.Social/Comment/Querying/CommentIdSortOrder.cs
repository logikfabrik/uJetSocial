// <copyright file="CommentIdSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Comment.Querying
{
    using Social.Querying;

    /// <summary>
    /// Represents a comment ID sort order.
    /// </summary>
    public class CommentIdSortOrder : EntityIdSortOrder, ICommentSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentIdSortOrder" /> class.
        /// </summary>
        /// <param name="order">The sort order.</param>
        public CommentIdSortOrder(Order order)
            : base(order)
        {
        }
    }
}
