// <copyright file="OwnableExtensions.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using System;

    /// <summary>
    /// The <see cref="OwnableExtensions" /> class.
    /// </summary>
    public static class OwnableExtensions
    {
        /// <summary>
        /// Sets the owner.
        /// </summary>
        /// <param name="ownable">The ownable.</param>
        /// <param name="value">The owner.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value" /> is <c>null</c>.</exception>
        public static void SetOwner(this IOwnable ownable, Individual.Individual value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            DataTransferObjectValidator.ThrowIfNotReadOnly(value);

            ownable.OwnerId = value.Id;
            ownable.OwnerType = value.GetType();
        }

        /// <summary>
        /// Gets the owner.
        /// </summary>
        /// <param name="ownable">The ownable.</param>
        /// <returns>The owner.</returns>
        public static Individual.Individual GetOwner(this IOwnable ownable)
        {
            return ownable.OwnerType == null
                ? null
                : GetOwner(ownable, DataTransferObjectProviders.GetProvider(ownable.OwnerType));
        }

        /// <summary>
        /// Gets the owner.
        /// </summary>
        /// <param name="ownable">The ownable.</param>
        /// <param name="provider">The provider.</param>
        /// <returns>The owner.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="provider" /> is <c>null</c>.</exception>
        public static Individual.Individual GetOwner(this IOwnable ownable, IDataTransferObjectProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            return provider.Get(ownable.OwnerId) as Individual.Individual;
        }
    }
}
