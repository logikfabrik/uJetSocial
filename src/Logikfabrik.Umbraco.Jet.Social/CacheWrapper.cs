// <copyright file="CacheWrapper.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using System;
    using global::Umbraco.Core.Cache;

    /// <summary>
    /// The <see cref="CacheWrapper" /> class.
    /// </summary>
    public class CacheWrapper : ICacheWrapper
    {
        private readonly IRuntimeCacheProvider _cacheProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheWrapper" /> class.
        /// </summary>
        /// <param name="cacheProvider">The cache provider.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="cacheProvider" /> is <c>null</c>.</exception>
        public CacheWrapper(IRuntimeCacheProvider cacheProvider)
        {
            if (cacheProvider == null)
            {
                throw new ArgumentNullException(nameof(cacheProvider));
            }

            _cacheProvider = cacheProvider;
        }

        /// <summary>
        /// Gets a data transfer object from cache.
        /// </summary>
        /// <typeparam name="T">The data transfer object type.</typeparam>
        /// <param name="cacheKey">The data transfer object cache key.</param>
        /// <returns>The data transfer object.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="cacheKey" /> is <c>null</c> or white space.</exception>
        public T GetObject<T>(string cacheKey)
            where T : DataTransferObject
        {
            if (string.IsNullOrWhiteSpace(cacheKey))
            {
                throw new ArgumentException("Cache key cannot be null or white space.", nameof(cacheKey));
            }

            var dto = _cacheProvider.GetCacheItem(cacheKey) as T;

            return dto;
        }

        /// <summary>
        /// Adds a data transfer object to cache.
        /// </summary>
        /// <typeparam name="T">The data transfer object type.</typeparam>
        /// <param name="dto">The data transfer object to add.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="dto" /> is <c>null</c>.</exception>
        public void AddObject<T>(T dto)
            where T : DataTransferObject
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var cacheKey = CacheKeyFactory.GetKey<T>(dto.Id);

            _cacheProvider.InsertCacheItem(cacheKey, () => dto);
        }

        /// <summary>
        /// Removes a data transfer object from cache.
        /// </summary>
        /// <typeparam name="T">The data transfer object type.</typeparam>
        /// <param name="dto">The data transfer object to remove.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="dto" /> is <c>null</c>.</exception>
        public void RemoveObject<T>(T dto)
            where T : DataTransferObject
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var cacheKey = CacheKeyFactory.GetKey<T>(dto.Id);

            RemoveObject<T>(cacheKey);
        }

        /// <summary>
        /// Removes a data transfer object from cache.
        /// </summary>
        /// <typeparam name="T">The data transfer object type.</typeparam>
        /// <param name="cacheKey">The data transfer object cache key.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="cacheKey" /> is <c>null</c> or white space.</exception>
        public void RemoveObject<T>(string cacheKey)
            where T : DataTransferObject
        {
            if (string.IsNullOrWhiteSpace(cacheKey))
            {
                throw new ArgumentException("Cache key cannot be null or white space.", nameof(cacheKey));
            }

            var dto = _cacheProvider.GetCacheItem(cacheKey) as T;

            if (dto == null)
            {
                return;
            }

            _cacheProvider.ClearCacheItem(cacheKey);
        }
    }
}
