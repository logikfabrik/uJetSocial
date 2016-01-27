// <copyright file="Query.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Models
{
    using System;

    /// <summary>
    /// The <see cref="Query" /> class.
    /// </summary>
    public abstract class Query
    {
        /// <summary>
        /// Gets or sets the lower limit for created date.
        /// </summary>
        /// <value>
        /// The lower limit for created date.
        /// </value>
        public DateTime? CreatedFrom { get; set; }

        /// <summary>
        /// Gets or sets the upper limit for created date.
        /// </summary>
        /// <value>
        /// The upper limit for created date.
        /// </value>
        public DateTime? CreatedTo { get; set; }

        /// <summary>
        /// Gets or sets the lower limit for updated date.
        /// </summary>
        /// <value>
        /// The lower limit for updated date.
        /// </value>
        public DateTime? UpdatedFrom { get; set; }

        /// <summary>
        /// Gets or sets the upper limit for updated date.
        /// </summary>
        /// <value>
        /// The upper limit for updated date.
        /// </value>
        public DateTime? UpdatedTo { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public DataTransferObjectStatuses? Status { get; set; }

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

        /// <summary>
        /// Gets or sets the name of the property to order by.
        /// </summary>
        /// <value>
        /// The name of the property to order by.
        /// </value>
        public string OrderBy { get; set; }
    }
}
