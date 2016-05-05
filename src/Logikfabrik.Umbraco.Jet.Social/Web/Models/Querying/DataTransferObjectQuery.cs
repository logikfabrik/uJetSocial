// <copyright file="DataTransferObjectQuery.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Models.Querying
{
    using System;

    /// <summary>
    /// The <see cref="DataTransferObjectQuery" /> class.
    /// </summary>
    public abstract class DataTransferObjectQuery : PagedQuery
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int? Id { get; set; }

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
        /// Gets or sets the name of the property to order by.
        /// </summary>
        /// <value>
        /// The name of the property to order by.
        /// </value>
        public string OrderBy { get; set; }
    }
}
