// <copyright file="Comment.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Comment
{
    using System;

    /// <summary>
    /// The <see cref="Comment" /> class. Represents a comment.
    /// </summary>
    public class Comment : Entity
    {
        private string _text;

        /// <summary>
        /// Initializes a new instance of the <see cref="Comment" /> class.
        /// </summary>
        /// <param name="entity">An entity.</param>
        /// <param name="author">An author.</param>
        public Comment(Entity entity, Individual.Individual author)
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
        /// Gets the default cache key for a comment.
        /// </summary>
        /// <param name="id">The comment ID.</param>
        /// <returns>The default comment cache key.</returns>
        public static string GetDefaultCacheKey(int id)
        {
            return GetDefaultCacheKey(typeof(Comment), id);
        }

        /// <summary>
        /// Gets cache keys for the current comment.
        /// </summary>
        /// <returns>Cache keys.</returns>
        public override string[] GetCacheKeys()
        {
            return new[] { GetDefaultCacheKey(Id) };
        }

        /// <summary>
        /// Gets a clone of the current comment.
        /// </summary>
        /// <returns>A clone of the current comment.</returns>
        protected override Entity Clone()
        {
            var clone = new Comment(Entity, Author)
            {
                Text = _text
            };

            return clone;
        }
    }
}