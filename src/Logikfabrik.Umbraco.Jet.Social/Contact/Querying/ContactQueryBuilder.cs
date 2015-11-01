// <copyright file="ContactQueryBuilder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Contact.Querying
{
    using System.Collections.Generic;
    using Social.Querying;

    /// <summary>
    /// The <see cref="ContactQueryBuilder" /> class.
    /// </summary>
    public class ContactQueryBuilder : EntityQueryBuilder<IContactCriteria, IContactSortOrder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactQueryBuilder" /> class.
        /// </summary>
        public ContactQueryBuilder()
            : base(GetColumns(), "uJetSocialContact")
        {
        }

        private static IEnumerable<string> GetColumns()
        {
            return new[]
            {
                "uJetSocialContact.FromId",
                "(SELECT CET.Type FROM uJetSocialEntityType as CET JOIN uJetSocialEntity AS CE ON CE.TypeId = CET.Id WHERE CE.Id = uJetSocialContact.FromId) AS FromType",
                "uJetSocialContact.ToId",
                "(SELECT CET.Type FROM uJetSocialEntityType as CET JOIN uJetSocialEntity AS CE ON CE.TypeId = CET.Id WHERE CE.Id = uJetSocialContact.ToId) AS ToType"
            };
        }
    }
}
