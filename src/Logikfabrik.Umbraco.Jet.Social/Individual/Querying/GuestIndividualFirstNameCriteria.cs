// <copyright file="GuestIndividualFirstNameCriteria.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Individual.Querying
{
    using Social.Querying;

    /// <summary>
    /// The <see cref="GuestIndividualFirstNameCriteria" /> class.
    /// </summary>
    public class GuestIndividualFirstNameCriteria : Criteria, IGuestIndividualCriteria
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuestIndividualFirstNameCriteria" /> class.
        /// </summary>
        public GuestIndividualFirstNameCriteria()
            : base("uJetCommunityIndividualGuest.FirstName")
        {
        }
    }
}
