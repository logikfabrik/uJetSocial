// <copyright file="Entity.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using System;
    using Caching;

    /// <summary>
    /// The <see cref="Entity" /> class.
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
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; internal set; }

        /// <summary>
        /// Gets or sets the date the <see cref="Entity" /> was created.
        /// </summary>
        /// <value>
        /// The date the <see cref="Entity" /> was created.
        /// </value>
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
        /// Gets or sets the date the <see cref="Entity" /> was last updated.
        /// </summary>
        /// <value>
        /// The date the <see cref="Entity" /> was last updated.
        /// </value>
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
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
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
        /// Gets a value indicating whether this instance is read-only.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is read-only; otherwise, <c>false</c>.
        /// </value>
        public bool IsReadOnly { get; internal set; }

        /// <summary>
        /// Gets the default cache key.
        /// </summary>
        /// <param name="type">The <see cref="Entity" /> type.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>The default cache key.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="type" /> is <c>null</c>.</exception>
        public static string GetDefaultCacheKey(Type type, int id)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return CacheKeyUtility.CreateCacheKey(new { Type = type, Id = id });
        }

        /// <summary>
        /// Gets a writable clone.
        /// </summary>
        /// <typeparam name="T">The <see cref="Entity" /> type.</typeparam>
        /// <returns>A writable clone.</returns>
        public T CreateWritableClone<T>()
            where T : Entity
        {
            return CreateWritableClone() as T;
        }

        /// <summary>
        /// Gets the cache keys.
        /// </summary>
        /// <returns>The cache keys.</returns>
        public abstract string[] GetCacheKeys();

        /// <summary>
        /// Asserts that the entity is a writable clone.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if this instance is read-only.</exception>
        protected void AssertIsWritableClone()
        {
            if (!IsReadOnly)
            {
                return;
            }

            throw new InvalidOperationException($"Entity of type {GetType()} is read-only. Create a writable clone to update the entity.");
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A writable clone of this instance.</returns>
        protected abstract Entity Clone();

        /// <summary>
        /// Creates a writable clone of this instance.
        /// </summary>
        /// <returns>A writable clone of this instance.</returns>
        private Entity CreateWritableClone()
        {
            var clone = Clone();

            clone.Id = Id;
            clone.IsReadOnly = false;
            clone.Created = _created;
            clone.Updated = _updated;
            clone.Status = _status;

            return clone;
        }
    }
}
