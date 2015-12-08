// <copyright file="DataTransferObjectProviders.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using System;

    /// <summary>
    /// The <see cref="DataTransferObjectProviders" /> class.
    /// </summary>
    public static class DataTransferObjectProviders
    {
        /// <summary>
        /// Gets the providers.
        /// </summary>
        /// <value>The providers.</value>
        public static DataTransferObjectProviderDictionary Providers { get; } = GetDefaultProviders();

        /// <summary>
        /// Gets the provider for the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The provider for the specified type.</returns>
        public static IDataTransferObjectProvider GetProvider(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            IDataTransferObjectProvider provider;

            return !Providers.TryGetValue(type, out provider) ? null : provider;
        }

        /// <summary>
        /// Gets the default providers.
        /// </summary>
        /// <returns>The default providers.</returns>
        private static DataTransferObjectProviderDictionary GetDefaultProviders()
        {
            return new DataTransferObjectProviderDictionary();
        }
    }
}
