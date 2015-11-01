// <copyright file="MemberIndividualUpdatedSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Individual.Querying
{
    using Social.Querying;

    /// <summary>
    /// The <see cref="MemberIndividualUpdatedSortOrder" /> class.
    /// </summary>
    public class MemberIndividualUpdatedSortOrder : EntityUpdatedSortOrder, IMemberIndividualSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberIndividualUpdatedSortOrder" /> class.
        /// </summary>
        /// <param name="order">The order.</param>
        public MemberIndividualUpdatedSortOrder(Order order)
            : base(order)
        {
        }
    }
}
