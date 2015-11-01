// <copyright file="IQueryBuilder{T1,T2}.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Querying
{
    /// <summary>
    /// The <see cref="IQueryBuilder{T1, T2}" /> interface.
    /// </summary>
    /// <typeparam name="T1">The criteria type.</typeparam>
    /// <typeparam name="T2">The sort order type.</typeparam>
    public interface IQueryBuilder<T1, T2>
        where T1 : ICriteria
        where T2 : class, ISortOrder
    {
        /// <summary>
        /// Gets the select command text.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>The select command text.</returns>
        string GetSelectCommandText(Query<T1, T2> query);

        /// <summary>
        /// Gets the count command text.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>The count command text.</returns>
        string GetCountCommandText(Query<T1, T2> query);
    }
}
