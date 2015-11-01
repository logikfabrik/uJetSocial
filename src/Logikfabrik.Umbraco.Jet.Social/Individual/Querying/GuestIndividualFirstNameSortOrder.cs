// <copyright file="GuestIndividualFirstNameSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Individual.Querying
{
    using Social.Querying;

    /// <summary>
    /// The <see cref="GuestIndividualFirstNameSortOrder" /> class.
    /// </summary>
    public class GuestIndividualFirstNameSortOrder : SortOrder, IGuestIndividualSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuestIndividualFirstNameSortOrder" /> class.
        /// </summary>
        /// <param name="order">The order.</param>
        public GuestIndividualFirstNameSortOrder(Order order)
            : base("uJetSocialIndividualGuest.FirstName", order)
        {
        }
    }
}
