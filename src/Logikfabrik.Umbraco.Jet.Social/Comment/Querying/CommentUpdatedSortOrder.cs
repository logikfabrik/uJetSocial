// <copyright file="CommentUpdatedSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Comment.Querying
{
    using Social.Querying;

    /// <summary>
    /// The <see cref="CommentUpdatedSortOrder" /> class.
    /// </summary>
    public class CommentUpdatedSortOrder : EntityUpdatedSortOrder, ICommentSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentUpdatedSortOrder" /> class.
        /// </summary>
        /// <param name="order">The order.</param>
        public CommentUpdatedSortOrder(Order order)
            : base(order)
        {
        }
    }
}
