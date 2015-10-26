// <copyright file="IEntityProviderFactory.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using System;

    /// <summary>
    /// Represents the entity provider factory interface.
    /// </summary>
    public interface IEntityProviderFactory
    {
        /// <summary>
        /// Gets an entity provider for the given entity type.
        /// </summary>
        /// <param name="entityType">An entity type.</param>
        /// <returns>An entity provider.</returns>
        IEntityProvider GetEntityProvider(Type entityType);

        /// <summary>
        /// Adds an entity provider.
        /// </summary>
        /// <param name="entityProvider">The entity provider to add.</param>
        void AddEntityProvider(IEntityProvider entityProvider);

        /// <summary>
        /// Removes an entity provider.
        /// </summary>
        /// <param name="entityType">The entity type for which the entity provider is to be removed.</param>
        void RemoveEntityProvider(Type entityType);
    }
}
