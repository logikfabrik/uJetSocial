// <copyright file="SearchQuery.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.UI.Models
{
    using System;

    /// <summary>
    /// The <see cref="SearchQuery" /> class.
    /// </summary>
    public abstract class SearchQuery
    {
        /// <summary>
        /// Gets or sets the from date.
        /// </summary>
        /// <value>
        /// The from date.
        /// </value>
        public DateTime? From { get; set; }

        /// <summary>
        /// Gets or sets the to date.
        /// </summary>
        /// <value>
        /// The to date.
        /// </value>
        public DateTime? To { get; set; }

        /// <summary>
        /// Gets or sets the page index.
        /// </summary>
        /// <value>
        /// The page index.
        /// </value>
        public int PageIndex { get; set; }

        /// <summary>
        /// Gets or sets the page size.
        /// </summary>
        /// <value>
        /// The page size.
        /// </value>
        public int PageSize { get; set; }
    }
}
