// <copyright file="IQueryableEntityProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Querying
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents the queryable entity provider interface.
    /// </summary>
    /// <typeparam name="T1">The entity type.</typeparam>
    /// <typeparam name="T2">The criteria type.</typeparam>
    /// <typeparam name="T3">The sort order type.</typeparam>
    public interface IQueryableEntityProvider<T1, T2, T3> : IEntityProvider<T1>
        where T1 : Entity
        where T2 : ICriteria
        where T3 : class, ISortOrder
    {
        IEnumerable<T1> Query(Query<T2, T3> query, out int total);
    }
}