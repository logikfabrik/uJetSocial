// <copyright file="ContactStatusSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Contact.Querying
{
    using Social.Querying;

    /// <summary>
    /// Represents a contact status sort order.
    /// </summary>
    public class ContactStatusSortOrder : EntityStatusSortOrder, IContactSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactStatusSortOrder" /> class.
        /// </summary>
        /// <param name="order">The sort order.</param>
        public ContactStatusSortOrder(Order order)
            : base(order)
        {
        }
    }
}
