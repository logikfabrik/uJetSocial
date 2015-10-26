// <copyright file="EntityValidator.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using System;

    /// <summary>
    /// Utility class for entity validation.
    /// </summary>
    public static class EntityValidator
    {
        public static bool EntityHasId(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return IsValidId(entity.Id);
        }

        public static bool CanGetEntity(int id)
        {
            return IsValidId(id);
        }

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

        public static bool CanUpdateEntity(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return !entity.IsReadOnly && EntityHasId(entity);
        }

        public static bool CanRemoveEntity(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return entity.IsReadOnly && EntityHasId(entity);
        }

        /// <summary>
        /// Gets whether or not the given ID is valid.
        /// </summary>
        /// <param name="id">The ID to validate.</param>
        /// <returns>True if the ID is valid; otherwise false.</returns>
        private static bool IsValidId(int id)
        {
            return id != default(int);
        }
    }
}
