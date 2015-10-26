﻿// <copyright file="GroupStatusSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Group.Querying
{
    using Social.Querying;

    /// <summary>
    /// Represents a group status sort order.
    /// </summary>
    public class GroupStatusSortOrder : EntityStatusSortOrder, IGroupSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupStatusSortOrder" /> class.
        /// </summary>
        /// <param name="order">The sort order.</param>
        public GroupStatusSortOrder(Order order)
            : base(order)
        {
        }
    }
}
