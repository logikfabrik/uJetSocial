// <copyright file="ContactCreatedSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Contact.Querying
{
    using Social.Querying;

    /// <summary>
    /// Represents a contact created sort order.
    /// </summary>
    public class ContactCreatedSortOrder : EntityCreatedSortOrder, IContactSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactCreatedSortOrder" /> class.
        /// </summary>
        /// <param name="order">The sort order.</param>
        public ContactCreatedSortOrder(Order order)
            : base(order)
        {
        }
    }
}
