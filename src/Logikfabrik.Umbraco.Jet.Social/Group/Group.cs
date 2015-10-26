// <copyright file="Group.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Group
{
    using System;

    /// <summary>
    /// Represents a group.
    /// </summary>
    public class Group : Entity
    {
        private string _name;
        private string _description;
        private Individual.Individual _owner;

        /// <summary>
        /// Initializes a new instance of the <see cref="Group" /> class.
        /// </summary>
        /// <param name="owner">An owner.</param>
        public Group(Individual.Individual owner)
        {
            if (owner == null)
            {
                throw new ArgumentException("owner");
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
                    throw new ArgumentException("value");
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
        /// Gets the default cache key for a group.
        /// </summary>
        /// <param name="id">The group ID.</param>
        /// <returns>The default group cache key.</returns>
        public static string GetDefaultCacheKey(int id)
        {
            return GetDefaultCacheKey(typeof(Group), id);
        }

        /// <summary>
        /// Gets cache keys for the current group.
        /// </summary>
        /// <returns>Cache keys.</returns>
        public override string[] GetCacheKeys()
        {
            return new[] { GetDefaultCacheKey(Id) };
        }

        /// <summary>
        /// Gets a clone of the current entity.
        /// </summary>
        /// <returns>A clone of the current entity.</returns>
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
