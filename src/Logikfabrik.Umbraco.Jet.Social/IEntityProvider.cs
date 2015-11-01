// <copyright file="IEntityProvider.cs" company="Logikfabrik">
// Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The <see cref="IEntityProvider" /> interface.
    /// </summary>
    public interface IEntityProvider
    {
        /// <summary>
        /// Gets the entity type this instance supports.
        /// </summary>
        /// <value>
        /// The entity type this instance supports.
        /// </value>
        Type EntityType { get; }

        /// <summary>
        /// Gets the entity with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The entity.</returns>
        Entity GetEntity(int id);

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The added entity.</returns>
        Entity AddEntity(Entity entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The updated entity.</returns>
        Entity UpdateEntity(Entity entity);

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void RemoveEntity(Entity entity);

        /// <summary>
        /// Gets the entity count by created.
        /// </summary>
        /// <returns>The entity count by created.</returns>
        IDictionary<int, IDictionary<int, int>> GetEntityCountByCreated();
    }
}
