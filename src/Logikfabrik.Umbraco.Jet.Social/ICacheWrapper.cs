// <copyright file="ICacheWrapper.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    /// <summary>
    /// The <see cref="ICacheWrapper" /> interface.
    /// </summary>
    public interface ICacheWrapper
    {
        /// <summary>
        /// Gets a data transfer object from cache.
        /// </summary>
        /// <typeparam name="T">The data transfer object type.</typeparam>
        /// <param name="cacheKey">The data transfer object cache key.</param>
        /// <returns>The data transfer object.</returns>
        T GetObject<T>(string cacheKey)
            where T : DataTransferObject;

        /// <summary>
        /// Adds a data transfer object to cache.
        /// </summary>
        /// <typeparam name="T">The data transfer object type.</typeparam>
        /// <param name="dto">The data transfer object to add.</param>
        void AddObject<T>(T dto)
            where T : DataTransferObject;

        /// <summary>
        /// Adds a data transfer object to cache.
        /// </summary>
        /// <typeparam name="T">The data transfer object type.</typeparam>
        /// <param name="dto">The data transfer object to add.</param>
        /// <param name="cacheKeys">The data transfer object cache key.</param>
        void AddObject<T>(T dto, string[] cacheKeys)
            where T : DataTransferObject;

        /// <summary>
        /// Removes a data transfer object from cache.
        /// </summary>
        /// <typeparam name="T">The data transfer object type.</typeparam>
        /// <param name="dto">The data transfer object to remove.</param>
        void RemoveObject<T>(T dto)
            where T : DataTransferObject;

        /// <summary>
        /// Updates a data transfer object in cache.
        /// </summary>
        /// <typeparam name="T">The data transfer object type.</typeparam>
        /// <param name="dto">The data transfer object to update.</param>
        void UpdateObject<T>(T dto)
            where T : DataTransferObject;
    }
}
