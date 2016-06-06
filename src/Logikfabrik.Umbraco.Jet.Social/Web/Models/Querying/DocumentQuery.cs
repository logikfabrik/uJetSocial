// <copyright file="DocumentQuery.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Models.Querying
{
    /// <summary>
    /// The <see cref="DocumentQuery" /> class.
    /// </summary>
    public class DocumentQuery : DataTransferObjectQuery
    {
        /// <summary>
        /// Gets or sets the document identifier to query by.
        /// </summary>
        /// <value>
        /// The document identifier to query by.
        /// </value>
        public int? DocumentId { get; set; }
    }
}
