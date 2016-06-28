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

        public T GetObject<T>(string cacheKey)
            where T : DataTransferObject
        {
            throw new NotImplementedException();
        }

        public void AddObject<T>(T dto)
            where T : DataTransferObject
        {
            throw new NotImplementedException();
        }

        public void AddObject<T>(T dto, string[] cacheKeys)
            where T : DataTransferObject
        {
            throw new NotImplementedException();
        }

        public void RemoveObject<T>(T dto)
            where T : DataTransferObject
        {
            throw new NotImplementedException();
        }

        public void UpdateObject<T>(T dto)
            where T : DataTransferObject
        {
            throw new NotImplementedException();
        }
    }
}
