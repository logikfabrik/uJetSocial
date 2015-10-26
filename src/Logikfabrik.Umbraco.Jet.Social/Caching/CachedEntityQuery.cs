// <copyright file="CachedEntityQuery.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Caching
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The <see cref="CachedEntityQuery" /> class. Represents a cached entity query.
    /// </summary>
    public class CachedEntityQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CachedEntityQuery" /> class.
        /// </summary>
        /// <param name="cacheKeys">The cache keys of the entities this instance is for.</param>
        /// <param name="total">The total.</param>
        public CachedEntityQuery(IEnumerable<string> cacheKeys, int total)
        {
            if (cacheKeys == null)
            {
                throw new ArgumentNullException(nameof(cacheKeys));
            }

            CacheKeys = cacheKeys;
            Total = total;
        }

        /// <summary>
        /// Gets the cache keys.
        /// </summary>
        public IEnumerable<string> CacheKeys { get; }

        /// <summary>
        /// Gets the total.
        /// </summary>
        public int Total { get; }
    }
}
