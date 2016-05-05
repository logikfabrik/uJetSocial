// <copyright file="IndividualGuestQuery.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Models.Querying
{
    /// <summary>
    /// The <see cref="IndividualGuestQuery" /> class.
    /// </summary>
    public class IndividualGuestQuery : Query
    {
        /// <summary>
        /// Gets or sets the first name to query by.
        /// </summary>
        /// <value>
        /// The first name to query by.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name to query by.
        /// </summary>
        /// <value>
        /// The last name to query by.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the e-mail to query by.
        /// </summary>
        /// <value>
        /// The e-mail to query by.
        /// </value>
        public string Email { get; set; }
    }
}
