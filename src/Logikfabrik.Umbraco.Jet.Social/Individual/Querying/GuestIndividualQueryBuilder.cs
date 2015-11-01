// <copyright file="GuestIndividualQueryBuilder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Individual.Querying
{
    using System.Collections.Generic;
    using Social.Querying;

    /// <summary>
    /// The <see cref="GuestIndividualQueryBuilder" /> class.
    /// </summary>
    public class GuestIndividualQueryBuilder : EntityQueryBuilder<IGuestIndividualCriteria, IGuestIndividualSortOrder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuestIndividualQueryBuilder" /> class.
        /// </summary>
        public GuestIndividualQueryBuilder()
            : base(GetColumns(), "uJetSocialIndividualGuest")
        {
        }

        private static IEnumerable<string> GetColumns()
        {
            return new[]
            {
                "uJetSocialIndividualGuest.FirstName",
                "uJetSocialIndividualGuest.LastName",
                "uJetSocialIndividualGuest.Email"
            };
        }
    }
}
