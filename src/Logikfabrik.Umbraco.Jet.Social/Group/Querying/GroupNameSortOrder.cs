// <copyright file="GroupNameSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Group.Querying
{
    using Social.Querying;

    /// <summary>
    /// The <see cref="GroupNameSortOrder" /> class.
    /// </summary>
    public class GroupNameSortOrder : SortOrder, IGroupSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupNameSortOrder" /> class.
        /// </summary>
        /// <param name="order">The order.</param>
        public GroupNameSortOrder(Order order)
            : base("uJetSocialGroup.Name", order)
        {
        }
    }
}
