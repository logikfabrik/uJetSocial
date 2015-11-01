// <copyright file="ContactToIdCriteria.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Contact.Querying
{
    using Social.Querying;

    /// <summary>
    /// The <see cref="ContactToIdCriteria" /> class.
    /// </summary>
    public class ContactToIdCriteria : Criteria, IContactCriteria
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactToIdCriteria" /> class.
        /// </summary>
        public ContactToIdCriteria()
            : base("uJetSocialContact.ToId")
        {
        }
    }
}
