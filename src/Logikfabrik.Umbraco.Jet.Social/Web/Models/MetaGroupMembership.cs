// <copyright file="MetaGroupMembership.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Models
{
    using Group;

    /// <summary>
    /// The <see cref="MetaGroupMembership" /> class. Class for including meta data on API calls.
    /// </summary>
    /// <seealso cref="GroupMembership" />
    public class MetaGroupMembership : GroupMembership
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the e-mail.
        /// </summary>
        /// <value>
        /// The e-mail.
        /// </value>
        public string Email { get; set; }
    }
}
