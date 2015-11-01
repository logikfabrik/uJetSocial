// <copyright file="ContactFromIdSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Contact.Querying
{
    using Social.Querying;

    /// <summary>
    /// The <see cref="ContactFromIdSortOrder" /> class.
    /// </summary>
    public class ContactFromIdSortOrder : SortOrder, IContactSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactFromIdSortOrder" /> class.
        /// </summary>
        /// <param name="order">The order.</param>
        public ContactFromIdSortOrder(Order order)
            : base("uJetSocialContact.FromId", order)
        {
        }
    }
}
