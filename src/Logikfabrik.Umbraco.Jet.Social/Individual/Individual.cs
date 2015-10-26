// <copyright file="Individual.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Individual
{
    /// <summary>
    /// Represents a individual.
    /// </summary>
    public abstract class Individual : Entity
    {
        /// <summary>
        /// Gets the default cache key for an individual.
        /// </summary>
        /// <param name="id">The individual ID.</param>
        /// <returns>The default individual cache key.</returns>
        public static string GetDefaultCacheKey(int id)
        {
            return GetDefaultCacheKey(typeof(Individual), id);
        }

        /// <summary>
        /// Gets cache keys for the current individual.
        /// </summary>
        /// <returns>Cache keys.</returns>
        public override string[] GetCacheKeys()
        {
            return new[] { GetDefaultCacheKey(Id) };
        }
    }
}