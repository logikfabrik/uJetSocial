// <copyright file="IndividualMemberQuery.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Models.Querying
{
    /// <summary>
    /// The <see cref="IndividualMemberQuery" /> class.
    /// </summary>
    public class IndividualMemberQuery : DataTransferObjectQuery
    {
        /// <summary>
        /// Gets or sets the member identifier to query by.
        /// </summary>
        /// <value>
        /// The member identifier to query by.
        /// </value>
        public int? MemberId { get; set; }
    }
}
