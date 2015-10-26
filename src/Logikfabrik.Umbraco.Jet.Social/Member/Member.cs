// <copyright file="Member.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Member
{
    using System;
    using Caching;

    /// <summary>
    /// Represents a member.
    /// </summary>
    public class Member : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Member" /> class.
        /// </summary>
        /// <param name="providerUserKey">A provider user key.</param>
        public Member(object providerUserKey)
        {
            if (providerUserKey == null)
            {
                throw new ArgumentException("providerUserKey");
            }

            ProviderUserKey = providerUserKey;
        }

        /// <summary>
        /// Gets the provider user key.
        /// </summary>
        public object ProviderUserKey { get; }

        /// <summary>
        /// Gets cache keys for a member.
        /// </summary>
        /// <param name="id">The member ID.</param>
        /// <param name="providerUserKey">The provider user key.</param>
        /// <returns>The member cache keys.</returns>
        public static string[] GetCacheKeys(int id, object providerUserKey)
        {
            return new[]
            {
                GetDefaultCacheKey(id),
                GetDefaultCacheKey(providerUserKey)
            };
        }

        /// <summary>
        /// Gets the default cache key for a member.
        /// </summary>
        /// <param name="id">The member ID.</param>
        /// <returns>The default member cache key.</returns>
        public static string GetDefaultCacheKey(int id)
        {
            return GetDefaultCacheKey(typeof(Member), id);
        }

        /// <summary>
        /// Gets the default cache key for a member.
        /// </summary>
        /// <param name="providerUserKey">The member provider user key.</param>
        /// <returns>The default member cache key.</returns>
        public static string GetDefaultCacheKey(object providerUserKey)
        {
            if (providerUserKey == null)
            {
                throw new ArgumentNullException(nameof(providerUserKey));
            }

            return CacheKeyUtility.CreateCacheKey(new { Type = typeof(Member), ProviderUserKey = providerUserKey });
        }

        /// <summary>
        /// Gets cache keys for the current member.
        /// </summary>
        /// <returns>Cache keys.</returns>
        public override string[] GetCacheKeys()
        {
            return GetCacheKeys(Id, ProviderUserKey);
        }

        /// <summary>
        /// Gets a clone of the current entity.
        /// </summary>
        /// <returns>A clone of the current entity.</returns>
        protected override Entity Clone()
        {
            var clone = new Member(ProviderUserKey);

            return clone;
        }
    }
}
