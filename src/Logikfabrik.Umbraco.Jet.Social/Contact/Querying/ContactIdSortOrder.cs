// <copyright file="ContactIdSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Contact.Querying
{
    using Social.Querying;

    /// <summary>
    /// The <see cref="ContactIdSortOrder" /> class.
    /// </summary>
    public class ContactIdSortOrder : EntityIdSortOrder, IContactSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactIdSortOrder" /> class.
        /// </summary>
        /// <param name="order">The order.</param>
        public ContactIdSortOrder(Order order)
            : base(order)
        {
        }
    }
}
