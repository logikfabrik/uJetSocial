// <copyright file="MemberIndividualStatusSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Individual.Querying
{
    using Social.Querying;

    /// <summary>
    /// The <see cref="MemberIndividualStatusSortOrder" /> class.
    /// </summary>
    public class MemberIndividualStatusSortOrder : EntityStatusSortOrder, IMemberIndividualSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberIndividualStatusSortOrder" /> class.
        /// </summary>
        /// <param name="order">The order.</param>
        public MemberIndividualStatusSortOrder(Order order)
            : base(order)
        {
        }
    }
}
