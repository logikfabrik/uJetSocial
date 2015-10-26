// <copyright file="QueryableEntityProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Querying
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using Caching;

    /// <summary>
    /// Represents a queryable entity provider.
    /// </summary>
    /// <typeparam name="T1">The entity type.</typeparam>
    /// <typeparam name="T2">The criteria type.</typeparam>
    /// <typeparam name="T3">The sort order type.</typeparam>
    public abstract class QueryableEntityProvider<T1, T2, T3> : EntityProvider<T1>, IQueryableEntityProvider<T1, T2, T3>
        where T1 : Entity
        where T2 : ICriteria
        where T3 : class, ISortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryableEntityProvider{T1,T2,T3}" /> class.
        /// </summary>
        /// <param name="cacheManager">The cache manager to use.</param>
        /// <param name="databaseProvider">The database provider to use.</param>
        protected QueryableEntityProvider(ICacheManager cacheManager, IDatabaseProvider databaseProvider)
            : base(cacheManager, databaseProvider)
        {
        }

        /// <summary>
        /// Gets the query builder.
        /// </summary>
        protected abstract IQueryBuilder<T2, T3> QueryBuilder { get; }

        public IEnumerable<T1> Query(Query<T2, T3> query, out int total)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            var e = CacheManager.GetEntityQuery<T1>(query.GetCacheKey(), out total);

            if (e != null)
            {
                return e;
            }

            e = QueryDatabase(query, out total);

            if (e == null)
            {
                return new T1[] { };
            }

            var entities = e as T1[] ?? e.ToArray();

            CacheManager.AddEntityQuery(entities, total, query.GetCacheKey());

            return entities;
        }

        protected abstract T1 GetEntity(IDataReader reader);

        private IEnumerable<T1> QueryDatabase(Query<T2, T3> query, out int total)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            var builder = QueryBuilder;
            var entities = new List<T1>();

            using (var connection = DatabaseProvider.GetConnection())
            {
                connection.Open();

                using (var command = DatabaseProvider.GetCommand(connection, builder.GetSelectCommandText(query)))
                {
                    AddParameters(command, query);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            entities.Add(GetEntity(reader));
                        }
                    }
                }

                using (var command = DatabaseProvider.GetCommand(connection, builder.GetCountCommandText(query)))
                {
                    AddParameters(command, query);

                    total = (int)command.ExecuteScalar();
                }
            }

            return entities;
        }

        private void AddParameters(IDbCommand command, Query<T2, T3> query)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            foreach (var criteria in query.Criterias)
            {
                if (criteria.Value == null)
                {
                    continue;
                }

                foreach (var commandParameter in criteria.Value.GetCommandParameters(criteria))
                {
                    DatabaseProvider.AddCommandParameter(command, criteria.Value.DbType, commandParameter.Key, commandParameter.Value);
                }
            }
        }
    }
}
