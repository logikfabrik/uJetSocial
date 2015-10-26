// <copyright file="CacheManager.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Caching
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using global::Umbraco.Core;
    using global::Umbraco.Core.Cache;

    /// <summary>
    /// The <see cref="CacheManager" /> class. The default cache manager, using a <see cref="IRuntimeCacheProvider" /> implementation.
    /// </summary>
    public class CacheManager : ICacheManager
    {
        /// <summary>
        /// The runtime cache provider.
        /// </summary>
        private readonly IRuntimeCacheProvider _runtimeCacheProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheManager" /> class.
        /// </summary>
        public CacheManager()
            : this(ApplicationContext.Current.ApplicationCache.RuntimeCache)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheManager" /> class.
        /// </summary>
        /// <param name="runtimeCacheProvider">The runtime cache provider to use.</param>
        public CacheManager(IRuntimeCacheProvider runtimeCacheProvider)
        {
            if (runtimeCacheProvider == null)
            {
                throw new ArgumentNullException(nameof(runtimeCacheProvider));
            }

            _runtimeCacheProvider = runtimeCacheProvider;
        }

        /// <summary>
        /// Gets an entity from cache.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <param name="cacheKey">The entity cache key.</param>
        /// <returns>The entity.</returns>
        public T GetEntity<T>(string cacheKey)
            where T : Entity
        {
            if (string.IsNullOrWhiteSpace(cacheKey))
            {
                throw new ArgumentException("Cache key cannot be null or white space.", nameof(cacheKey));
            }

            var cachedEntity = _runtimeCacheProvider.GetCacheItem(cacheKey) as CachedEntity;

            return (T)cachedEntity?.Entity;
        }

        /// <summary>
        /// Adds an entity to cache.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <param name="entity">The entity to add.</param>
        public void AddEntity<T>(T entity)
            where T : Entity
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var cacheKeys = entity.GetCacheKeys();

            AddEntity(entity, cacheKeys);
        }

        /// <summary>
        /// Adds an entity to cache.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <param name="entity">The entity to add.</param>
        /// <param name="cacheKeys">The entity cache key.</param>
        public void AddEntity<T>(T entity, string[] cacheKeys)
            where T : Entity
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            // TODO: Will cache the same object multiple times, using different keys. Should be rewritten so that an object is only cached once.
            foreach (var cacheKey in cacheKeys)
            {
                _runtimeCacheProvider.InsertCacheItem(cacheKey, () => new CachedEntity(entity));
            }
        }

        /// <summary>
        /// Removes a cached entity.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <param name="entity">The entity to remove.</param>
        public void RemoveEntity<T>(T entity)
            where T : Entity
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            foreach (var cacheKey in entity.GetCacheKeys())
            {
                _runtimeCacheProvider.ClearCacheItem(cacheKey);
            }
        }

        /// <summary>
        /// Updates a cached entity.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <param name="entity">The entity to update.</param>
        public void UpdateEntity<T>(T entity)
            where T : Entity
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            AddEntity(entity);
        }

        /// <summary>
        /// Gets an entity query from cache.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <param name="cacheKey">The entity query cache key.</param>
        /// <param name="total">The total.</param>
        /// <returns>The entities.</returns>
        public IEnumerable<T> GetEntityQuery<T>(string cacheKey, out int total)
            where T : Entity
        {
            if (string.IsNullOrWhiteSpace(cacheKey))
            {
                throw new ArgumentException("Cache key cannot be null or white space.", nameof(cacheKey));
            }

            var cachedEntityQuery = _runtimeCacheProvider.GetCacheItem(cacheKey) as CachedEntityQuery;

            if (cachedEntityQuery == null)
            {
                total = default(int);
                return null;
            }

            total = cachedEntityQuery.Total;

            return cachedEntityQuery.CacheKeys.Select(key =>
            {
                var cachedEntity = _runtimeCacheProvider.GetCacheItem(key) as CachedEntity;

                return (T)cachedEntity?.Entity;
            });
        }

        /// <summary>
        /// Adds a entity query to cache.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <param name="entities">The entity query to add.</param>
        /// <param name="total">The total.</param>
        /// <param name="cacheKey">The entity query cache key.</param>
        public void AddEntityQuery<T>(IEnumerable<T> entities, int total, string cacheKey)
            where T : Entity
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            if (string.IsNullOrWhiteSpace(cacheKey))
            {
                throw new ArgumentException("Cache key cannot be null or white space.", nameof(cacheKey));
            }

            var e = entities.ToArray();

            foreach (var entity in e)
            {
                AddEntity(entity); // Calling AddEntity(...) will add/update the entities returned by the query in the cache.
            }

            var cacheKeys = e.Select(entity => entity.GetCacheKeys().First());

            _runtimeCacheProvider.InsertCacheItem(cacheKey, () => new CachedEntityQuery(cacheKeys, total));
        }

        /// <summary>
        /// Removes a cached entity query.
        /// </summary>
        /// <param name="cacheKey">The entity query cache key.</param>
        public void RemoveEntityQuery(string cacheKey)
        {
            if (string.IsNullOrWhiteSpace(cacheKey))
            {
                throw new ArgumentException("Cache key cannot be null or white space.", nameof(cacheKey));
            }

            _runtimeCacheProvider.ClearCacheItem(cacheKey);
        }
    }
}