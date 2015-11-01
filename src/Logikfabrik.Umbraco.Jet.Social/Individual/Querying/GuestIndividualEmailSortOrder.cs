// <copyright file="GuestIndividualEmailSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Individual.Querying
{
    using Social.Querying;

    /// <summary>
    /// The <see cref="GuestIndividualEmailSortOrder" /> class.
    /// </summary>
    public class GuestIndividualEmailSortOrder : SortOrder, IGuestIndividualSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuestIndividualEmailSortOrder" /> class.
        /// </summary>
        /// <param name="order">The order.</param>
        public GuestIndividualEmailSortOrder(Order order)
            : base("uJetCommunityIndividualGuest.Email", order)
        {
        }
    }
}
