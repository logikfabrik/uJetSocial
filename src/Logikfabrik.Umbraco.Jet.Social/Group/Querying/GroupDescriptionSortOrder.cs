// <copyright file="GroupDescriptionSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Group.Querying
{
    using Social.Querying;

    /// <summary>
    /// The <see cref="GroupDescriptionSortOrder" /> class.
    /// </summary>
    public class GroupDescriptionSortOrder : SortOrder, IGroupSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupDescriptionSortOrder" /> class.
        /// </summary>
        /// <param name="order">The order.</param>
        public GroupDescriptionSortOrder(Order order)
            : base("uJetSocialGroup.Description", order)
        {
        }
    }
}
