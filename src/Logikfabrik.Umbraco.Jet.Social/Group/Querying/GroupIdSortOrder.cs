// <copyright file="GroupIdSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Group.Querying
{
    using Social.Querying;

    /// <summary>
    /// Represents a group ID sort order.
    /// </summary>
    public class GroupIdSortOrder : EntityIdSortOrder, IGroupSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupIdSortOrder" /> class.
        /// </summary>
        /// <param name="order">The sort order.</param>
        public GroupIdSortOrder(Order order)
            : base(order)
        {
        }
    }
}
