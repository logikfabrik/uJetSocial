// <copyright file="GuestIndividualUpdatedSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Individual.Querying
{
    using Social.Querying;

    /// <summary>
    /// Represents a guest individual updated sort order.
    /// </summary>
    public class GuestIndividualUpdatedSortOrder : EntityUpdatedSortOrder, IGuestIndividualSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuestIndividualUpdatedSortOrder" /> class.
        /// </summary>
        /// <param name="order">The sort order.</param>
        public GuestIndividualUpdatedSortOrder(Order order)
            : base(order)
        {
        }
    }
}
