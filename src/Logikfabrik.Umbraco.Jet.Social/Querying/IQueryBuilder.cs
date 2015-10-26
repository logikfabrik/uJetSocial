// <copyright file="IQueryBuilder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Querying
{
    /// <summary>
    /// Represents the query builder interface.
    /// </summary>
    /// <typeparam name="T1">The criteria type.</typeparam>
    /// <typeparam name="T2">The sort order type.</typeparam>
    public interface IQueryBuilder<T1, T2>
        where T1 : ICriteria
        where T2 : class, ISortOrder
    {
        string GetSelectCommandText(Query<T1, T2> query);

        string GetCountCommandText(Query<T1, T2> query);
    }
}
