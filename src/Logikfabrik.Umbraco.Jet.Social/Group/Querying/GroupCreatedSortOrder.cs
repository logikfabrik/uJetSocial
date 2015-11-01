// <copyright file="GroupCreatedSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Group.Querying
{
    using Social.Querying;

    /// <summary>
    /// The <see cref="GroupCreatedSortOrder" /> class.
    /// </summary>
    public class GroupCreatedSortOrder : EntityCreatedSortOrder, IGroupSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupCreatedSortOrder" /> class.
        /// </summary>
        /// <param name="order">The order.</param>
        public GroupCreatedSortOrder(Order order)
            : base(order)
        {
        }
    }
}
