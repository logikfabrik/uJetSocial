// <copyright file="CacheWrapperFactory.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    /// <summary>
    /// The <see cref="CacheWrapperFactory" /> class.
    /// </summary>
    public static class CacheWrapperFactory
    {
        /// <summary>
        /// Gets the cache.
        /// </summary>
        /// <returns>The cache.</returns>
        public static ICacheWrapper GetCache()
        {
            var cacheProvider = global::Umbraco.Core.ApplicationContext.Current.ApplicationCache.RuntimeCache;

            return new CacheWrapper(cacheProvider);
        }
    }
}
