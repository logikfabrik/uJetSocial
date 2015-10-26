// <copyright file="GuestIndividualCreatedSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Individual.Querying
{
    using Social.Querying;

    /// <summary>
    /// Represents a guest individual created sort order.
    /// </summary>
    public class GuestIndividualCreatedSortOrder : EntityCreatedSortOrder, IGuestIndividualSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuestIndividualCreatedSortOrder" /> class.
        /// </summary>
        /// <param name="order">The sort order.</param>
        public GuestIndividualCreatedSortOrder(Order order)
            : base(order)
        {
        }
    }
}
