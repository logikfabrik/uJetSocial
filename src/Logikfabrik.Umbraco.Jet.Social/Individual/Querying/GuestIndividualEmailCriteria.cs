// <copyright file="GuestIndividualEmailCriteria.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Individual.Querying
{
    using Social.Querying;

    /// <summary>
    /// Represents a guest individual e-mail criteria.
    /// </summary>
    public class GuestIndividualEmailCriteria : Criteria, IGuestIndividualCriteria
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuestIndividualEmailCriteria" /> class.
        /// </summary>
        public GuestIndividualEmailCriteria()
            : base("uJetCommunityIndividualGuest.Email")
        {
        }
    }
}
