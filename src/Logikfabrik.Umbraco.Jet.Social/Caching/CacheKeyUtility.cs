// <copyright file="CacheKeyUtility.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Caching
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// The <see cref="CacheKeyUtility" /> class. Utility class for entity cache keys.
    /// </summary>
    public static class CacheKeyUtility
    {
        /// <summary>
        /// Creates a cache key using the given object.
        /// </summary>
        /// <param name="obj">The object to create a cache key using.</param>
        /// <returns>A cache key.</returns>
        public static string CreateCacheKey(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return JsonConvert.SerializeObject(obj);
        }
    }
}
