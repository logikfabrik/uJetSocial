// <copyright file="IAuthorable.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using System;

    /// <summary>
    /// The <see cref="IAuthorable" /> interface.
    /// </summary>
    public interface IAuthorable
    {
        /// <summary>
        /// Gets or sets the author identifier.
        /// </summary>
        /// <value>
        /// The author identifier.
        /// </value>
        int AuthorId { get; set; }

        /// <summary>
        /// Gets or sets the author type.
        /// </summary>
        /// <value>
        /// The author type.
        /// </value>
        Type AuthorType { get; set; }
    }
}