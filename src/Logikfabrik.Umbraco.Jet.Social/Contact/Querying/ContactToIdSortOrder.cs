// <copyright file="ContactToIdSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Contact.Querying
{
    using Social.Querying;

    /// <summary>
    /// Represents a contact to ID sort order.
    /// </summary>
    public class ContactToIdSortOrder : SortOrder, IContactSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactToIdSortOrder" /> class.
        /// </summary>
        /// <param name="order">The sort order.</param>
        public ContactToIdSortOrder(Order order)
            : base("uJetCommunityContact.ToId", order)
        {
        }
    }
}
