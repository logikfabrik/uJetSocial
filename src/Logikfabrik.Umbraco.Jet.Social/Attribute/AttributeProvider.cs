// <copyright file="AttributeProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Attribute
{
    using System;

    /// <summary>
    /// The <see cref="AttributeProvider" /> class.
    /// </summary>
    public class AttributeProvider : DataTransferObjectProvider<Attribute>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeProvider" /> class.
        /// </summary>
        /// <param name="cache">The cache.</param>
        /// <param name="database">The database.</param>
        public AttributeProvider(
            Func<ICacheWrapper> cache,
            Func<IDatabaseWrapper> database)
            : base(cache, database)
        {
        }
    }
}
