// <copyright file="GroupQuery.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Models.Querying
{
    /// <summary>
    /// The <see cref="GroupQuery" /> class.
    /// </summary>
    public class GroupQuery : DataTransferObjectQuery
    {
        /// <summary>
        /// Gets or sets the name to query by.
        /// </summary>
        /// <value>
        /// The name to query by.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description to query by.
        /// </summary>
        /// <value>
        /// The description to query by.
        /// </value>
        public string Description { get; set; }
    }
}
