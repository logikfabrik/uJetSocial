// <copyright file="ICacheManager.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Caching
{
    using System.Collections.Generic;

    /// <summary>
    /// The <see cref="ICacheManager" /> class.
    /// </summary>
    public interface ICacheManager
    {
        /// <summary>
        /// Gets an entity from cache.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <param name="cacheKey">The entity cache key.</param>
        /// <returns>The entity.</returns>
        T GetEntity<T>(string cacheKey)
            where T : Entity;

        /// <summary>
        /// Adds an entity to cache.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <param name="entity">The entity to add.</param>
        void AddEntity<T>(T entity)
            where T : Entity;

        /// <summary>
        /// Adds an entity to cache.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <param name="entity">The entity to add.</param>
        /// <param name="cacheKeys">The entity cache key.</param>
        void AddEntity<T>(T entity, string[] cacheKeys)
            where T : Entity;

        /// <summary>
        /// Removes a cached entity.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <param name="entity">The entity to remove.</param>
        void RemoveEntity<T>(T entity)
            where T : Entity;

        /// <summary>
        /// Updates a cached entity.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <param name="entity">The entity to update.</param>
        void UpdateEntity<T>(T entity)
            where T : Entity;

        /// <summary>
        /// Gets an entity query from cache.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <param name="cacheKey">The entity query cache key.</param>
        /// <param name="total">The total.</param>
        /// <returns>The entities.</returns>
        IEnumerable<T> GetEntityQuery<T>(string cacheKey, out int total)
            where T : Entity;

        /// <summary>
        /// Adds a entity query to cache.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <param name="entities">The entity query to add.</param>
        /// <param name="total">The total.</param>
        /// <param name="cacheKey">The entity query cache key.</param>
        void AddEntityQuery<T>(IEnumerable<T> entities, int total, string cacheKey)
            where T : Entity;

        /// <summary>
        /// Removes a cached entity query.
        /// </summary>
        /// <param name="cacheKey">The entity query cache key.</param>
        void RemoveEntityQuery(string cacheKey);
    }
}
