// <copyright file="MemberIndividualMemberIdCriteria.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Individual.Querying
{
    using Social.Querying;

    /// <summary>
    /// Represents a member individual member ID criteria.
    /// </summary>
    public class MemberIndividualMemberIdCriteria : Criteria, IMemberIndividualCriteria
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberIndividualMemberIdCriteria" /> class.
        /// </summary>
        public MemberIndividualMemberIdCriteria()
            : base("uJetCommunityIndividualMember.MemberId")
        {
        }
    }
}
