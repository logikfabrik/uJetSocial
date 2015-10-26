// <copyright file="EntityUpdatedSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Querying
{
    /// <summary>
    /// Represents a entity updated sort order.
    /// </summary>
    public abstract class EntityUpdatedSortOrder : SortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityUpdatedSortOrder" /> class.
        /// </summary>
        /// <param name="order">The sort order.</param>
        protected EntityUpdatedSortOrder(Order order)
            : base("uJetCommunityEntity.Updated", order)
        {
        }
    }
}
