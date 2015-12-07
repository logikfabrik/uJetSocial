// <copyright file="CommentExtensions.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Comment
{
    using System;

    /// <summary>
    /// The <see cref="CommentExtensions" /> class.
    /// </summary>
    public static class CommentExtensions
    {
        /// <summary>
        /// Gets the commented entity.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <returns>The commented entity.</returns>
        public static DataTransferObject GetEntity(this Comment comment)
        {
            // TODO: Get entity.
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the commented entity.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <param name="value">The entity.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value" /> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="value" /> is not read-only.</exception>
        public static void SetEntity(this Comment comment, DataTransferObject value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (!value.IsReadOnly)
            {
                throw new InvalidOperationException("The specified data transfer object is not read-only.");
            }

            comment.EntityId = value.Id;
        }

        /// <summary>
        /// Gets the author.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <returns>The author.</returns>
        public static Individual.Individual GetAuthor(this Comment comment)
        {
            // TODO: Get author.
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the author.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <param name="value">The author.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value" /> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="value" /> is not read-only.</exception>
        public static void SetAuthor(this Comment comment, Individual.Individual value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (value.IsReadOnly)
            {
                throw new InvalidOperationException("The specified data transfer object is not read-only.");
            }

            comment.AuthorId = value.Id;
        }
    }
}