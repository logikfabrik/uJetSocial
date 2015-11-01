// <copyright file="EntityProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using Caching;

    /// <summary>
    /// The <see cref="EntityProvider{T}" /> class.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    public abstract class EntityProvider<T> : IEntityProvider<T>
        where T : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityProvider{T}" /> class.
        /// </summary>
        /// <param name="entityProviderFactory">The entity provider factory.</param>
        /// <param name="cacheManager">The cache manager.</param>
        /// <param name="databaseProvider">The database provider.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="entityProviderFactory" />, <paramref name="cacheManager" />, or <paramref name="databaseProvider" /> are <c>null</c>.</exception>
        protected EntityProvider(
            IEntityProviderFactory entityProviderFactory,
            ICacheManager cacheManager,
            IDatabaseProvider databaseProvider)
        {
            if (entityProviderFactory == null)
            {
                throw new ArgumentNullException(nameof(entityProviderFactory));
            }

            if (cacheManager == null)
            {
                throw new ArgumentNullException(nameof(cacheManager));
            }

            if (databaseProvider == null)
            {
                throw new ArgumentNullException(nameof(databaseProvider));
            }

            EntityProviderFactory = entityProviderFactory;
            CacheManager = cacheManager;
            DatabaseProvider = databaseProvider;

            RegisterEntityTypeInDatabase();
        }

        /// <summary>
        /// Gets the entity type this instance supports.
        /// </summary>
        public Type EntityType => typeof(T);

        /// <summary>
        /// Gets the entity provider factory.
        /// </summary>
        /// <value>
        /// The entity provider factory.
        /// </value>
        protected IEntityProviderFactory EntityProviderFactory { get; }

        /// <summary>
        /// Gets the cache manager.
        /// </summary>
        /// <value>
        /// The cache manager.
        /// </value>
        protected ICacheManager CacheManager { get; }

        /// <summary>
        /// Gets the database provider.
        /// </summary>
        /// <value>
        /// The database provider.
        /// </value>
        protected IDatabaseProvider DatabaseProvider { get; }

        /// <summary>
        /// Gets the entity count by created.
        /// </summary>
        /// <returns>The entity count by created.</returns>
        public IDictionary<int, IDictionary<int, int>> GetEntityCountByCreated()
        {
            using (var connection = DatabaseProvider.GetConnection())
            {
                using (var command = DatabaseProvider.GetProcedureCommand(connection, "uJetCommunityEntityCountByCreated"))
                {
                    DatabaseProvider.AddCommandParameter(command, DbType.String, "type", EntityType.FullName);

                    var countByYear = new Dictionary<int, IDictionary<int, int>>();

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var year = reader.GetInt32(0);
                            var month = reader.GetInt32(1);
                            var count = reader.GetInt32(2);

                            IDictionary<int, int> countByMonth;

                            if (!countByYear.TryGetValue(year, out countByMonth))
                            {
                                countByYear.Add(year, new Dictionary<int, int> { { month, count } });
                            }
                            else
                            {
                                countByMonth.Add(month, count);
                            }
                        }
                    }

                    return countByYear;
                }
            }
        }

        /// <summary>
        /// Gets the entity with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The entity.</returns>
        public T GetEntity(int id)
        {
            if (!EntityValidator.CanGetEntity(id))
            {
                throw new ArgumentException("Invalid entity ID.", nameof(id));
            }

            var cacheKey = GetDefaultCacheKey(id);

            return GetEntity(id, cacheKey);
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The added entity.</returns>
        public T AddEntity(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (!EntityValidator.CanAddEntity(entity))
            {
                throw new ArgumentException("The entity cannot be added.", nameof(entity));
            }

            var e = AddEntityToDatabase(entity);

            CacheManager.AddEntity(e);

            return e;
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The updated entity.</returns>
        public T UpdateEntity(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (!EntityValidator.CanUpdateEntity(entity))
            {
                throw new ArgumentException("The entity cannot be updated.", nameof(entity));
            }

            var e = UpdateEntityInDatabase(entity);

            CacheManager.UpdateEntity(e);

            return e;
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void RemoveEntity(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (!EntityValidator.CanRemoveEntity(entity))
            {
                throw new ArgumentException("The entity cannot be removed.", nameof(entity));
            }

            RemoveEntityFromDatabase(entity);

            CacheManager.RemoveEntity(entity);
        }

        /// <summary>
        /// Gets the entity with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The entity.</returns>
        Entity IEntityProvider.GetEntity(int id)
        {
            return GetEntity(id);
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The added entity.</returns>
        Entity IEntityProvider.AddEntity(Entity entity)
        {
            return AddEntity(entity as T);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The updated entity.</returns>
        Entity IEntityProvider.UpdateEntity(Entity entity)
        {
            return UpdateEntity(entity as T);
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void IEntityProvider.RemoveEntity(Entity entity)
        {
            RemoveEntity(entity as T);
        }

        /// <summary>
        /// Gets the entity with the specified identifier from the database.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The entity.</returns>
        protected abstract T GetEntityFromDatabase(int id);

        /// <summary>
        /// Adds the specified entity to the database.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The added entity.</returns>
        protected abstract T AddEntityToDatabase(T entity);

        /// <summary>
        /// Updates the specified entity in the database.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The updated entity.</returns>
        protected abstract T UpdateEntityInDatabase(T entity);

        /// <summary>
        /// Removes the specified entity from the database.
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected abstract void RemoveEntityFromDatabase(T entity);

        /// <summary>
        /// Gets the default cache key using the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The default cache key.</returns>
        protected abstract string GetDefaultCacheKey(int id);

        /// <summary>
        /// Gets the entity with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cacheKey">The cache key.</param>
        /// <returns>The entity.</returns>
        private T GetEntity(int id, string cacheKey)
        {
            if (!EntityValidator.CanGetEntity(id))
            {
                throw new ArgumentException("Invalid entity ID.", nameof(id));
            }

            if (string.IsNullOrWhiteSpace(cacheKey))
            {
                throw new ArgumentException("Cache key cannot be null or white space.", nameof(cacheKey));
            }

            var e = CacheManager.GetEntity<T>(cacheKey);

            if (e != null)
            {
                return e;
            }

            e = GetEntityFromDatabase(id);

            if (e == null)
            {
                return null;
            }

            CacheManager.AddEntity(e);

            return e;
        }

        /// <summary>
        /// Registers the entity type in the database.
        /// </summary>
        private void RegisterEntityTypeInDatabase()
        {
            using (var connection = DatabaseProvider.GetConnection())
            {
                using (var command = DatabaseProvider.GetProcedureCommand(connection, "uJetCommunityEntityTypeAdd"))
                {
                    DatabaseProvider.AddCommandParameter(command, DbType.String, "type", EntityType.FullName);

                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
