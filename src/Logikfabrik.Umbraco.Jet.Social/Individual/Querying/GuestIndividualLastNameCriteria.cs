// <copyright file="GuestIndividualLastNameCriteria.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Individual.Querying
{
    using Social.Querying;

    /// <summary>
    /// The <see cref="GuestIndividualLastNameCriteria" /> class.
    /// </summary>
    public class GuestIndividualLastNameCriteria : Criteria, IGuestIndividualCriteria
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuestIndividualLastNameCriteria" /> class.
        /// </summary>
        public GuestIndividualLastNameCriteria()
            : base("uJetCommunityIndividualGuest.LastName")
        {
        }
    }
}
