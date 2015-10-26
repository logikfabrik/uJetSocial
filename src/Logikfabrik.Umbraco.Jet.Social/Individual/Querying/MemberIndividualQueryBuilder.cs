// <copyright file="MemberIndividualQueryBuilder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Individual.Querying
{
    using System.Collections.Generic;
    using Social.Querying;

    /// <summary>
    /// Represents a member individual query builder.
    /// </summary>
    public class MemberIndividualQueryBuilder : EntityQueryBuilder<IMemberIndividualCriteria, IMemberIndividualSortOrder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberIndividualQueryBuilder" /> class.
        /// </summary>
        public MemberIndividualQueryBuilder()
            : base(GetColumns(), "uJetCommunityIndividualMember")
        {
        }

        private static IEnumerable<string> GetColumns()
        {
            return new[]
            {
                "uJetCommunityIndividualMember.MemberId"
            };
        }
    }
}
