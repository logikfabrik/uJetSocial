// <copyright file="MemberIndividualIdSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Individual.Querying
{
    using Social.Querying;

    /// <summary>
    /// The <see cref="MemberIndividualIdSortOrder" /> class.
    /// </summary>
    public class MemberIndividualIdSortOrder : EntityIdSortOrder, IMemberIndividualSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberIndividualIdSortOrder" /> class.
        /// </summary>
        /// <param name="order">The order.</param>
        public MemberIndividualIdSortOrder(Order order)
            : base(order)
        {
        }
    }
}
