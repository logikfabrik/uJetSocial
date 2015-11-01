// <copyright file="EntityIdSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Querying
{
    /// <summary>
    /// The <see cref="EntityIdSortOrder" /> class.
    /// </summary>
    public abstract class EntityIdSortOrder : SortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityIdSortOrder" /> class.
        /// </summary>
        /// <param name="order">The order.</param>
        protected EntityIdSortOrder(Order order)
            : base("uJetCommunityEntity.Id", order)
        {
        }
    }
}
