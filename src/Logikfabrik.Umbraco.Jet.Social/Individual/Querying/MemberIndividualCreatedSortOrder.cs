// <copyright file="MemberIndividualCreatedSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Individual.Querying
{
    using Social.Querying;

    /// <summary>
    /// Represents a member individual created sort order.
    /// </summary>
    public class MemberIndividualCreatedSortOrder : EntityCreatedSortOrder, IMemberIndividualSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberIndividualCreatedSortOrder" /> class.
        /// </summary>
        /// <param name="order">The sort order.</param>
        public MemberIndividualCreatedSortOrder(Order order)
            : base(order)
        {
        }
    }
}
