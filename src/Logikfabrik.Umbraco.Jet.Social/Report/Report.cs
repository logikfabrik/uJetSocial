// <copyright file="Report.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Report
{
    using System;

    /// <summary>
    /// Represents a report.
    /// </summary>
    public class Report : Entity
    {
        private string _text;

        /// <summary>
        /// Initializes a new instance of the <see cref="Report" /> class.
        /// </summary>
        /// <param name="entity">An entity.</param>
        /// <param name="author">An author.</param>
        public Report(Entity entity, Individual.Individual author)
        {
            if (entity == null)
            {
                throw new ArgumentException("entity");
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
                throw new ArgumentException("author");
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
        public Entity Entity { get; }

        /// <summary>
        /// Gets the author.
        /// </summary>
        public Individual.Individual Author { get; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
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
        /// Gets the default cache key for a report.
        /// </summary>
        /// <param name="id">The report ID.</param>
        /// <returns>The default report cache key.</returns>
        public static string GetDefaultCacheKey(int id)
        {
            return GetDefaultCacheKey(typeof(Report), id);
        }

        /// <summary>
        /// Gets cache keys for the current report.
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
            var clone = new Report(Entity, Author)
            {
                Text = _text
            };

            return clone;
        }
    }
}
