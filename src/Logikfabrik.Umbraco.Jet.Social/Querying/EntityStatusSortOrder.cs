// <copyright file="EntityStatusSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Querying
{
    /// <summary>
    /// The <see cref="EntityStatusSortOrder" /> class.
    /// </summary>
    public abstract class EntityStatusSortOrder : SortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityStatusSortOrder" /> class.
        /// </summary>
        /// <param name="order">The order.</param>
        protected EntityStatusSortOrder(Order order)
            : base("uJetCommunityEntity.Status", order)
        {
        }
    }
}
