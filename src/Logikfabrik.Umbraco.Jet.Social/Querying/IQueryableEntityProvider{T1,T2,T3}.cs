// <copyright file="IQueryableEntityProvider{T1,T2,T3}.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Querying
{
    using System.Collections.Generic;

    /// <summary>
    /// The <see cref="IQueryableEntityProvider{T1, T2, T3}" /> interface.
    /// </summary>
    /// <typeparam name="T1">The entity type.</typeparam>
    /// <typeparam name="T2">The criteria type.</typeparam>
    /// <typeparam name="T3">The sort order type.</typeparam>
    public interface IQueryableEntityProvider<T1, T2, T3> : IEntityProvider<T1>
        where T1 : Entity
        where T2 : ICriteria
        where T3 : class, ISortOrder
    {
        /// <summary>
        /// Queries the provider for entities.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="total">The total number of entities.</param>
        /// <returns>The entities.</returns>
        IEnumerable<T1> Query(Query<T2, T3> query, out int total);
    }
}