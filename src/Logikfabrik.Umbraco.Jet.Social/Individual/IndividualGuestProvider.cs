// <copyright file="IndividualGuestProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Individual
{
    using System;

    /// <summary>
    /// The <see cref="IndividualGuestProvider" /> class.
    /// </summary>
    public class IndividualGuestProvider : IndividualProvider<IndividualGuest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndividualGuestProvider" /> class.
        /// </summary>
        /// <param name="cache">The cache.</param>
        /// <param name="database">The database.</param>
        public IndividualGuestProvider(
            Func<ICacheWrapper> cache,
            Func<IDatabaseWrapper> database)
            : base(cache, database)
        {
        }
    }
}
