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
        /// Sets the commented entity.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <param name="value">The entity.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value" /> is <c>null</c>.</exception>
        public static void SetEntity(this Comment comment, DataTransferObject value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            DataTransferObjectValidator.ThrowIfNotReadOnly(value);

            comment.EntityId = value.Id;
            comment.EntityType = value.GetType();
        }

        /// <summary>
        /// Gets the commented entity.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <returns>The commented entity.</returns>
        public static DataTransferObject GetEntity(this Comment comment)
        {
            return comment.EntityType == null
                ? null
                : GetEntity(comment, DataTransferObjectProviders.GetProvider(comment.EntityType));
        }

        /// <summary>
        /// Gets the commented entity.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <param name="provider">The provider.</param>
        /// <returns>The commented entity.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="provider" /> is <c>null</c>.</exception>
        public static DataTransferObject GetEntity(this Comment comment, IDataTransferObjectProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            return provider.Get(comment.AuthorId);
        }
    }
}