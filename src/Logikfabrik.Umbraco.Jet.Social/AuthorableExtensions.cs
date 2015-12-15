// <copyright file="AuthorableExtensions.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using System;

    /// <summary>
    /// The <see cref="AuthorableExtensions" /> class.
    /// </summary>
    public static class AuthorableExtensions
    {
        /// <summary>
        /// Sets the author.
        /// </summary>
        /// <param name="authorable">The authorable.</param>
        /// <param name="value">The author.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value" /> is <c>null</c>.</exception>
        public static void SetAuthor(this IAuthorable authorable, Individual.Individual value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            DataTransferObjectValidator.ThrowIfNotReadOnly(value);

            authorable.AuthorId = value.Id;
            authorable.AuthorType = value.GetType();
        }

        /// <summary>
        /// Gets the author.
        /// </summary>
        /// <param name="authorable">The authorable.</param>
        /// <returns>The author.</returns>
        public static Individual.Individual GetAuthor(this IAuthorable authorable)
        {
            return authorable.AuthorType == null
                ? null
                : GetAuthor(authorable, DataTransferObjectProviders.GetProvider(authorable.AuthorType));
        }

        /// <summary>
        /// Gets the author.
        /// </summary>
        /// <param name="authorable">The authorable.</param>
        /// <param name="provider">The provider.</param>
        /// <returns>The author.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="provider" /> is <c>null</c>.</exception>
        public static Individual.Individual GetAuthor(this IAuthorable authorable, IDataTransferObjectProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            return provider.Get(authorable.AuthorId) as Individual.Individual;
        }
    }
}
