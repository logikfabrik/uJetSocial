// <copyright file="ContactUpdatedSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Contact.Querying
{
    using Social.Querying;

    /// <summary>
    /// The <see cref="ContactUpdatedSortOrder" /> class.
    /// </summary>
    public class ContactUpdatedSortOrder : EntityUpdatedSortOrder, IContactSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactUpdatedSortOrder" /> class.
        /// </summary>
        /// <param name="order">The order.</param>
        public ContactUpdatedSortOrder(Order order)
            : base(order)
        {
        }
    }
}
