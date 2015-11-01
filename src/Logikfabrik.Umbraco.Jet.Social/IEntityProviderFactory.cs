// <copyright file="IEntityProviderFactory.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using System;

    /// <summary>
    /// The <see cref="IEntityProviderFactory" /> interface.
    /// </summary>
    public interface IEntityProviderFactory
    {
        /// <summary>
        /// Gets the entity provider for the specified entity type.
        /// </summary>
        /// <param name="entityType">The entity type.</param>
        /// <returns>The entity provider.</returns>
        IEntityProvider GetEntityProvider(Type entityType);

        /// <summary>
        /// Adds the specified entity provider.
        /// </summary>
        /// <param name="entityProvider">The entity provider.</param>
        void AddEntityProvider(IEntityProvider entityProvider);

        /// <summary>
        /// Removes the entity provider for the specified entity type.
        /// </summary>
        /// <param name="entityType">The entity type.</param>
        void RemoveEntityProvider(Type entityType);
    }
}
