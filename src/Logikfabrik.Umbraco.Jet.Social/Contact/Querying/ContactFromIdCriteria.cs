// <copyright file="ContactFromIdCriteria.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Contact.Querying
{
    using Social.Querying;

    /// <summary>
    /// Represents a contact from ID criteria.
    /// </summary>
    public class ContactFromIdCriteria : Criteria, IContactCriteria
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactFromIdCriteria" /> class.
        /// </summary>
        public ContactFromIdCriteria()
            : base("uJetCommunityContact.FromId")
        {
        }
    }
}
