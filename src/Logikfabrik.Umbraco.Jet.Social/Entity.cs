// <copyright file="Entity.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using System;
    using Caching;

    /// <summary>
    /// Represents an entity.
    /// </summary>
    public abstract class Entity
    {
        private DateTime _created;
        private DateTime _updated;
        private EntityStatus _status;

        /// <summary>
        /// Initializes a new instance of the <see cref="Entity" /> class.
        /// </summary>
        protected Entity()
        {
            _created = DateTime.Now;
            _updated = DateTime.Now;
            _status = EntityStatus.Pending;
        }

        /// <summary>
        /// Gets the entity ID.
        /// </summary>
        public int Id { get; internal set; }

        /// <summary>
        /// Gets or sets the date the entity was created.
        /// </summary>
        public DateTime Created
        {
            get
            {
                return _created;
            }

            set
            {
                AssertIsWritableClone();
                _created = value;
            }
        }

        /// <summary>
        /// Gets or sets the date the entity was last updated.
        /// </summary>
        public DateTime Updated
        {
            get
            {
                return _updated;
            }

            set
            {
                AssertIsWritableClone();
                _updated = value;
            }
        }

        /// <summary>
        /// Gets or sets the entity status.
        /// </summary>
        public EntityStatus Status
        {
            get
            {
                return _status;
            }

            set
            {
                AssertIsWritableClone();
                _status = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether or not the entity is writable.
        /// </summary>
        public bool IsReadOnly { get; internal set; }

        /// <summary>
        /// Gets the default cache key for an entity.
        /// </summary>
        /// <param name="type">The entity type.</param>
        /// <param name="id">The entity ID.</param>
        /// <returns>The default entity cache key.</returns>
        public static string GetDefaultCacheKey(Type type, int id)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return CacheKeyUtility.CreateCacheKey(new { Type = type, Id = id });
        }

        /// <summary>
        /// Gets a writable clone of the current entity.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <returns>A writable clone of the current entity.</returns>
        public T CreateWritableClone<T>()
            where T : Entity
        {
            return CreateWritableClone() as T;
        }

        /// <summary>
        /// Gets cache keys for the current entity.
        /// </summary>
        /// <returns>Cache keys.</returns>
        public abstract string[] GetCacheKeys();

        /// <summary>
        /// Asserts that the entity is a writable clone.
        /// </summary>
        protected void AssertIsWritableClone()
        {
            if (!IsReadOnly)
            {
                return;
            }

            throw new Exception($"Entity of type {GetType()} is read-only. Create a writable clone to update the entity.");
        }

        /// <summary>
        /// Gets a clone of the current entity.
        /// </summary>
        /// <returns>A clone of the current entity.</returns>
        protected abstract Entity Clone();

        /// <summary>
        /// Gets a writable clone of the current entity.
        /// </summary>
        /// <returns>A writable clone of the current entity.</returns>
        private Entity CreateWritableClone()
        {
            var clone = Clone();

            if (clone == this)
            {
                throw new Exception("The clone cannot be the current entity instance.");
            }

            clone.Id = Id;
            clone.IsReadOnly = false;
            clone.Created = _created;
            clone.Updated = _updated;
            clone.Status = _status;

            return clone;
        }
    }
}
