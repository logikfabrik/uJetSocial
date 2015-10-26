// <copyright file="ICriteria.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Querying
{
    /// <summary>
    /// Represents the criteria interface.
    /// </summary>
    public interface ICriteria
    {
        /// <summary>
        /// Gets the column name.
        /// </summary>
        string ColumnName { get; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        ICriteriaValue Value { get; set; }

        /// <summary>
        /// Gets the command text.
        /// </summary>
        /// <returns>The command text.</returns>
        string GetCommandText();

        /// <summary>
        /// Gets the cache key.
        /// </summary>
        /// <returns>The cache key.</returns>
        string GetCacheKey();
    }
}
