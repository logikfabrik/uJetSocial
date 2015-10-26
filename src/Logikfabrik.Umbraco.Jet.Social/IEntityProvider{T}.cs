// <copyright file="IEntityProvider{T}.cs" company="Logikfabrik">
// Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    /// <summary>
    /// Represents the entity provider interface.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    public interface IEntityProvider<T> : IEntityProvider
        where T : Entity
    {
        /// <summary>
        /// Gets an entity.
        /// </summary>
        /// <param name="id">The entity ID.</param>
        /// <returns>An entity.</returns>
        new T GetEntity(int id);

        /// <summary>
        /// Adds an entity.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The added entity.</returns>
        T AddEntity(T entity);

        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>The updated entity.</returns>
        T UpdateEntity(T entity);

        /// <summary>
        /// Removes an entity.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
        void RemoveEntity(T entity);
    }
}
