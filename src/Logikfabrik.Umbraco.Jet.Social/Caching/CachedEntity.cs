// <copyright file="CachedEntity.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Caching
{
    using System;

    /// <summary>
    /// The <see cref="CachedEntity" /> class. Represents a cached entity.
    /// </summary>
    public class CachedEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CachedEntity" /> class.
        /// </summary>
        /// <param name="entity">The entity this instance is for.</param>
        public CachedEntity(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Entity = entity;
        }

        /// <summary>
        /// Gets the entity.
        /// </summary>
        /// <value>
        /// The entity.
        /// </value>
        public Entity Entity { get; }
    }
}
