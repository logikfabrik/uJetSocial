// <copyright file="GroupOwnerIdSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Group.Querying
{
    using Social.Querying;

    /// <summary>
    /// Represents a group owner ID sort order.
    /// </summary>
    public class GroupOwnerIdSortOrder : SortOrder, IGroupSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupOwnerIdSortOrder" /> class.
        /// </summary>
        /// <param name="order">The sort order.</param>
        public GroupOwnerIdSortOrder(Order order)
            : base("uJetCommunityGroup.OwnerId", order)
        {
        }
    }
}
