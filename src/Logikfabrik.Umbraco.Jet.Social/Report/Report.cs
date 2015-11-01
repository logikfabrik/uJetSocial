// <copyright file="Report.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Report
{
    using System;

    /// <summary>
    /// The <see cref="Report" /> class.
    /// </summary>
    public class Report : Entity
    {
        private string _text;

        /// <summary>
        /// Initializes a new instance of the <see cref="Report" /> class.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="author">The author.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="entity" /> or <paramref name="author" /> are <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="entity" /> or <paramref name="author" /> have invalid identifiers, or are writable.</exception>
        public Report(Entity entity, Individual.Individual author)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (!EntityValidator.EntityHasId(entity))
            {
                throw new ArgumentException("Entity must have a valid ID.", nameof(entity));
            }

            if (!entity.IsReadOnly)
            {
                throw new ArgumentException("Entity must be read-only.", nameof(entity));
            }

            if (author == null)
            {
                throw new ArgumentNullException(nameof(author));
            }

            if (!EntityValidator.EntityHasId(author))
            {
                throw new ArgumentException("Author must have a valid ID.", nameof(author));
            }

            if (!author.IsReadOnly)
            {
                throw new ArgumentException("Author must be read-only.", nameof(author));
            }

            Author = author;
            Entity = entity;
        }

        /// <summary>
        /// Gets the entity.
        /// </summary>
        /// <value>
        /// The entity.
        /// </value>
        public Entity Entity { get; }

        /// <summary>
        /// Gets the author.
        /// </summary>
        /// <value>
        /// The author.
        /// </value>
        public Individual.Individual Author { get; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text
        {
            get
            {
                return _text;
            }

            set
            {
                AssertIsWritableClone();
                _text = value;
            }
        }

        /// <summary>
        /// Gets the default cache key.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The default cache key.</returns>
        public static string GetDefaultCacheKey(int id)
        {
            return GetDefaultCacheKey(typeof(Report), id);
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
            var clone = new Report(Entity, Author)
            {
                Text = _text
            };

            return clone;
        }
    }
}
