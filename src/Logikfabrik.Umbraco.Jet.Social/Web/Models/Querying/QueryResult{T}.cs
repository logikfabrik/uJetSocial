// <copyright file="QueryResult{T}.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Models.Querying
{
    using System.Collections.Generic;

    /// <summary>
    /// The <see cref="QueryResult{T}" /> class.
    /// </summary>
    /// <typeparam name="T">The data transfer object type.</typeparam>
    public class QueryResult<T>
        where T : DataTransferObject
    {
        /// <summary>
        /// Gets or sets the total number of objects.
        /// </summary>
        /// <value>
        /// The total number of objects.
        /// </value>
        public long Total { get; set; }

        /// <summary>
        /// Gets or sets the objects.
        /// </summary>
        /// <value>
        /// The objects.
        /// </value>
        public IEnumerable<T> Objects { get; set; }
    }
}
