// <copyright file="GuestIndividualStatusSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Individual.Querying
{
    using Social.Querying;

    /// <summary>
    /// The <see cref="GuestIndividualStatusSortOrder" /> class.
    /// </summary>
    public class GuestIndividualStatusSortOrder : EntityStatusSortOrder, IGuestIndividualSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuestIndividualStatusSortOrder" /> class.
        /// </summary>
        /// <param name="order">The order.</param>
        public GuestIndividualStatusSortOrder(Order order)
            : base(order)
        {
        }
    }
}
