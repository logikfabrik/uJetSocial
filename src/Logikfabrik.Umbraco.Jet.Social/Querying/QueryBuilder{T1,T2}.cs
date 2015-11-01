// <copyright file="QueryBuilder{T1,T2}.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Querying
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The <see cref="QueryBuilder{T1, T2}" /> class.
    /// </summary>
    /// <typeparam name="T1">The criteria type.</typeparam>
    /// <typeparam name="T2">The sort order type.</typeparam>
    public abstract class QueryBuilder<T1, T2> : IQueryBuilder<T1, T2>
        where T1 : ICriteria
        where T2 : class, ISortOrder
    {
        private readonly IEnumerable<string> _columns;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryBuilder{T1, T2}" /> class.
        /// </summary>
        /// <param name="columns">The columns.</param>
        /// <param name="table">The table.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="columns" /> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="table" /> is <c>null</c> or white space.</exception>
        protected QueryBuilder(IEnumerable<string> columns, string table)
        {
            if (columns == null)
            {
                throw new ArgumentNullException(nameof(columns));
            }

            if (string.IsNullOrWhiteSpace(table))
            {
                throw new ArgumentException("Table cannot be null or white space.", nameof(table));
            }

            _columns = columns;
            Table = table;
        }

        /// <summary>
        /// Gets the table.
        /// </summary>
        /// <value>
        /// The table.
        /// </value>
        protected string Table { get; }

        /// <summary>
        /// Gets the select command text.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>
        /// The select command text.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="query" /> is <c>null</c>.</exception>
        public string GetSelectCommandText(Query<T1, T2> query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            var builder = new StringBuilder();

            builder.Append(GetSelectClause());
            builder.Append(GetFromClause());
            builder.Append(GetJoinClause());
            builder.Append(GetWhereClause(query.Criterias));
            builder.Append(GetOrderByClause(query.SortOrder));
            builder.Append(GetOffsetClause(query.PageIndex, query.PageSize));

            return builder.ToString();
        }

        /// <summary>
        /// Gets the count command text.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>
        /// The count command text.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="query" /> is <c>null</c>.</exception>
        public string GetCountCommandText(Query<T1, T2> query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            var builder = new StringBuilder();

            builder.Append(GetCountClause());
            builder.Append(GetFromClause());
            builder.Append(GetJoinClause());
            builder.Append(GetWhereClause(query.Criterias));

            return builder.ToString();
        }

        /// <summary>
        /// Gets the joins.
        /// </summary>
        /// <returns>The joins.</returns>
        protected abstract IEnumerable<string> GetJoins();

        private static string GetCountClause()
        {
            return "SELECT COUNT(*) ";
        }

        private static string GetWhereClause(IEnumerable<T1> criterias)
        {
            if (criterias == null)
            {
                throw new ArgumentNullException(nameof(criterias));
            }

            var c = criterias as T1[] ?? criterias.ToArray();

            return !c.Any()
                ? null
                : $"WHERE {string.Join(", ", c.Select(criteria => criteria.GetCommandText()))} ";
        }

        private static string GetOrderByClause(T2 sortOrder)
        {
            if (sortOrder == null)
            {
                throw new ArgumentNullException(nameof(sortOrder));
            }

            return $"ORDER BY {sortOrder.Build()} ";
        }

        private static string GetOffsetClause(int pageIndex, int pageSize)
        {
            return $"OFFSET {pageIndex * pageSize} ROWS FETCH NEXT {pageSize} ROWS ONLY";
        }

        private string GetSelectClause()
        {
            return $"SELECT {string.Join(",", _columns)} ";
        }

        private string GetFromClause()
        {
            return $"FROM {Table} ";
        }

        private string GetJoinClause()
        {
            var joins = GetJoins();

            var j = joins as string[] ?? joins.ToArray();

            return !j.Any() ? null : $"JOIN {string.Join(",", j)} ";
        }
    }
}
