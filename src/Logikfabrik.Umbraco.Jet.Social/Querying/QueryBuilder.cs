// <copyright file="QueryBuilder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Querying
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Represents a query builder.
    /// </summary>
    /// <typeparam name="T1">The criteria type.</typeparam>
    /// <typeparam name="T2">The sort order type.</typeparam>
    public abstract class QueryBuilder<T1, T2> : IQueryBuilder<T1, T2>
        where T1 : ICriteria
        where T2 : class, ISortOrder
    {
        private readonly IEnumerable<string> _columns;
        private readonly string _table;

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
            _table = table;
        }

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
            return $"FROM {_table} ";
        }

        private string GetJoinClause()
        {
            var joins = GetJoins();

            var j = joins as string[] ?? joins.ToArray();

            return !j.Any() ? null : $"JOIN {string.Join(",", j)} ";
        }
    }
}
