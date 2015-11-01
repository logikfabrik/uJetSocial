// <copyright file="GuestIndividualIdSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Individual.Querying
{
    using Social.Querying;

    /// <summary>
    /// The <see cref="GuestIndividualIdSortOrder" /> class.
    /// </summary>
    public class GuestIndividualIdSortOrder : EntityIdSortOrder, IGuestIndividualSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuestIndividualIdSortOrder" /> class.
        /// </summary>
        /// <param name="order">The order.</param>
        public GuestIndividualIdSortOrder(Order order)
            : base(order)
        {
        }
    }
}
