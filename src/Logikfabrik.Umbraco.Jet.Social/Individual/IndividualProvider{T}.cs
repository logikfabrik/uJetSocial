// <copyright file="IndividualProvider{T}.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Individual
{
    using System;

    /// <summary>
    /// The <see cref="IndividualProvider{T}" /> class.
    /// </summary>
    /// <typeparam name="T">The individual type.</typeparam>
    public abstract class IndividualProvider<T> : DataTransferObjectProvider<T>
        where T : Individual
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndividualProvider{T}" /> class.
        /// </summary>
        /// <param name="database">The database.</param>
        protected IndividualProvider(Func<IDatabaseWrapper> database)
            : base(database)
        {
        }
    }
}
