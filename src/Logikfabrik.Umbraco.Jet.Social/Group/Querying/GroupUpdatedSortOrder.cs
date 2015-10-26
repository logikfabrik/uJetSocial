// <copyright file="GroupUpdatedSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Group.Querying
{
    using Social.Querying;

    /// <summary>
    /// Represents a group updated sort order.
    /// </summary>
    public class GroupUpdatedSortOrder : EntityUpdatedSortOrder, IGroupSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupUpdatedSortOrder" /> class.
        /// </summary>
        /// <param name="order">The sort order.</param>
        public GroupUpdatedSortOrder(Order order)
            : base(order)
        {
        }
    }
}
