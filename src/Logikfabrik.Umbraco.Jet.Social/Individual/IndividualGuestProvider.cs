// <copyright file="IndividualGuestProvider.cs" company="Logikfabrik">
//  Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Data
{
    using global::Umbraco.Core.Persistence;

    /// <summary>
    /// The <see cref="IndividualGuestProvider" /> class.
    /// </summary>
    public sealed class IndividualGuestProvider : DataTransferObjectProvider<IndividualGuest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndividualGuestProvider" /> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public IndividualGuestProvider(Database database)
            : base(database)
        {
        }
    }
}
