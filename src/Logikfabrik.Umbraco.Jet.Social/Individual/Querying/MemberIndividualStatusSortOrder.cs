// <copyright file="MemberIndividualStatusSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Individual.Querying
{
    using Social.Querying;

    /// <summary>
    /// Represents a member individual status sort order.
    /// </summary>
    public class MemberIndividualStatusSortOrder : EntityStatusSortOrder, IMemberIndividualSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberIndividualStatusSortOrder" /> class.
        /// </summary>
        /// <param name="order">The sort order.</param>
        public MemberIndividualStatusSortOrder(Order order)
            : base(order)
        {
        }
    }
}
