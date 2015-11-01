// <copyright file="EntityCreatedSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Querying
{
    /// <summary>
    /// The <see cref="EntityCreatedSortOrder" /> class.
    /// </summary>
    public abstract class EntityCreatedSortOrder : SortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityCreatedSortOrder" /> class.
        /// </summary>
        /// <param name="order">The order.</param>
        protected EntityCreatedSortOrder(Order order)
            : base("uJetSocialEntity.Created", order)
        {
        }
    }
}
