// <copyright file="ContactToIdSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Contact.Querying
{
    using Social.Querying;

    /// <summary>
    /// The <see cref="ContactToIdSortOrder" /> class.
    /// </summary>
    public class ContactToIdSortOrder : SortOrder, IContactSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactToIdSortOrder" /> class.
        /// </summary>
        /// <param name="order">The order.</param>
        public ContactToIdSortOrder(Order order)
            : base("uJetSocialContact.ToId", order)
        {
        }
    }
}
