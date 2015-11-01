// <copyright file="Member.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Member
{
    using System;
    using Caching;

    /// <summary>
    /// The <see cref="Member" /> class.
    /// </summary>
    public class Member : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Member" /> class.
        /// </summary>
        /// <param name="providerUserKey">The provider user key.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="providerUserKey" /> is <c>null</c>.</exception>
        public Member(object providerUserKey)
        {
            if (providerUserKey == null)
            {
                throw new ArgumentNullException(nameof(providerUserKey));
            }

            ProviderUserKey = providerUserKey;
        }

        /// <summary>
        /// Gets the provider user key.
        /// </summary>
        /// <value>
        /// The provider user key.
        /// </value>
        public object ProviderUserKey { get; }

        /// <summary>
        /// Gets the cache keys.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="providerUserKey">The provider user key.</param>
        /// <returns>The cache keys.</returns>
        public static string[] GetCacheKeys(int id, object providerUserKey)
        {
            return new[]
            {
                GetDefaultCacheKey(id),
                GetDefaultCacheKey(providerUserKey)
            };
        }

        /// <summary>
        /// Gets the default cache key.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The default cache key.</returns>
        public static string GetDefaultCacheKey(int id)
        {
            return GetDefaultCacheKey(typeof(Member), id);
        }

        /// <summary>
        /// Gets the default cache key.
        /// </summary>
        /// <param name="providerUserKey">The provider user key.</param>
        /// <returns>The default cache key.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="providerUserKey" /> is <c>null</c>.</exception>
        public static string GetDefaultCacheKey(object providerUserKey)
        {
            if (providerUserKey == null)
            {
                throw new ArgumentNullException(nameof(providerUserKey));
            }

            return CacheKeyUtility.CreateCacheKey(new { Type = typeof(Member), ProviderUserKey = providerUserKey });
        }

        /// <summary>
        /// Gets the cache keys.
        /// </summary>
        /// <returns>
        /// The cache keys.
        /// </returns>
        public override string[] GetCacheKeys()
        {
            return GetCacheKeys(Id, ProviderUserKey);
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A writable clone of this instance.
        /// </returns>
        protected override Entity Clone()
        {
            var clone = new Member(ProviderUserKey);

            return clone;
        }
    }
}
