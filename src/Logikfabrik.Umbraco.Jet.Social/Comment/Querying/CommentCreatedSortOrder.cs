// <copyright file="CommentCreatedSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Comment.Querying
{
    using Social.Querying;

    /// <summary>
    /// The <see cref="CommentCreatedSortOrder" /> class.
    /// </summary>
    public class CommentCreatedSortOrder : EntityCreatedSortOrder, ICommentSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentCreatedSortOrder" /> class.
        /// </summary>
        /// <param name="order">The order.</param>
        public CommentCreatedSortOrder(Order order)
            : base(order)
        {
        }
    }
}
