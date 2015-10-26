// <copyright file="ContactFromIdSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Contact.Querying
{
    using Social.Querying;

    /// <summary>
    /// Represents a contact from ID sort order.
    /// </summary>
    public class ContactFromIdSortOrder : SortOrder, IContactSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactFromIdSortOrder" /> class.
        /// </summary>
        /// <param name="order">The sort order.</param>
        public ContactFromIdSortOrder(Order order)
            : base("uJetCommunityContact.FromId", order)
        {
        }
    }
}
