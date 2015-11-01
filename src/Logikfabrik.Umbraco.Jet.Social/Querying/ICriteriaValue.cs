// <copyright file="ICriteriaValue.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Querying
{
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// The <see cref="ICriteriaValue" /> interface.
    /// </summary>
    public interface ICriteriaValue
    {
        /// <summary>
        /// Gets the database type.
        /// </summary>
        /// <value>
        /// The database type.
        /// </value>
        DbType DbType { get; }

        /// <summary>
        /// Gets the command format.
        /// </summary>
        /// <returns>The command format.</returns>
        string GetCommandFormat();

        /// <summary>
        /// Gets the command parameters.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>The command parameters.</returns>
        IDictionary<string, object> GetCommandParameters(ICriteria criteria);
    }
}
