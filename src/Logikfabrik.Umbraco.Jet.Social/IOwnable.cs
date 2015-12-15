// <copyright file="IOwnable.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using System;

    /// <summary>
    /// The <see cref="IOwnable" /> interface.
    /// </summary>
    public interface IOwnable
    {
        /// <summary>
        /// Gets or sets the owner identifier.
        /// </summary>
        /// <value>
        /// The owner identifier.
        /// </value>
        int OwnerId { get; set; }

        /// <summary>
        /// Gets or sets the owner type.
        /// </summary>
        /// <value>
        /// The owner type.
        /// </value>
        Type OwnerType { get; set; }
    }
}