// <copyright file="UmbracoQuery.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Models.Querying
{
    /// <summary>
    /// The <see cref="UmbracoQuery" /> class.
    /// </summary>
    public class UmbracoQuery : PagedQuery
    {
        /// <summary>
        /// Gets or sets the name to query by.
        /// </summary>
        /// <value>
        /// The name to query by.
        /// </value>
        public string Name { get; set; }
    }
}
