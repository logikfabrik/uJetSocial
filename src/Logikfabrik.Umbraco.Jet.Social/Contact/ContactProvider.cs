// <copyright file="ContactProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Contact
{
    /// <summary>
    /// The <see cref="ContactProvider" /> class.
    /// </summary>
    public class ContactProvider : DataTransferObjectProvider<Contact>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactProvider" /> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public ContactProvider(IDatabaseWrapper database)
            : base(database)
        {
        }
    }
}
