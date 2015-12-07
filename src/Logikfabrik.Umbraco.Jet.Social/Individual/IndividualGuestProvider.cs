// <copyright file="IndividualGuestProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Individual
{
    /// <summary>
    /// The <see cref="IndividualGuestProvider" /> class.
    /// </summary>
    public class IndividualGuestProvider : DataTransferObjectProvider<IndividualGuest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndividualGuestProvider" /> class.
        /// </summary>
        /// <param name="databaseWrapper">The database wrapper.</param>
        public IndividualGuestProvider(IDatabaseWrapper databaseWrapper)
            : base(databaseWrapper)
        {
        }
    }
}
