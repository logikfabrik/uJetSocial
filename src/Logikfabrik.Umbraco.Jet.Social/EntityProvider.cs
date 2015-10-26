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
    /// Represents a entity provider.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    public abstract class EntityProvider<T> : IEntityProvider<T>
        where T : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityProvider{T}" /> class.
        /// </summary>
        /// <param name="cacheManager">The cache manager to use.</param>
        /// <param name="databaseProvider">The database provider to use.</param>
        protected EntityProvider(ICacheManager cacheManager, IDatabaseProvider databaseProvider)
        {
            if (cacheManager == null)
            {
                throw new ArgumentNullException(nameof(cacheManager));
            }

            if (databaseProvider == null)
            {
                throw new ArgumentNullException(nameof(databaseProvider));
            }

            CacheManager = cacheManager;
            DatabaseProvider = databaseProvider;

            RegisterEntityTypeInDatabase();
        }

        /// <summary>
        /// Gets the entity type for the provider.
        /// </summary>
        public Type EntityType => typeof(T);

        /// <summary>
        /// Gets the cache manager.
        /// </summary>
        protected ICacheManager CacheManager { get; }

        /// <summary>
        /// Gets the database provider.
        /// </summary>
        protected IDatabaseProvider DatabaseProvider { get; }

        /// <summary>
        /// Gets the total entity count.
        /// </summary>
        /// <returns>The total entity count.</returns>
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
        /// Gets an entity.
        /// </summary>
        /// <param name="id">The entity ID.</param>
        /// <returns>An entity.</returns>
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
        /// Adds an entity.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
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

            var e = AddEntityToDatabase(DatabaseProvider, entity);

            CacheManager.AddEntity(e);

            return e;
        }

        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
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

            var e = UpdateEntityInDatabase(DatabaseProvider, entity);

            CacheManager.UpdateEntity(e);

            return e;
        }

        /// <summary>
        /// Removes an entity.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
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

            RemoveEntityFromDatabase(DatabaseProvider, entity);

            CacheManager.RemoveEntity(entity);
        }

        /// <summary>
        /// Gets an entity.
        /// </summary>
        /// <param name="id">The entity ID.</param>
        /// <returns>An entity.</returns>
        Entity IEntityProvider.GetEntity(int id)
        {
            return GetEntity(id);
        }

        /// <summary>
        /// Adds an entity.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The added entity.</returns>
        Entity IEntityProvider.AddEntity(Entity entity)
        {
            return AddEntity(entity as T);
        }

        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>The updated entity.</returns>
        Entity IEntityProvider.UpdateEntity(Entity entity)
        {
            return UpdateEntity(entity as T);
        }

        /// <summary>
        /// Removes an entity.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
        void IEntityProvider.RemoveEntity(Entity entity)
        {
            RemoveEntity(entity as T);
        }

        /// <summary>
        /// Gets an entity from the database.
        /// </summary>
        /// <param name="provider">A database provider.</param>
        /// <param name="id">The entity ID.</param>
        /// <returns>An entity.</returns>
        protected abstract T GetEntityFromDatabase(IDatabaseProvider provider, int id);

        /// <summary>
        /// Adds an entity to the database.
        /// </summary>
        /// <param name="provider">A database provider.</param>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The added entity.</returns>
        protected abstract T AddEntityToDatabase(IDatabaseProvider provider, T entity);

        /// <summary>
        /// Updates an entity in the database.
        /// </summary>
        /// <param name="provider">A database provider.</param>
        /// <param name="entity">The entity to update.</param>
        /// <returns>The updated entity.</returns>
        protected abstract T UpdateEntityInDatabase(IDatabaseProvider provider, T entity);

        /// <summary>
        /// Removes an entity from the database.
        /// </summary>
        /// <param name="provider">A database provider.</param>
        /// <param name="entity">The entity to remove.</param>
        protected abstract void RemoveEntityFromDatabase(IDatabaseProvider provider, T entity);

        /// <summary>
        /// Gets the default cache key.
        /// </summary>
        /// <param name="id">A entity ID.</param>
        /// <returns>The default cache key.</returns>
        protected abstract string GetDefaultCacheKey(int id);

        /// <summary>
        /// Gets an entity.
        /// </summary>
        /// <param name="id">The entity ID.</param>
        /// <param name="cacheKey">The entity cache key.</param>
        /// <returns>An entity.</returns>
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

            e = GetEntityFromDatabase(DatabaseProvider, id);

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
