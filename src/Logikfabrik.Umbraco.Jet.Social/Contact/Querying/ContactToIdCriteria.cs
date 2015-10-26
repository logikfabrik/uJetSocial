// <copyright file="ContactToIdCriteria.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Contact.Querying
{
    using Social.Querying;

    /// <summary>
    /// Represents a contact to ID criteria.
    /// </summary>
    public class ContactToIdCriteria : Criteria, IContactCriteria
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactToIdCriteria" /> class.
        /// </summary>
        public ContactToIdCriteria()
            : base("uJetCommunityContact.ToId")
        {
        }
    }
}
