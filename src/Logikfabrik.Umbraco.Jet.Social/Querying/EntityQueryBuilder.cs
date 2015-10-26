// <copyright file="EntityQueryBuilder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Querying
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents a entity query builder.
    /// </summary>
    /// <typeparam name="T1">The criteria type.</typeparam>
    /// <typeparam name="T2">The sort order type.</typeparam>
    public abstract class EntityQueryBuilder<T1, T2> : QueryBuilder<T1, T2>
        where T1 : ICriteria
        where T2 : class, ISortOrder
    {
        /// <summary>
        /// The table.
        /// </summary>
        private readonly string _table;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityQueryBuilder{T1,T2}" /> class.
        /// </summary>
        /// <param name="columns">The columns.</param>
        /// <param name="table">The table.</param>
        protected EntityQueryBuilder(IEnumerable<string> columns, string table)
            : base(GetColumns().Union(columns), "uJetCommunityEntity")
        {
            if (string.IsNullOrWhiteSpace(table))
            {
                throw new ArgumentException("Table cannot be null or white space.", nameof(table));
            }

            _table = table;
        }

        protected override IEnumerable<string> GetJoins()
        {
            return new[] { string.Format("{0} ON {0}.Id = uJetCommunityEntity.Id", _table) };
        }

        private static IEnumerable<string> GetColumns()
        {
            return new[]
            {
                "uJetCommunityEntity.Id",
                "uJetCommunityEntity.Created",
                "uJetCommunityEntity.Updated",
                "uJetCommunityEntity.Status"
            };
        }
    }
}
