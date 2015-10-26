// <copyright file="ContactQueryBuilder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Contact.Querying
{
    using System.Collections.Generic;
    using Social.Querying;

    /// <summary>
    /// Represents a contact query builder.
    /// </summary>
    public class ContactQueryBuilder : EntityQueryBuilder<IContactCriteria, IContactSortOrder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactQueryBuilder" /> class.
        /// </summary>
        public ContactQueryBuilder()
            : base(GetColumns(), "uJetCommunityContact")
        {
        }

        private static IEnumerable<string> GetColumns()
        {
            return new[]
            {
                "uJetCommunityContact.FromId",
                "(SELECT CET.Type FROM uJetCommunityEntityType as CET JOIN uJetCommunityEntity AS CE ON CE.TypeId = CET.Id WHERE CE.Id = uJetCommunityContact.FromId) AS FromType",
                "uJetCommunityContact.ToId",
                "(SELECT CET.Type FROM uJetCommunityEntityType as CET JOIN uJetCommunityEntity AS CE ON CE.TypeId = CET.Id WHERE CE.Id = uJetCommunityContact.ToId) AS ToType"
            };
        }
    }
}
