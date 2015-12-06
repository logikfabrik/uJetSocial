// <copyright file="DataTransferObjectProviderFactory.cs" company="Logikfabrik">
//  Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Data
{
    using System;
    using System.Collections.Concurrent;

    /// <summary>
    /// The <see cref="DataTransferObjectProviderFactory" /> class.
    /// </summary>
    public class DataTransferObjectProviderFactory
    {
        private readonly Lazy<ConcurrentDictionary<Type, IDataTransferObjectProvider>> _dataTransferObjectProvider;

        private DataTransferObjectProviderFactory()
        {
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static DataTransferObjectProviderFactory Instance { get; } = new DataTransferObjectProviderFactory();
    }
}
