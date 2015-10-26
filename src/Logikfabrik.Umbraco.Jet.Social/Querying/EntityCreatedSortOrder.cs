// <copyright file="EntityCreatedSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Querying
{
    /// <summary>
    /// Represents a entity created sort order.
    /// </summary>
    public abstract class EntityCreatedSortOrder : SortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityCreatedSortOrder" /> class.
        /// </summary>
        /// <param name="order">The sort order.</param>
        protected EntityCreatedSortOrder(Order order)
            : base("uJetCommunityEntity.Created", order)
        {
        }
    }
}
