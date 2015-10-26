// <copyright file="IEntityProvider.cs" company="Logikfabrik">
// Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the entity provider interface.
    /// </summary>
    public interface IEntityProvider
    {
        /// <summary>
        /// Gets the entity type for the provider.
        /// </summary>
        Type EntityType { get; }

        /// <summary>
        /// Gets an entity.
        /// </summary>
        /// <param name="id">The entity ID.</param>
        /// <returns>An entity.</returns>
        Entity GetEntity(int id);

        /// <summary>
        /// Adds an entity.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The added entity.</returns>
        Entity AddEntity(Entity entity);

        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>The updated entity.</returns>
        Entity UpdateEntity(Entity entity);

        /// <summary>
        /// Removes an entity.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
        void RemoveEntity(Entity entity);

        /// <summary>
        /// Gets the total entity count.
        /// </summary>
        /// <returns>The total entity count.</returns>
        IDictionary<int, IDictionary<int, int>> GetEntityCountByCreated();
    }
}
