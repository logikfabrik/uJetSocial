// <copyright file="EntityValidator.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using System;

    /// <summary>
    /// The <see cref="EntityValidator" /> class. Utility class for entity validation on provider operations.
    /// </summary>
    public static class EntityValidator
    {
        /// <summary>
        /// Determines whether the specified entity has a valid identifier.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if the entity identifier is valid; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="entity" /> is <c>null</c>.</exception>
        public static bool EntityHasId(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return IsValidId(entity.Id);
        }

        /// <summary>
        /// Determines whether an entity can be gotten using the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if an entity can be gotten using the specified identifier; otherwise, <c>false</c>.</returns>
        public static bool CanGetEntity(int id)
        {
            return IsValidId(id);
        }

        /// <summary>
        /// Determines whether the specified entity can be added.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if the specified entity can be added; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="entity" /> is <c>null</c>.</exception>
        public static bool CanAddEntity(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (entity.IsReadOnly)
            {
                return false;
            }

            return !EntityHasId(entity);
        }

        /// <summary>
        /// Determines whether the specified entity can be updated
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if the specified entity can be updated; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="entity" /> is <c>null</c>.</exception>
        public static bool CanUpdateEntity(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return !entity.IsReadOnly && EntityHasId(entity);
        }

        /// <summary>
        /// Determines whether the specified entity can be removed.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if the specified entity can be removed; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="entity" /> is <c>null</c>.</exception>
        public static bool CanRemoveEntity(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return entity.IsReadOnly && EntityHasId(entity);
        }

        /// <summary>
        /// Determines whether the specified identifier is valid.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if the identifier is valid; otherwise, <c>false</c>.</returns>
        private static bool IsValidId(int id)
        {
            return id != default(int);
        }
    }
}
