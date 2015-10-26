﻿// <copyright file="MemberIndividualMemberIdSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Individual.Querying
{
    using Social.Querying;

    /// <summary>
    /// Represents a member individual member ID sort order.
    /// </summary>
    public class MemberIndividualMemberIdSortOrder : SortOrder, IMemberIndividualSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberIndividualMemberIdSortOrder" /> class.
        /// </summary>
        /// <param name="order">The sort order.</param>
        public MemberIndividualMemberIdSortOrder(Order order)
            : base("uJetCommunityIndividualMember.MemberId", order)
        {
        }
    }
}
