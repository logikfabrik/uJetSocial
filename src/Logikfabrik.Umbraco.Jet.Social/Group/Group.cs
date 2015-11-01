// <copyright file="Group.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Group
{
    using System;

    /// <summary>
    /// The <see cref="Group" /> class.
    /// </summary>
    public class Group : Entity
    {
        private string _name;
        private string _description;
        private Individual.Individual _owner;

        /// <summary>
        /// Initializes a new instance of the <see cref="Group" /> class.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="owner" /> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="owner" /> has an invalid identifier, or is writable.</exception>
        public Group(Individual.Individual owner)
        {
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }

            if (!EntityValidator.EntityHasId(owner))
            {
                throw new ArgumentException("Owner must have a valid ID.", nameof(owner));
            }

            if (!owner.IsReadOnly)
            {
                throw new ArgumentException("Owner must be read-only.", nameof(owner));
            }

            _owner = owner;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                AssertIsWritableClone();
                _name = value;
            }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                AssertIsWritableClone();
                _description = value;
            }
        }

        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        /// <value>
        /// The owner.
        /// </value>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value" /> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value" /> has an invalid identifier, or is writable.</exception>
        public Individual.Individual Owner
        {
            get
            {
                return _owner;
            }

            set
            {
                AssertIsWritableClone();

                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (!EntityValidator.EntityHasId(value))
                {
                    throw new ArgumentException("Value must have a valid ID.", nameof(value));
                }

                if (!value.IsReadOnly)
                {
                    throw new ArgumentException("Value must be read-only.", nameof(value));
                }

                _owner = value;
            }
        }

        /// <summary>
        /// Gets the default cache key.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The default cache key.</returns>
        public static string GetDefaultCacheKey(int id)
        {
            return GetDefaultCacheKey(typeof(Group), id);
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

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A writable clone of this instance.
        /// </returns>
        protected override Entity Clone()
        {
            var clone = new Group(_owner)
            {
                Name = _name,
                Description = _description
            };

            return clone;
        }
    }
}
