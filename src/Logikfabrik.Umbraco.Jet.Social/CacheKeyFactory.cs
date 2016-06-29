// <copyright file="CacheKeyFactory.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using System;

    /// <summary>
    /// The <see cref="CacheKeyFactory" /> class.
    /// </summary>
    public static class CacheKeyFactory
    {
        /// <summary>
        /// Gets a key for the specified object type and identifier.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>A cache key.</returns>
        public static string GetKey<T>(int id)
            where T : DataTransferObject
        {
            return GetKey(typeof(T), id);
        }

        private static string GetKey(Type type, int id)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return $"{type}_{id}";
        }
    }
}
