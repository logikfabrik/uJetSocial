// <copyright file="GuestIndividualLastNameSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Individual.Querying
{
    using Social.Querying;

    /// <summary>
    /// The <see cref="GuestIndividualLastNameSortOrder" /> class.
    /// </summary>
    public class GuestIndividualLastNameSortOrder : SortOrder, IGuestIndividualSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuestIndividualLastNameSortOrder" /> class.
        /// </summary>
        /// <param name="order">The order.</param>
        public GuestIndividualLastNameSortOrder(Order order)
            : base("uJetSocialIndividualGuest.LastName", order)
        {
        }
    }
}
