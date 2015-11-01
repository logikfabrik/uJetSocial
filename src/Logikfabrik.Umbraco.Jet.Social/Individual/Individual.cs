// <copyright file="Individual.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Individual
{
    /// <summary>
    /// The <see cref="Individual" /> class.
    /// </summary>
    public abstract class Individual : Entity
    {
        /// <summary>
        /// Gets the default cache key.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The default cache key.</returns>
        public static string GetDefaultCacheKey(int id)
        {
            return GetDefaultCacheKey(typeof(Individual), id);
        }

        /// <summary>
        /// Gets the cache keys.
        /// </summary>
        /// <returns>
        /// The cache keys.
        /// </returns>
        public override string[] GetCacheKeys()
        {
            return new[] { GetDefaultCacheKey(Id) };
        }
    }
}