// <copyright file="MediaQuery.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Models.Querying
{
    /// <summary>
    /// The <see cref="MediaQuery" /> class.
    /// </summary>
    public class MediaQuery : DataTransferObjectQuery
    {
        /// <summary>
        /// Gets or sets the media identifier to query by.
        /// </summary>
        /// <value>
        /// The media identifier to query by.
        /// </value>
        public int? MediaId { get; set; }
    }
}
